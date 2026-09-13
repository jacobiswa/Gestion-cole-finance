using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class LigneRapportFinancier
    {
        public string Categorie { get; set; }        // Ex: Type de frais, Classe ou Section
        public string Detail { get; set; }           // Ex: Mode de paiement ou Mois
        public int NombreTransactions { get; set; }
        public decimal TotalUSD { get; set; }
        public decimal TotalCDF { get; set; }
    }

    // Statistiques du taux de recouvrement
    public class StatistiqueRecouvrement
    {
        public string NomClasse { get; set; }
        public string NomSection { get; set; }
        public int TotalEleves { get; set; }
        public int ElevesAJour { get; set; }
        public int ElevesInsolvables { get; set; }
        public decimal TauxRecouvrement => TotalEleves == 0 ? 0 : Math.Round((decimal)ElevesAJour / TotalEleves * 100, 2);
    }

    // Synthèse globale annuelle pour le promoteur / direction
    public class SyntheseAnnuelle
    {
        public int TotalElevesInscrits { get; set; }
        public decimal MontantTotalAttenduUSD { get; set; }
        public decimal MontantTotalRecouvreUSD { get; set; }
        public decimal MontantTotalResteUSD => MontantTotalAttenduUSD - MontantTotalRecouvreUSD;
        public decimal TauxGlobalRecouvrement => MontantTotalAttenduUSD == 0 ? 0 : Math.Round((MontantTotalRecouvreUSD / MontantTotalAttenduUSD) * 100, 2);
    }
    public class RapportService
    {
        private readonly Connexion_db bd = new Connexion_db();

        // ---------------------------------------------------------
        // 1. RAPPORT JOURNALIER DE CAISSE
        // ---------------------------------------------------------
        public List<LigneRapportFinancier> ObtenirJournalCaisse(DateTime dateJour)
        {
            List<LigneRapportFinancier> liste = new List<LigneRapportFinancier>();

            string query = @"
            SELECT 
                f.LibelleFrais AS Categorie,
                p.ModePaiement AS Detail,
                COUNT(p.Id) AS NbTrans,
                SUM(CASE WHEN p.Devise = 'USD' THEN p.MontantPaye ELSE 0 END) AS TotalUSD,
                SUM(CASE WHEN p.Devise = 'CDF' THEN p.MontantPaye ELSE 0 END) AS TotalCDF
            FROM Paiements p
            INNER JOIN ConfigurationFrais f ON p.FraisId = f.Id
            WHERE DATE(p.DatePaiement) = @DateJour
            GROUP BY f.LibelleFrais, p.ModePaiement
            ORDER BY f.LibelleFrais, p.ModePaiement;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DateJour", dateJour.ToString("yyyy-MM-dd"));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new LigneRapportFinancier
                            {
                                Categorie = reader["Categorie"].ToString(),
                                Detail = reader["Detail"].ToString(),
                                NombreTransactions = Convert.ToInt32(reader["NbTrans"]),
                                TotalUSD = Convert.ToDecimal(reader["TotalUSD"]),
                                TotalCDF = Convert.ToDecimal(reader["TotalCDF"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        // ---------------------------------------------------------
        // 2. BILAN MENSUEL ET TRIMESTRIEL PAR SECTION / CLASSE
        // ---------------------------------------------------------
        public List<LigneRapportFinancier> ObtenirBilanPeriodique(DateTime dateDebut, DateTime dateFin, int sectionId = 0)
        {
            List<LigneRapportFinancier> liste = new List<LigneRapportFinancier>();

            string query = @"
            SELECT 
                s.NomSection AS Categorie,
                c.NomClasse AS Detail,
                COUNT(p.Id) AS NbTrans,
                SUM(CASE WHEN p.Devise = 'USD' THEN p.MontantPaye ELSE 0 END) AS TotalUSD,
                SUM(CASE WHEN p.Devise = 'CDF' THEN p.MontantPaye ELSE 0 END) AS TotalCDF
            FROM Paiements p
            INNER JOIN Eleves e ON p.EleveId = e.Id
            INNER JOIN Classes c ON e.ClasseId = c.Id
            INNER JOIN Sections s ON c.SectionId = s.Id
            WHERE DATE(p.DatePaiement) BETWEEN @DateDebut AND @DateFin
              AND (@SectionId = 0 OR s.Id = @SectionId)
            GROUP BY s.NomSection, c.NomClasse
            ORDER BY s.NomSection, c.NomClasse;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DateDebut", dateDebut.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateFin", dateFin.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@SectionId", sectionId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new LigneRapportFinancier
                            {
                                Categorie = reader["Categorie"].ToString(),
                                Detail = reader["Detail"].ToString(),
                                NombreTransactions = Convert.ToInt32(reader["NbTrans"]),
                                TotalUSD = Convert.ToDecimal(reader["TotalUSD"]),
                                TotalCDF = Convert.ToDecimal(reader["TotalCDF"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        // ---------------------------------------------------------
        // 3. TAUX DE RECOUVREMENT PAR CLASSE
        // ---------------------------------------------------------
        public List<StatistiqueRecouvrement> ObtenirTauxRecouvrement(int fraisId)
        {
            List<StatistiqueRecouvrement> liste = new List<StatistiqueRecouvrement>();

            string query = @"
            SELECT 
                s.NomSection,
                c.NomClasse,
                COUNT(e.Id) AS TotalEleves,
                SUM(CASE WHEN IFNULL(paye.TotalPaye, 0) >= f.Montant THEN 1 ELSE 0 END) AS ElevesAJour,
                SUM(CASE WHEN IFNULL(paye.TotalPaye, 0) < f.Montant THEN 1 ELSE 0 END) AS ElevesInsolvables
            FROM Eleves e
            INNER JOIN Classes c ON e.ClasseId = c.Id
            INNER JOIN Sections s ON c.SectionId = s.Id
            CROSS JOIN ConfigurationFrais f ON f.Id = @FraisId
            LEFT JOIN (
                SELECT EleveId, SUM(MontantPaye) AS TotalPaye
                FROM Paiements
                WHERE FraisId = @FraisId
                GROUP BY EleveId
            ) paye ON paye.EleveId = e.Id
            WHERE e.Actif = 1 AND (f.ClasseId IS NULL OR f.ClasseId = c.Id)
            GROUP BY s.NomSection, c.NomClasse
            ORDER BY s.NomSection, c.NomClasse;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FraisId", fraisId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new StatistiqueRecouvrement
                            {
                                NomSection = reader["NomSection"].ToString(),
                                NomClasse = reader["NomClasse"].ToString(),
                                TotalEleves = Convert.ToInt32(reader["TotalEleves"]),
                                ElevesAJour = Convert.ToInt32(reader["ElevesAJour"]),
                                ElevesInsolvables = Convert.ToInt32(reader["ElevesInsolvables"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        // ---------------------------------------------------------
        // 4. SYNTHÈSE ANNUELLE GLOBALE
        // ---------------------------------------------------------
        public SyntheseAnnuelle ObtenirSyntheseAnnuelle(int anneeScolaireId)
        {
            SyntheseAnnuelle syn = new SyntheseAnnuelle();

            string query = @"
            SELECT 
                (SELECT COUNT(*) FROM Eleves WHERE Actif = 1) AS TotalEleves,
                IFNULL((
                    SELECT SUM(f.Montant) 
                    FROM Eleves e 
                    INNER JOIN ConfigurationFrais f ON (f.ClasseId IS NULL OR f.ClasseId = e.ClasseId)
                    WHERE e.Actif = 1 AND f.AnneeScolaireId = @AnneeId
                ), 0) AS MontantAttenduUSD,
                IFNULL((
                    SELECT SUM(p.MontantPaye) 
                    FROM Paiements p
                    INNER JOIN ConfigurationFrais f ON p.FraisId = f.Id
                    WHERE f.AnneeScolaireId = @AnneeId AND p.Devise = 'USD'
                ), 0) AS MontantRecouvreUSD;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AnneeId", anneeScolaireId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            syn.TotalElevesInscrits = Convert.ToInt32(reader["TotalEleves"]);
                            syn.MontantTotalAttenduUSD = Convert.ToDecimal(reader["MontantAttenduUSD"]);
                            syn.MontantTotalRecouvreUSD = Convert.ToDecimal(reader["MontantRecouvreUSD"]);
                        }
                    }
                }
            }
            return syn;
        }

        // Méthodes auxiliaires pour comboboxes
        public DataTable ObtenirAnneesScolaires()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Libelle FROM AnneesScolaires ORDER BY Id DESC;";
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd)) da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenirParametresEcole()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Paramettres LIMIT 1;";
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd)) da.Fill(dt);
            }
            return dt;
        }
    }
}
