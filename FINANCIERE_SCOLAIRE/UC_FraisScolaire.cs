using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public partial class UC_FraisScolaire : UserControl
    {
        private FraisService fraisService = new FraisService();
        private Connexion_db bd = new Connexion_db();
        private int selectedFraisId = 0;
        public UC_FraisScolaire()
        {
            InitializeComponent();
        }

        private void UC_FraisScolaire_Load(object sender, EventArgs e)
        {
            ChargerAnneesScolaires();
            ChargerClasses();
            ChargerDevises();
            ChargerEcheances();
            RafraichirGrille();
        }
        private void ChargerAnneesScolaires()
        {
            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    string query = "SELECT Id, Libelle FROM AnneesScolaires ORDER BY Id DESC;";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbAnneeScolaire.DataSource = dt;
                        cmbAnneeScolaire.DisplayMember = "Libelle";
                        cmbAnneeScolaire.ValueMember = "Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement années scolaires : {ex.Message}");
            }
        }

        private void ChargerClasses()
        {
            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    string query = "SELECT Id, NomClasse FROM Classes ORDER BY NomClasse ASC;";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Ajouter l'option "Toute l'école" (NULL)
                        DataRow row = dt.NewRow();
                        row["Id"] = DBNull.Value;
                        row["NomClasse"] = "-- Toute l'École (Global) --";
                        dt.Rows.InsertAt(row, 0);

                        cmbClasse.DataSource = dt;
                        cmbClasse.DisplayMember = "NomClasse";
                        cmbClasse.ValueMember = "Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement classes : {ex.Message}");
            }
        }

        private void ChargerDevises()
        {
            cmbDevise.Items.Clear();
            cmbDevise.Items.Add("USD");
            cmbDevise.Items.Add("CDF");
            cmbDevise.SelectedIndex = 0;
        }

        private void ChargerEcheances()
        {
            cmbEcheance.Items.Clear();
            cmbEcheance.Items.Add("Inscription");
            cmbEcheance.Items.Add("Acompte 1");
            cmbEcheance.Items.Add("Acompte 2");
            cmbEcheance.Items.Add("Septembre");
            cmbEcheance.Items.Add("Octobre");
            cmbEcheance.Items.Add("Novembre");
            cmbEcheance.Items.Add("Décembre");
            cmbEcheance.Items.Add("Janvier");
            cmbEcheance.Items.Add("Février");
            cmbEcheance.Items.Add("Mars");
            cmbEcheance.Items.Add("Avril");
            cmbEcheance.Items.Add("Mai");
            cmbEcheance.Items.Add("Juin");
            cmbEcheance.Items.Add("Frais Annuel");
            cmbEcheance.SelectedIndex = 0;
        }

        private void ViderChamps()
        {
            selectedFraisId = 0;
            txtLibelleFrais.Clear();
            txtMontant.Clear();
            if (cmbDevise.Items.Count > 0) cmbDevise.SelectedIndex = 0;
            if (cmbEcheance.Items.Count > 0) cmbEcheance.SelectedIndex = 0;
            if (cmbClasse.Items.Count > 0) cmbClasse.SelectedIndex = 0;
            btnEnregistrer.Text = "Enregistrer";
        }
        private void RafraichirGrille()
        {
            int? anneeFilter = null;
            if (cmbAnneeScolaire.SelectedValue != null && int.TryParse(cmbAnneeScolaire.SelectedValue.ToString(), out int idAnnee))
            {
                anneeFilter = idAnnee;
            }

            dgvFrais.DataSource = fraisService.ObtenirFraisConfigures(anneeFilter);

            // Masquer les colonnes système d'IDs
            if (dgvFrais.Columns["AnneeScolaireId"] != null) dgvFrais.Columns["AnneeScolaireId"].Visible = false;
            if (dgvFrais.Columns["ClasseId"] != null) dgvFrais.Columns["ClasseId"].Visible = false;
        }

        private void btnEnregistreFrais_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelleFrais.Text))
            {
                MessageBox.Show("Veuillez saisir le libellé du frais.", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMontant.Text, out decimal montant) || montant <= 0)
            {
                MessageBox.Show("Veuillez saisir un montant valide supérieur à 0.", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? classeId = null;
            if (cmbClasse.SelectedValue != null && int.TryParse(cmbClasse.SelectedValue.ToString(), out int cId) && cId > 0)
            {
                classeId = cId;
            }

            ConfigurationFraisModel frais = new ConfigurationFraisModel
            {
                Id = selectedFraisId,
                LibelleFrais = txtLibelleFrais.Text.Trim(),
                Montant = montant,
                Devise = cmbDevise.SelectedItem.ToString(),
                EcheanceMois = cmbEcheance.SelectedItem != null ? cmbEcheance.SelectedItem.ToString() : null,
                AnneeScolaireId = Convert.ToInt32(cmbAnneeScolaire.SelectedValue),
                ClasseId = classeId
            };

            bool succes = false;
            if (selectedFraisId == 0)
            {
                succes = fraisService.AjouterFrais(frais);
                if (succes) MessageBox.Show("Nouveau frais configuré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
            else
            {
                succes = fraisService.ModifierFrais(frais);
                if (succes) MessageBox.Show("Configuration du frais mise à jour !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

            if (succes)
            {
                ViderChamps();
                RafraichirGrille();
                
            }
        }

        private void btnSuprimmer_Click(object sender, EventArgs e)
        {
            if (selectedFraisId == 0)
            {
                MessageBox.Show("Veuillez sélectionner un frais à supprimer dans le tableau.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette configuration de frais ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (fraisService.SupprimerFrais(selectedFraisId))
                {
                    MessageBox.Show("Frais supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViderChamps();
                    RafraichirGrille();
                }
            }
        }

        private void dgvFrais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFrais.Rows[e.RowIndex];
                selectedFraisId = Convert.ToInt32(row.Cells["Id"].Value);
                txtLibelleFrais.Text = row.Cells["Type de Frais"].Value.ToString();
                txtMontant.Text = row.Cells["Montant"].Value.ToString();
                cmbDevise.SelectedItem = row.Cells["Devise"].Value.ToString();
                cmbEcheance.SelectedItem = row.Cells["Échéance / Mois"].Value.ToString();

                if (row.Cells["AnneeScolaireId"].Value != DBNull.Value)
                    cmbAnneeScolaire.SelectedValue = Convert.ToInt32(row.Cells["AnneeScolaireId"].Value);

                if (row.Cells["ClasseId"].Value != DBNull.Value)
                    cmbClasse.SelectedValue = Convert.ToInt32(row.Cells["ClasseId"].Value);
                else
                    cmbClasse.SelectedIndex = 0; // "-- Toute l'École --"

                btnEnregistrer.Text = "Modifier";
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderChamps();
     
        }

        private void cmbAnneeScolaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            RafraichirGrille();
        }

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // 1. Autoriser la touche Retour arrière (Backspace) et la touche Suppr
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // 2. Autoriser uniquement les chiffres
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // 3. Autoriser une seule virgule ou un seul point décimal
            char decimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if ((e.KeyChar == ',' || e.KeyChar == '.') && !txt.Text.Contains(",") && !txt.Text.Contains("."))
            {
                // Remplacer automatiquement le point par la virgule (ou vice-versa selon la culture du système)
                e.KeyChar = decimalSeparator;
                return;
            }

            // Bloquer toutes les autres touches (lettres, symboles, espaces)
            e.Handled = true;
        }
    









    }
}
