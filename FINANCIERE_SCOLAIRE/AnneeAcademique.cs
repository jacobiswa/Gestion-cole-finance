using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    
    public class AnneeAcademique
    {
        Connexion_db bd = new Connexion_db();

        public bool CloturerAnneeScolaire(int anneeId)
        {
            string query = @"
        UPDATE AnneesScolaires 
        SET EstCloturee = 1, EstActive = 0 
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", anneeId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de la clôture de l'année : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool EstAnneeCloturee(int anneeScolaireId)
        {
            string query = "SELECT EstCloturee FROM AnneesScolaires WHERE Id = @Id;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", anneeScolaireId);
                    object res = cmd.ExecuteScalar();
                    return res != null && Convert.ToBoolean(res);
                }
            }
        }

        public bool RestaurerAnneeScolaire(int anneeId)
        {
            string query = @"
        UPDATE AnneesScolaires 
        SET EstCloturee = 0 
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", anneeId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de la restauration de l'année : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable ObtenirToutesLesAnneesScolaires()
        {
            DataTable dt = new DataTable();

            // Requête SQL avec alias pour un affichage propre dans le DataGridView
            string query = @"
        SELECT 
            Id AS 'ID',
            Libelle AS 'Année Scolaire',
            CASE 
                WHEN EstActive = 1 THEN 'Active'
                ELSE 'Inactive'
            END AS 'Statut'
        FROM AnneesScolaires
        ORDER BY Id DESC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors du chargement des années scolaires : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenirToutesLesSections()
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            Id AS 'ID',
            NomSection AS 'Nom de la Section'
        FROM Sections
        ORDER BY Id ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors du chargement des sections : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenirToutesLesOptions()
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            o.Id AS 'ID',
            o.NomOption AS 'Option / Filière',
            s.NomSection AS 'Section'
        FROM Options o
        INNER JOIN Sections s ON o.SectionId = s.Id
        ORDER BY o.Id ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors du chargement des options : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenirToutesLesClasses()
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            c.Id AS 'ID',
            c.NomClasse AS 'Nom de la Classe',
            c.SectionId,                          -- <--- Colonne ajoutée
            s.NomSection AS 'Section',
            c.OptionId,                           -- <--- Colonne ajoutée
            IFNULL(o.NomOption, 'Aucune') AS 'Option'
        FROM Classes c
        INNER JOIN Sections s ON c.SectionId = s.Id
        LEFT JOIN Options o ON c.OptionId = o.Id
        ORDER BY c.SectionId ASC, c.Id ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors du chargement des classes : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenirClassesParSectionEtOption(int sectionId, int? optionId)
{
    DataTable dt = new DataTable();

    // Requête conditionnelle selon que l'optionId est précisé ou non
    string query = @"
        SELECT 
            c.Id,
            c.NomClasse,
            c.SectionId,
            c.OptionId,
            IFNULL(o.NomOption, 'Sans option') AS NomOption
        FROM Classes c
        LEFT JOIN Options o ON c.OptionId = o.Id
        WHERE c.SectionId = @SectionId ";

    // Si une option est sélectionnée (ex: Secondaire), on filtre aussi par OptionId
    if (optionId.HasValue && optionId.Value > 0)
    {
        query += " AND c.OptionId = @OptionId";
    }
    else
    {
        // Pour Maternelle / Primaire ou classes du Secondaire sans option (7è / 8è EB)
        query += " AND (c.OptionId IS NULL OR c.OptionId = 0)";
    }

    query += " ORDER BY c.NomClasse ASC;";

    try
    {
        using (MySqlConnection conn = bd.GetConnection())
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SectionId", sectionId);

                if (optionId.HasValue && optionId.Value > 0)
                {
                    cmd.Parameters.AddWithValue("@OptionId", optionId.Value);
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur lors du chargement des classes : {ex.Message}", 
                        "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    return dt;
}
        public DataTable ObtenirOptionsParSection(int sectionId)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            o.Id AS 'ID',
            o.NomOption AS 'Option / Filière',
            s.NomSection AS 'Section'
        FROM Options o
        INNER JOIN Sections s ON o.SectionId = s.Id
        WHERE o.SectionId = @SectionId
        ORDER BY o.Id ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de la récupération des options : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public DataTable ObtenirClassesParSection(int sectionId)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            c.Id AS 'ID',
            c.NomClasse AS 'Nom de la Classe',
            IFNULL(o.NomOption, 'Tronc Commun') AS 'Option'
        FROM Classes c
        LEFT JOIN Options o ON c.OptionId = o.Id
        WHERE c.SectionId = @SectionId
        ORDER BY c.Id ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenirClassesFiltrees(int? sectionId, int? optionId)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            c.Id AS 'ID',
            c.NomClasse AS 'Nom de la Classe',
            s.NomSection AS 'Section',
            IFNULL(o.NomOption, 'Aucune') AS 'Option'
        FROM Classes c
        INNER JOIN Sections s ON c.SectionId = s.Id
        LEFT JOIN Options o ON c.OptionId = o.Id
        WHERE (@SectionId IS NULL OR c.SectionId = @SectionId)
          AND (@OptionId IS NULL OR c.OptionId = @OptionId)
        ORDER BY c.SectionId ASC, c.Id ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SectionId", (object)sectionId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@OptionId", (object)optionId ?? DBNull.Value);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors du filtrage des classes : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public bool ExisteAnneeScolaire(string libelle)
        {
            string query = "SELECT COUNT(*) FROM AnneesScolaires WHERE Libelle = @Libelle;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", libelle.Trim());
                        long count = Convert.ToInt64(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de vérification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Par sécurité, on renvoie true en cas d'erreur pour ne pas insérer
            }
        }
        public bool ExisteClasse(string nomClasse, int sectionId, int? optionId)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Classes 
        WHERE LOWER(NomClasse) = LOWER(@NomClasse) 
          AND SectionId = @SectionId
          AND (OptionId = @OptionId OR (OptionId IS NULL AND @OptionId IS NULL));";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomClasse", nomClasse.Trim());
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);
                        cmd.Parameters.AddWithValue("@OptionId", (object)optionId ?? DBNull.Value);

                        long count = Convert.ToInt64(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de vérification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
        public bool ExisteSection(string nomSection)
        {
            string query = "SELECT COUNT(*) FROM Sections WHERE LOWER(NomSection) = LOWER(@NomSection);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomSection", nomSection.Trim());
                        long count = Convert.ToInt64(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de vérification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Retourne true par sécurité en cas de problème d'accès
            }
        }
        public bool ExisteOption(string nomOption, int sectionId)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Options 
        WHERE LOWER(NomOption) = LOWER(@NomOption) 
          AND SectionId = @SectionId;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomOption", nomOption.Trim());
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);

                        long count = Convert.ToInt64(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de vérification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        public bool InsererAnneeScolaire(string libelle, bool estActive)
        {
            string queryDesactiverTout = "UPDATE AnneesScolaires SET EstActive = 0;";
            string queryInsert = @"
        INSERT INTO AnneesScolaires (Libelle, EstActive) 
        VALUES (@Libelle, @EstActive);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Si la nouvelle année doit être active, on désactive les autres au préalable
                            if (estActive)
                            {
                                using (MySqlCommand cmdDesactiver = new MySqlCommand(queryDesactiverTout, conn, transaction))
                                {
                                    cmdDesactiver.ExecuteNonQuery();
                                }
                            }

                            // Insertion de la nouvelle année
                            using (MySqlCommand cmd = new MySqlCommand(queryInsert, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Libelle", libelle.Trim());
                                cmd.Parameters.AddWithValue("@EstActive", estActive ? 1 : 0);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Code d'erreur MySQL pour doublon (UNIQUE)
                {
                    MessageBox.Show($"L'année scolaire '{libelle}' existe déjà.",
                                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de l'ajout de l'année scolaire : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
 
        public bool InsererSection(string nomSection)
        {
            string query = "INSERT INTO Sections (NomSection) VALUES (@NomSection);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomSection", nomSection.Trim());
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Contrainte d'unicité sur NomSection
                {
                    MessageBox.Show($"La section '{nomSection}' existe déjà.",
                                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de l'ajout de la section : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool InsererOption(string nomOption, int sectionId)
        {
            string query = @"
        INSERT INTO Options (NomOption, SectionId) 
        VALUES (@NomOption, @SectionId);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomOption", nomOption.Trim());
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de l'ajout de l'option : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool InsererClasse(string nomClasse, int sectionId, int? optionId)
        {
            string query = @"
        INSERT INTO Classes (NomClasse, SectionId, OptionId) 
        VALUES (@NomClasse, @SectionId, @OptionId);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomClasse", nomClasse.Trim());
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);

                        // Gestion explicite des valeurs NULL pour OptionId si optionId est null ou 0
                        if (optionId.HasValue && optionId.Value > 0)
                        {
                            cmd.Parameters.AddWithValue("@OptionId", optionId.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@OptionId", DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de l'ajout de la classe : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public bool ModifierAnneeScolaire(int id, string libelle, bool estActive)
        {
            string queryDesactiverTout = "UPDATE AnneesScolaires SET EstActive = 0;";
            string queryUpdate = @"
        UPDATE AnneesScolaires 
        SET Libelle = @Libelle, EstActive = @EstActive 
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Si on active cette année, on désactive les autres au préalable
                            if (estActive)
                            {
                                using (MySqlCommand cmdDesactiver = new MySqlCommand(queryDesactiverTout, conn, transaction))
                                {
                                    cmdDesactiver.ExecuteNonQuery();
                                }
                            }

                            using (MySqlCommand cmd = new MySqlCommand(queryUpdate, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Libelle", libelle.Trim());
                                cmd.Parameters.AddWithValue("@EstActive", estActive ? 1 : 0);
                                cmd.Parameters.AddWithValue("@Id", id);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show($"L'année scolaire '{libelle}' existe déjà.", "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la modification : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public bool ModifierSection(int sectionId, string nouveauNom)
        {
            string query = "UPDATE Sections SET NomSection = @NomSection WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomSection", nouveauNom.Trim());
                        cmd.Parameters.AddWithValue("@Id", sectionId);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Violation de la contrainte UNIQUE sur NomSection
                {
                    MessageBox.Show($"La section '{nouveauNom}' existe déjà.",
                                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la modification : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool ModifierOption(int optionId, string nomOption, int sectionId)
        {
            string query = @"
        UPDATE Options 
        SET NomOption = @NomOption, SectionId = @SectionId 
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomOption", nomOption.Trim());
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);
                        cmd.Parameters.AddWithValue("@Id", optionId);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Violation de contrainte d'unicité (Option unique par section)
                {
                    MessageBox.Show($"L'option '{nomOption}' existe déjà pour cette section.",
                                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la modification : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ModifierClasse(int classeId, string nomClasse, int sectionId, int? optionId)
        {
            string query = @"
        UPDATE Classes 
        SET NomClasse = @NomClasse, SectionId = @SectionId, OptionId = @OptionId 
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomClasse", nomClasse.Trim());
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);
                        cmd.Parameters.AddWithValue("@Id", classeId);

                        if (optionId.HasValue && optionId.Value > 0)
                            cmd.Parameters.AddWithValue("@OptionId", optionId.Value);
                        else
                            cmd.Parameters.AddWithValue("@OptionId", DBNull.Value);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de la modification de la classe : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SupprimerClasse(int classeId)
        {
            string query = "DELETE FROM Classes WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", classeId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) // Violation de clé étrangère (ex: élèves/inscriptions liés)
                {
                    MessageBox.Show("Impossible de supprimer cette classe car des élèves y sont déjà inscrits.",
                                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la suppression : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SupprimerAnneeScolaire(int id)
        {
            string query = "DELETE FROM AnneesScolaires WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // 1451 est le code d'erreur MySQL pour contrainte de clé étrangère (si liée à des inscriptions/frais)
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Impossible de supprimer cette année scolaire car des données y sont déjà liées.",
                                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la suppression : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SupprimerOption(int optionId)
        {
            string query = "DELETE FROM Options WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", optionId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) // Clé étrangère empêchant la suppression (ex: classes liées à cette option)
                {
                    MessageBox.Show("Impossible de supprimer cette option car des classes y sont directement liées.",
                                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la suppression : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SupprimerSection(int sectionId)
        {
            string query = "DELETE FROM Sections WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", sectionId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) // Clé étrangère empêchant la suppression (ex: options ou classes liées)
                {
                    MessageBox.Show("Impossible de supprimer cette section car des options ou classes y sont rattachées.",
                                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de la suppression : {ex.Message}",
                                    "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
