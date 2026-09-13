using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public class PaiementModel
    {
        public int Id { get; set; }
        public string NumeroRecu { get; set; }
        public int EleveId { get; set; }
        public int FraisId { get; set; }
        public decimal MontantPaye { get; set; }
        public string Devise { get; set; }
        public string ModePaiement { get; set; }
        public string MoisConcerne { get; set; }
        public int UtilisateurId { get; set; }
        public string Observations { get; set; }
    }

    public class PaiementService
    {
        private Connexion_db bd = new Connexion_db();

       
        public DataTable ObtenirTousLesPaiements(string filtreRecherche = "")
        {
            DataTable dt = new DataTable();
            string query = @"
    SELECT 
        p.Id,
        e.Matricule,
        CONCAT(e.Nom, ' ', e.Postnom, ' ', e.Prenom) AS `Élève`,
        c.NomClasse AS `Classe`,
        f.LibelleFrais AS `Motif / Frais`,
        IFNULL(p.MoisConcerne, '-') AS `Échéance`,
        p.MontantPaye AS `Montant`,
        p.Devise,
        p.ModePaiement AS `Mode`,
        p.NumeroRecu AS `N° Reçu`,
        p.DatePaiement AS `Date & Heure`,
        u.NomComplet AS `Caissier`,
        IFNULL(p.Observations, '') AS `Observations`
    FROM Paiements p
    INNER JOIN Eleves e ON p.EleveId = e.Id
    INNER JOIN Classes c ON e.ClasseId = c.Id
    INNER JOIN ConfigurationFrais f ON p.FraisId = f.Id
    INNER JOIN Utilisateurs u ON p.UtilisateurId = u.Id
    WHERE (
        p.NumeroRecu LIKE @Filtre OR
        e.Matricule LIKE @Filtre OR
        e.Nom LIKE @Filtre OR
        e.Postnom LIKE @Filtre OR
        e.Prenom LIKE @Filtre OR
        c.NomClasse LIKE @Filtre OR
        f.LibelleFrais LIKE @Filtre
    )
    ORDER BY p.DatePaiement DESC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Filtre", "%" + filtreRecherche + "%");
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des paiements : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        // ---------------------------------------------------------
        // 1. RECHERCHE RAPIDE D'ÉLÈVES (Matricule, Nom, Classe)
        // ---------------------------------------------------------
        public DataTable RechercherEleves(string recherche)
        {
            DataTable dt = new DataTable();

            if (string.IsNullOrWhiteSpace(recherche))
                return dt;

            // Découpage du texte de recherche par les espaces (ex: "ILUNGA BANZA" -> ["ILUNGA", "BANZA"])
            string[] mots = recherche.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Si aucun mot valide
            if (mots.Length == 0)
                return dt;

            // Construction dynamique des clauses WHERE pour chaque mot
            List<string> conditionsMots = new List<string>();

            for (int i = 0; i < mots.Length; i++)
            {
                // Pour chaque mot, il doit correspondre soit au Nom, Postnom, Prenom, Matricule, Classe ou au NomComplet concaténé
                string condition = $"(e.Matricule LIKE @Mot{i} OR " +
                                   $"e.Nom LIKE @Mot{i} OR " +
                                   $"e.Postnom LIKE @Mot{i} OR " +
                                   $"e.Prenom LIKE @Mot{i} OR " +
                                   $"c.NomClasse LIKE @Mot{i} OR " +
                                   $"CONCAT(e.Nom, ' ', e.Postnom, ' ', e.Prenom) LIKE @Mot{i})";

                conditionsMots.Add(condition);
            }

            // Combinaison des conditions avec des AND pour que TOUS les mots recherchés soient trouvés
            string whereClause = string.Join(" AND ", conditionsMots);

            string query = $@"
    SELECT 
        e.Id, e.Matricule, e.Nom, e.Postnom, e.Prenom, 
        CONCAT(e.Nom, ' ', e.Postnom, ' ', e.Prenom) AS NomComplet,
        e.ClasseId, c.NomClasse AS Classe, e.TypeEleve
    FROM Eleves e
    INNER JOIN Classes c ON e.ClasseId = c.Id
    WHERE e.Actif = 1 AND ({whereClause})
    ORDER BY e.Nom ASC, e.Postnom ASC, e.Prenom ASC 
    LIMIT 30;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Ajout des paramètres pour chaque mot
                        for (int i = 0; i < mots.Length; i++)
                        {
                            cmd.Parameters.AddWithValue($"@Mot{i}", "%" + mots[i] + "%");
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche des élèves : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        // ---------------------------------------------------------
        // 2. CHARGER LES FRAIS APPLICABLES A UN ÉLÈVE ET CALCULER LE SOLDE
        // ---------------------------------------------------------
        public DataTable ObtenirFraisEtSoldesParEleve(int eleveId, int classeId)
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT 
                f.Id AS FraisId,
                f.LibelleFrais,
                IFNULL(f.EchanceMois, 'N/A') AS EcheanceMois,
                f.Montant AS MontantTotal,
                f.Devise,
                IFNULL(SUM(p.MontantPaye), 0) AS TotalDejaPaye,
                (f.Montant - IFNULL(SUM(p.MontantPaye), 0)) AS ResteAPayer
            FROM ConfigurationFrais f
            INNER JOIN AnneesScolaires a ON f.AnneeScolaireId = a.Id
            LEFT JOIN Paiements p ON p.FraisId = f.Id AND p.EleveId = @EleveId
            WHERE a.EstActive = 1 AND (f.ClasseId = @ClasseId OR f.ClasseId IS NULL)
            GROUP BY f.Id, f.LibelleFrais, f.EchanceMois, f.Montant, f.Devise
            HAVING ResteAPayer > 0;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EleveId", eleveId);
                        cmd.Parameters.AddWithValue("@ClasseId", classeId);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du calcul du solde des frais : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // ---------------------------------------------------------
        // 3. ENREGISTRER UN PAIEMENT
        // ---------------------------------------------------------
        public bool EnregistrerPaiement(PaiementModel p)
        {
            string query = @"
            INSERT INTO Paiements (NumeroRecu, EleveId, FraisId, MontantPaye, Devise, ModePaiement, MoisConcerne, UtilisateurId, Observations)
            VALUES (@NumRecu, @EleveId, @FraisId, @Montant, @Devise, @Mode, @Mois, @UserId, @Obs);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NumRecu", p.NumeroRecu);
                        cmd.Parameters.AddWithValue("@EleveId", p.EleveId);
                        cmd.Parameters.AddWithValue("@FraisId", p.FraisId);
                        cmd.Parameters.AddWithValue("@Montant", p.MontantPaye);
                        cmd.Parameters.AddWithValue("@Devise", p.Devise);
                        cmd.Parameters.AddWithValue("@Mode", p.ModePaiement);
                        cmd.Parameters.AddWithValue("@Mois", string.IsNullOrEmpty(p.MoisConcerne) ? (object)DBNull.Value : p.MoisConcerne);
                        cmd.Parameters.AddWithValue("@UserId", p.UtilisateurId);
                        cmd.Parameters.AddWithValue("@Obs", string.IsNullOrEmpty(p.Observations) ? (object)DBNull.Value : p.Observations);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement du paiement : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------------------------------------------
        // 4. GÉNÉRATION DE NUMÉRO DE REÇU UNIQUE
        // ---------------------------------------------------------
        public string GenererNumeroRecu()
        {
            return "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }


    }
}
