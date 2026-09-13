using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace FINANCIERE_SCOLAIRE
{
        public class DashboardMetrics
        {
            public int TotalEleves { get; set; }
            public decimal TotalEncaisseJour { get; set; }
            public decimal TotalEncaisseMois { get; set; }
            public int NombreInsolvables { get; set; }
            public decimal TauxRecouvrement { get; set; }
            public int TotalUtilisateurs { get; set; }
        }

        public class DashboardService
        {
            private readonly Connexion_db _bd = new Connexion_db();

            /// <summary>
            /// Calcule les métriques clés (KPIs) pour le tableau de bord
            /// </summary>
            public DashboardMetrics ObtenirMetriquesGlobales()
            {
                DashboardMetrics metrics = new DashboardMetrics();

                using (MySqlConnection conn = _bd.GetConnection())
                {
                    conn.Open();

                    // 1. Total Élèves Actifs
                    string queryEleves = "SELECT COUNT(*) FROM Eleves WHERE Actif = 1";
                    using (MySqlCommand cmd = new MySqlCommand(queryEleves, conn))
                    {
                        metrics.TotalEleves = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }

                    // 2. Encaissements du Jour (Paiements aujourd'hui)
                    string queryJour = "SELECT IFNULL(SUM(MontantPaye), 0) FROM Paiements WHERE DATE(DatePaiement) = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(queryJour, conn))
                    {
                        metrics.TotalEncaisseJour = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                    }

                    // 3. Encaissements du Mois en cours
                    string queryMois = "SELECT IFNULL(SUM(MontantPaye), 0) FROM Paiements WHERE MONTH(DatePaiement) = MONTH(CURDATE()) AND YEAR(DatePaiement) = YEAR(CURDATE())";
                    using (MySqlCommand cmd = new MySqlCommand(queryMois, conn))
                    {
                        metrics.TotalEncaisseMois = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                    }

                    // 4. Calcul sommaire du Taux de Recouvrement
                    // (Total Perçu vs Total Attendu selon la configuration des frais)
                    string queryTotalAttendu = @"
                    SELECT IFNULL(SUM(f.Montant), 0) 
                    FROM Eleves e 
                    JOIN ConfigurationFrais f ON (f.ClasseId = e.ClasseId OR f.ClasseId IS NULL)
                    JOIN AnneesScolaires a ON f.AnneeScolaireId = a.Id
                    WHERE e.Actif = 1 AND a.EstActive = 1";

                    string queryTotalPaye = "SELECT IFNULL(SUM(MontantPaye), 0) FROM Paiements";

                    decimal attendu = 0, paye = 0;
                    using (MySqlCommand cmd = new MySqlCommand(queryTotalAttendu, conn))
                    {
                        attendu = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                    }
                    using (MySqlCommand cmd = new MySqlCommand(queryTotalPaye, conn))
                    {
                        paye = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                    }

                    metrics.TauxRecouvrement = attendu > 0 ? Math.Round((paye / attendu) * 100, 1) : 0;
                }

                return metrics;
            }

        /// <summary>
        /// Charge les 10 derniers paiements enregistrés
        /// </summary>
        public DataTable ObtenirDerniersPaiements()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = _bd.GetConnection())
            {
                conn.Open();
                string query = @"
        SELECT 
            p.NumeroRecu AS 'N° Reçu',
            CONCAT(e.Nom, ' ', e.Postnom, ' ', e.Prenom) AS 'Élève',
            c.NomClasse AS 'Classe',
            f.LibelleFrais AS 'Frais',
            p.MontantPaye AS 'Montant',
            p.Devise,
            p.ModePaiement AS 'Mode',
            DATE_FORMAT(p.DatePaiement, '%d/%m/%Y %H:%i') AS 'Date'
        FROM Paiements p
        JOIN Eleves e ON p.EleveId = e.Id
        JOIN Classes c ON e.ClasseId = c.Id
        JOIN ConfigurationFrais f ON p.FraisId = f.Id
        ORDER BY p.DatePaiement DESC
        LIMIT 10;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        /// <summary>
        /// Récupère les totaux d'encaissements regroupés par section
        /// </summary>
        public DataTable ObtenirRecettesParSection()
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = _bd.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        s.NomSection,
                        IFNULL(SUM(p.MontantPaye), 0) AS TotalPerçu
                    FROM Sections s
                    LEFT JOIN Classes c ON s.Id = c.SectionId
                    LEFT JOIN Eleves e ON c.Id = e.ClasseId
                    LEFT JOIN Paiements p ON e.Id = p.EleveId
                    GROUP BY s.Id, s.NomSection;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }

            /// <summary>
            /// Récupère la répartition mensuelle des recettes pour l'année en cours
            /// </summary>
            public DataTable ObtenirEvolutionRecettesMensuelles()
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = _bd.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MONTHNAME(DatePaiement) AS Mois,
                        MONTH(DatePaiement) AS NumMois,
                        SUM(MontantPaye) AS Total
                    FROM Paiements
                    WHERE YEAR(DatePaiement) = YEAR(CURDATE())
                    GROUP BY MONTH(DatePaiement), MONTHNAME(DatePaiement)
                    ORDER BY NumMois;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
        }
    }