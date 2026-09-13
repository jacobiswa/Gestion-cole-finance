using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public class ConfigurationFraisModel
    {
        public int Id { get; set; }
        public string LibelleFrais { get; set; }
        public decimal Montant { get; set; }
        public string Devise { get; set; }
        public string EcheanceMois { get; set; }
        public int AnneeScolaireId { get; set; }
        public int? ClasseId { get; set; }
    }

    public class FraisService
    {
        private Connexion_db bd = new Connexion_db();

        // ---------------------------------------------------------
        // 1. AJOUTER UN NOUVEAU FRAIS
        // ---------------------------------------------------------
        public bool AjouterFrais(ConfigurationFraisModel frais)
        {
            string query = @"
            INSERT INTO ConfigurationFrais (LibelleFrais, Montant, Devise, EchanceMois, AnneeScolaireId, ClasseId)
            VALUES (@Libelle, @Montant, @Devise, @Echeance, @AnneeId, @ClasseId);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", frais.LibelleFrais);
                        cmd.Parameters.AddWithValue("@Montant", frais.Montant);
                        cmd.Parameters.AddWithValue("@Devise", frais.Devise);
                        cmd.Parameters.AddWithValue("@Echeance", string.IsNullOrEmpty(frais.EcheanceMois) ? (object)DBNull.Value : frais.EcheanceMois);
                        cmd.Parameters.AddWithValue("@AnneeId", frais.AnneeScolaireId);
                        cmd.Parameters.AddWithValue("@ClasseId", frais.ClasseId.HasValue ? (object)frais.ClasseId.Value : DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du frais : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------------------------------------------
        // 2. MODIFIER UN FRAIS EXISTANT
        // ---------------------------------------------------------
        public bool ModifierFrais(ConfigurationFraisModel frais)
        {
            string query = @"
            UPDATE ConfigurationFrais 
            SET LibelleFrais = @Libelle, 
                Montant = @Montant, 
                Devise = @Devise, 
                EchanceMois = @Echeance, 
                AnneeScolaireId = @AnneeId, 
                ClasseId = @ClasseId
            WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", frais.Id);
                        cmd.Parameters.AddWithValue("@Libelle", frais.LibelleFrais);
                        cmd.Parameters.AddWithValue("@Montant", frais.Montant);
                        cmd.Parameters.AddWithValue("@Devise", frais.Devise);
                        cmd.Parameters.AddWithValue("@Echeance", string.IsNullOrEmpty(frais.EcheanceMois) ? (object)DBNull.Value : frais.EcheanceMois);
                        cmd.Parameters.AddWithValue("@AnneeId", frais.AnneeScolaireId);
                        cmd.Parameters.AddWithValue("@ClasseId", frais.ClasseId.HasValue ? (object)frais.ClasseId.Value : DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du frais : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------------------------------------------
        // 3. SUPPRIMER UN FRAIS
        // ---------------------------------------------------------
        public bool SupprimerFrais(int idFrais)
        {
            string query = "DELETE FROM ConfigurationFrais WHERE Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idFrais);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------------------------------------------
        // 4. CHARGER LES FRAIS CONFIGURÉS
        // ---------------------------------------------------------
        public DataTable ObtenirFraisConfigures(int? anneeScolaireId = null)
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT 
                f.Id,
                f.LibelleFrais AS 'Type de Frais',
                f.Montant,
                f.Devise,
                IFNULL(f.EchanceMois, 'N/A') AS 'Échéance / Mois',
                a.Libelle AS 'Année Scolaire',
                IFNULL(c.NomClasse, 'Toute l\'École') AS 'Application / Classe',
                f.AnneeScolaireId,
                f.ClasseId
            FROM ConfigurationFrais f
            INNER JOIN AnneesScolaires a ON f.AnneeScolaireId = a.Id
            LEFT JOIN Classes c ON f.ClasseId = c.Id";

            if (anneeScolaireId.HasValue && anneeScolaireId.Value > 0)
            {
                query += " WHERE f.AnneeScolaireId = @AnneeId";
            }

            query += " ORDER BY f.Id DESC;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (anneeScolaireId.HasValue && anneeScolaireId.Value > 0)
                        {
                            cmd.Parameters.AddWithValue("@AnneeId", anneeScolaireId.Value);
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
                MessageBox.Show($"Erreur lors de la récupération des frais : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
    }
}