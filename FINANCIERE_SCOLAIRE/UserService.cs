using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class UserService
    {
        private readonly Connexion_db bd = new Connexion_db();

        // ---------------------------------------------------------
        // CHIFFREMENT DE MOT DE PASSE (CryptoHelper AES)
        // ---------------------------------------------------------
        public static string HacherMotDePasse(string rawData)
        {
            // Utilisation du chiffrement AES via CryptoHelper
            return CryptoHelper.Encrypt(rawData);
        }

        // ---------------------------------------------------------
        // LOGGING & AUDIT TRAIL
        // ---------------------------------------------------------
        public void EnregistrerLog(string action, string details)
        {
            int? currentUserId = SessionUtilisateur.UtilisateurConnecte?.Id;
            string query = @"INSERT INTO LogsAudit (UtilisateurId, Action, Details, DateAction) 
                            VALUES (@UtilisateurId, @Action, @Details, NOW());";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UtilisateurId", (object)currentUserId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@Details", details);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ne pas bloquer l'application si le log échoue
                Console.WriteLine("Erreur d'écriture du Log Audit: " + ex.Message);
            }
        }

        // ---------------------------------------------------------
        // AUTHENTIFICATION
        // ---------------------------------------------------------
        public Utilisateur Authentifier(string nomUtilisateur, string motDePasse)
        {
            string hash = HacherMotDePasse(motDePasse);
            string query = "SELECT * FROM Utilisateurs WHERE NomUtilisateur = @NomUtilisateur AND MotDePasseHash = @Hash LIMIT 1;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomUtilisateur", nomUtilisateur);
                    cmd.Parameters.AddWithValue("@Hash", hash);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Utilisateur user = new Utilisateur
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NomUtilisateur = reader["NomUtilisateur"].ToString(),
                                Role = reader["Role"].ToString(),
                                NomComplet = reader["NomComplet"].ToString()
                            };

                            SessionUtilisateur.OuvrirSession(user);
                            EnregistrerLog("CONNEXION", $"Connexion réussie de {user.NomUtilisateur} ({user.Role})");
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        // ---------------------------------------------------------
        // CRUD UTILISATEURS
        // ---------------------------------------------------------
        public List<Utilisateur> ObtenirTousLesUtilisateurs()
        {
            List<Utilisateur> liste = new List<Utilisateur>();
            string query = "SELECT Id, NomUtilisateur, Role, NomComplet FROM Utilisateurs ORDER BY NomComplet;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Utilisateur
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NomUtilisateur = reader["NomUtilisateur"].ToString(),
                            Role = reader["Role"].ToString(),
                            NomComplet = reader["NomComplet"].ToString()
                        });
                    }
                }
            }
            return liste;
        }

        public bool AjouterUtilisateur(Utilisateur u, string motDePasseClair)
        {
            string hash = HacherMotDePasse(motDePasseClair);
            string query = @"INSERT INTO Utilisateurs (NomUtilisateur, MotDePasseHash, Role, NomComplet) 
                            VALUES (@NomUtilisateur, @MotDePasseHash, @Role, @NomComplet);";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomUtilisateur", u.NomUtilisateur);
                    cmd.Parameters.AddWithValue("@MotDePasseHash", hash);
                    cmd.Parameters.AddWithValue("@Role", u.Role);
                    cmd.Parameters.AddWithValue("@NomComplet", u.NomComplet);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        EnregistrerLog("CRÉATION UTILISATEUR", $"Compte créé pour : {u.NomUtilisateur} avec rôle {u.Role}");
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ModifierUtilisateur(Utilisateur u)
        {
            string query = @"UPDATE Utilisateurs SET NomUtilisateur = @NomUtilisateur, Role = @Role, NomComplet = @NomComplet 
                            WHERE Id = @Id;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", u.Id);
                    cmd.Parameters.AddWithValue("@NomUtilisateur", u.NomUtilisateur);
                    cmd.Parameters.AddWithValue("@Role", u.Role);
                    cmd.Parameters.AddWithValue("@NomComplet", u.NomComplet);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        EnregistrerLog("MODIFICATION UTILISATEUR", $"Mise à jour du compte #{u.Id} ({u.NomUtilisateur})");
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ReinitialiserMotDePasse(int userId, string nouveauMotDePasse)
        {
            string hash = HacherMotDePasse(nouveauMotDePasse);
            string query = "UPDATE Utilisateurs SET MotDePasseHash = @Hash WHERE Id = @Id;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Hash", hash);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        EnregistrerLog("RÉINITIALISATION MDP", $"Changement de mot de passe pour l'utilisateur ID: {userId}");
                        return true;
                    }
                }
            }
            return false;
        }

        public bool SupprimerUtilisateur(int userId)
        {
            string query = "DELETE FROM Utilisateurs WHERE Id = @Id;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        EnregistrerLog("SUPPRESSION UTILISATEUR", $"Suppression de l'utilisateur ID: {userId}");
                        return true;
                    }
                }
            }
            return false;
        }

        // ---------------------------------------------------------
        // CONSULTATION DES LOGS D'AUDIT
        // ---------------------------------------------------------
        public List<LogAudit> ObtenirLogsAudit(DateTime dateDebut, DateTime dateFin, string motCle = "")
        {
            List<LogAudit> liste = new List<LogAudit>();
            string query = @"
            SELECT 
                l.Id,
                l.UtilisateurId,
                IFNULL(u.NomUtilisateur, 'Système/Supprimé') AS NomUtilisateur,
                l.Action,
                l.Details,
                l.DateAction
            FROM LogsAudit l
            LEFT JOIN Utilisateurs u ON l.UtilisateurId = u.Id
            WHERE DATE(l.DateAction) BETWEEN @DateDebut AND @DateFin
              AND (@MotCle = '' OR l.Action LIKE @MotCleLike OR l.Details LIKE @MotCleLike OR u.NomUtilisateur LIKE @MotCleLike)
            ORDER BY l.DateAction DESC;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DateDebut", dateDebut.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateFin", dateFin.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@MotCle", motCle);
                    cmd.Parameters.AddWithValue("@MotCleLike", "%" + motCle + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new LogAudit
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UtilisateurId = reader["UtilisateurId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UtilisateurId"]),
                                NomUtilisateur = reader["NomUtilisateur"].ToString(),
                                Action = reader["Action"].ToString(),
                                Details = reader["Details"].ToString(),
                                DateAction = Convert.ToDateTime(reader["DateAction"])
                            });
                        }
                    }
                }
            }
            return liste;
        }
    }
}