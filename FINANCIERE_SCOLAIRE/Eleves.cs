using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class Eleves
    {
        Connexion_db bd = new Connexion_db();
        public string GenererMatriculeAutomatique()
        {
            string anneeEnCours = DateTime.Now.Year.ToString(); // ex: 2026
            string prefixe = $"ELV-{anneeEnCours}-";
            int dernierNumero = 0;

            string query = "SELECT Matricule FROM Eleves WHERE Matricule LIKE @Prefixe ORDER BY Id DESC LIMIT 1;";

            using (MySqlConnection conn = bd.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Prefixe", prefixe + "%");
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string dernierMatricule = result.ToString(); // ex: ELV-2026-0042
                        string partieNumerique = dernierMatricule.Replace(prefixe, "");
                        int.TryParse(partieNumerique, out dernierNumero);
                    }
                }
            }

            return $"{prefixe}{(dernierNumero + 1).ToString("D4")}"; // Résultat : ELV-2026-0001
        }

        public DataTable ObtenirEleveParId(int eleveId)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            e.Id,
            e.Matricule,
            e.Nom,
            e.Postnom,
            e.Prenom,
            e.Sexe,
            e.DateNaissance,
            e.LieuNaissance,
            e.ClasseId,
            c.SectionId,
            c.OptionId,
            e.TypeEleve,
            e.NomTuteur,
            e.TelephoneTuteur,
            e.Adresse,
            e.Actif
        FROM Eleves e
        INNER JOIN Classes c ON e.ClasseId = c.Id
        WHERE e.Id = @Id LIMIT 1;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", eleveId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des détails de l'élève : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public DataTable ObtenirTousLesEleves()
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            e.Id,
            e.Matricule,
            e.Nom,
            e.Postnom,
            e.Prenom,
            e.Sexe,
            e.DateNaissance,
            e.LieuNaissance,
            e.TypeEleve AS 'Catégorie',
            e.ClasseId,
            c.NomClasse AS 'Classe',
            s.NomSection AS 'Section',
            IFNULL(o.NomOption, 'N/A') AS 'Option',
            e.NomTuteur AS 'Tuteur',
            e.TelephoneTuteur AS 'Téléphone Tuteur',
            e.Adresse
        FROM Eleves e
        INNER JOIN Classes c ON e.ClasseId = c.Id
        INNER JOIN Sections s ON c.SectionId = s.Id
        LEFT JOIN Options o ON c.OptionId = o.Id
        WHERE e.Actif = 1
        ORDER BY e.Id DESC;";

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
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des élèves : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ObtenirElevesParClasse(int? classeId = null)
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        e.Id,
        e.Matricule,
        e.Nom,
        e.Postnom,
        e.Prenom,
        e.Sexe,
        e.DateNaissance,
        e.LieuNaissance,
        e.TypeEleve AS 'Catégorie',
        e.ClasseId,
        c.NomClasse AS 'Classe',
        s.NomSection AS 'Section',
        IFNULL(o.NomOption, 'N/A') AS 'Option',
        e.NomTuteur AS 'Tuteur',
        e.TelephoneTuteur AS 'Téléphone Tuteur',
        e.Adresse
    FROM Eleves e
    INNER JOIN Classes c ON e.ClasseId = c.Id
    INNER JOIN Sections s ON c.SectionId = s.Id
    LEFT JOIN Options o ON c.OptionId = o.Id
    WHERE e.Actif = 1 ";

            // Ajout conditionnel du filtre selon la classe choisie
            if (classeId.HasValue && classeId.Value > 0)
            {
                query += " AND e.ClasseId = @ClasseId ";
            }

            query += " ORDER BY e.Nom ASC, e.Prenom ASC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (classeId.HasValue && classeId.Value > 0)
                        {
                            cmd.Parameters.AddWithValue("@ClasseId", classeId.Value);
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
                MessageBox.Show($"Erreur lors du chargement des élèves : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public bool AjouterEleve(string matricule, string nom, string postnom, string prenom, string sexe,
                         DateTime dateNaissance, string lieuNaissance, int classeId, string typeEleve,
                         string nomTuteur, string telTuteur, string adresse)
        {
            string query = @"
        INSERT INTO Eleves 
        (Matricule, Nom, Postnom, Prenom, Sexe, DateNaissance, LieuNaissance, ClasseId, TypeEleve, NomTuteur, TelephoneTuteur, Adresse) 
        VALUES 
        (@Matricule, @Nom, @Postnom, @Prenom, @Sexe, @DateNaissance, @LieuNaissance, @ClasseId, @TypeEleve, @NomTuteur, @TelephoneTuteur, @Adresse);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Matricule", matricule);
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Postnom", postnom);
                        cmd.Parameters.AddWithValue("@Prenom", prenom);
                        cmd.Parameters.AddWithValue("@Sexe", sexe);
                        cmd.Parameters.AddWithValue("@DateNaissance", dateNaissance.ToString("yyyy-MM-dd"));

                        // Gestion des valeurs optionnelles (NULL)
                        cmd.Parameters.AddWithValue("@LieuNaissance", string.IsNullOrWhiteSpace(lieuNaissance) ? DBNull.Value : (object)lieuNaissance);
                        cmd.Parameters.AddWithValue("@ClasseId", classeId);
                        cmd.Parameters.AddWithValue("@TypeEleve", string.IsNullOrWhiteSpace(typeEleve) ? "Régulier" : (object)typeEleve);
                        cmd.Parameters.AddWithValue("@NomTuteur", string.IsNullOrWhiteSpace(nomTuteur) ? DBNull.Value : (object)nomTuteur);
                        cmd.Parameters.AddWithValue("@TelephoneTuteur", string.IsNullOrWhiteSpace(telTuteur) ? DBNull.Value : (object)telTuteur);
                        cmd.Parameters.AddWithValue("@Adresse", string.IsNullOrWhiteSpace(adresse) ? DBNull.Value : (object)adresse);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // 1062 est le code d'erreur MySQL pour les entrées dupliquées (ex: Matricule déjà existant)
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ce matricule existe déjà dans la base de données.",
                                    "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Erreur SQL lors de l'ajout de l'élève : {ex.Message}",
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
     
      
        public bool ModifierEleve(int eleveId, string nom, string postnom, string prenom, string sexe,
                                  DateTime dateNaissance, string lieuNaissance, int classeId, string typeEleve,
                                  string nomTuteur, string telTuteur, string adresse)
        {
            string query = @"
        UPDATE Eleves 
        SET Nom = @Nom,
            Postnom = @Postnom,
            Prenom = @Prenom,
            Sexe = @Sexe,
            DateNaissance = @DateNaissance,
            LieuNaissance = @LieuNaissance,
            ClasseId = @ClasseId,
            TypeEleve = @TypeEleve,
            NomTuteur = @NomTuteur,
            TelephoneTuteur = @TelephoneTuteur,
            Adresse = @Adresse
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", eleveId);
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Postnom", postnom);
                        cmd.Parameters.AddWithValue("@Prenom", prenom);
                        cmd.Parameters.AddWithValue("@Sexe", sexe);
                        cmd.Parameters.AddWithValue("@DateNaissance", dateNaissance.ToString("yyyy-MM-dd"));

                        // Gestion des valeurs optionnelles (NULL)
                        cmd.Parameters.AddWithValue("@LieuNaissance", string.IsNullOrWhiteSpace(lieuNaissance) ? DBNull.Value : (object)lieuNaissance);
                        cmd.Parameters.AddWithValue("@ClasseId", classeId);
                        cmd.Parameters.AddWithValue("@TypeEleve", string.IsNullOrWhiteSpace(typeEleve) ? "Régulier" : (object)typeEleve);
                        cmd.Parameters.AddWithValue("@NomTuteur", string.IsNullOrWhiteSpace(nomTuteur) ? DBNull.Value : (object)nomTuteur);
                        cmd.Parameters.AddWithValue("@TelephoneTuteur", string.IsNullOrWhiteSpace(telTuteur) ? DBNull.Value : (object)telTuteur);
                        cmd.Parameters.AddWithValue("@Adresse", string.IsNullOrWhiteSpace(adresse) ? DBNull.Value : (object)adresse);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de la modification de l'élève : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SupprimerEleve(int eleveId)
        {
            string query = @"
        UPDATE Eleves 
        SET Actif = 0 
        WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", eleveId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de la désactivation de l'élève : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
