using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class RecouvrementService
    {
        private readonly Connexion_db bd = new Connexion_db();

        // Charger les sections
        public DataTable ObtenirSections()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, NomSection FROM Sections ORDER BY NomSection;";
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Charger les classes par section
        public DataTable ObtenirClassesParSection(int sectionId = 0)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, NomClasse FROM Classes WHERE (@SectionId = 0 OR SectionId = @SectionId) ORDER BY NomClasse;";
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SectionId", sectionId);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Charger les configurations de frais
        public DataTable ObtenirConfigurationsFrais()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, LibelleFrais, Montant, Devise, EchanceMois FROM ConfigurationFrais ORDER BY LibelleFrais;";
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Obtenir la situation de recouvrement filtrée
        public List<EleveSolvabilite> ObtenirRapportRecouvrement(int fraisId, int sectionId = 0, int classeId = 0, string mois = "", string filtreStatut = "TOUS")
        {
            List<EleveSolvabilite> liste = new List<EleveSolvabilite>();

            string query = @"
            SELECT 
                e.Id AS EleveId,
                e.Matricule,
                CONCAT(e.Nom, ' ', e.Postnom, ' ', e.Prenom) AS NomComplet,
                e.Sexe,
                s.NomSection,
                c.NomClasse,
                f.LibelleFrais,
                f.Montant AS MontantDu,
                f.Devise,
                IFNULL(SUM(p.MontantPaye), 0) AS MontantPaye,
                e.TelephoneTuteur
            FROM Eleves e
            INNER JOIN Classes c ON e.ClasseId = c.Id
            INNER JOIN Sections s ON c.SectionId = s.Id
            CROSS JOIN ConfigurationFrais f ON f.Id = @FraisId
            LEFT JOIN Paiements p ON p.EleveId = e.Id AND p.FraisId = f.Id
                AND (@Mois = '' OR p.MoisConcerne = @Mois)
            WHERE e.Actif = 1
              AND (@SectionId = 0 OR s.Id = @SectionId)
              AND (@ClasseId = 0 OR c.Id = @ClasseId)
              AND (f.ClasseId IS NULL OR f.ClasseId = c.Id)
            GROUP BY e.Id, e.Matricule, NomComplet, e.Sexe, s.NomSection, c.NomClasse, f.LibelleFrais, f.Montant, f.Devise, e.TelephoneTuteur
            ORDER BY c.NomClasse, e.Nom, e.Postnom;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FraisId", fraisId);
                    cmd.Parameters.AddWithValue("@SectionId", sectionId);
                    cmd.Parameters.AddWithValue("@ClasseId", classeId);
                    cmd.Parameters.AddWithValue("@Mois", string.IsNullOrEmpty(mois) ? "" : mois);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new EleveSolvabilite
                            {
                                EleveId = Convert.ToInt32(reader["EleveId"]),
                                Matricule = reader["Matricule"].ToString(),
                                NomComplet = reader["NomComplet"].ToString(),
                                Sexe = reader["Sexe"].ToString(),
                                Section = reader["NomSection"].ToString(),
                                Classe = reader["NomClasse"].ToString(),
                                FraisLibelle = reader["LibelleFrais"].ToString(),
                                MontantDu = Convert.ToDecimal(reader["MontantDu"]),
                                MontantPaye = Convert.ToDecimal(reader["MontantPaye"]),
                                Devise = reader["Devise"].ToString(),
                                TelephoneTuteur = reader["TelephoneTuteur"]?.ToString() ?? "-"
                            };

                            // Filtrage selon le statut demandé
                            if (filtreStatut == "A_JOUR" && item.SoldeRestant <= 0)
                                liste.Add(item);
                            else if (filtreStatut == "INSOLVABLE" && item.SoldeRestant > 0)
                                liste.Add(item);
                            else if (filtreStatut == "TOUS")
                                liste.Add(item);
                        }
                    }
                }
            }

            return liste;
        }

        // Récupérer l'entête de l'école pour les rapports PDF
        public DataTable ObtenirParametresEcole()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Paramettres LIMIT 1;";
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
