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
    public partial class UC_StructureScolaire : UserControl
    {
        public UC_StructureScolaire()
        {
            InitializeComponent();
        }

        AnneeAcademique ac = new AnneeAcademique();
        private void UC_StructureScolaire_Load(object sender, EventArgs e)
        {
            AuDemmarage();
        }
        private void AuDemmarage()
        {
            ChargerInCombo();
            ChargerInDgv();
        }
        private void ChargerInCombo()
        {
            ChargerSectionsDansComboBox();
            ChargerOptionsDansComboBox();
        }

        private void ChargerInDgv()
        {
            // Affectation des données au DataGridView
            dgvAnnees.DataSource = ac.ObtenirToutesLesAnneesScolaires();
            dgvSections.DataSource = ac.ObtenirToutesLesSections();
            dgvOptions.DataSource = ac.ObtenirToutesLesOptions();
            dgvClasses.DataSource = ac.ObtenirToutesLesClasses();

            // Optionnel : Réglages d'affichage du DataGridView
            if (dgvAnnees.Columns["ID"] != null)
            {
                dgvAnnees.Columns["ID"].Visible = false; // Masquer la colonne ID si besoin
            }
            if (dgvSections.Columns["ID"] != null)
            {
                dgvSections.Columns["ID"].Visible = false; // Masquer la colonne ID si besoin
            }
            if (dgvOptions.Columns["ID"] != null)
            {
                dgvOptions.Columns["ID"].Visible = false; // Masquer la colonne ID si besoin
            }
            if (dgvClasses.Columns["ID"] != null)
            {
                dgvClasses.Columns["ID"].Visible = false; // Masquer la colonne ID si besoin
            }
            if (dgvClasses.Columns["SectionId"] != null)
                dgvClasses.Columns["SectionId"].Visible = false;

            if (dgvClasses.Columns["OptionId"] != null)
                dgvClasses.Columns["OptionId"].Visible = false;

            dgvAnnees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public void ChargerSectionsDansComboBox()
        {
            DataTable dt = ac.ObtenirToutesLesSections();

            if (dt != null)
            {
                // Créer et insérer la ligne "-- Toutes les sections --" à l'index 0
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["Nom de la Section"] = "-- Toutes les sections --";
                dt.Rows.InsertAt(dr, 0);

                cmbSections.DataSource = dt;
                cmbSections.DisplayMember = "Nom de la Section";
                cmbSections.ValueMember = "ID";
                cmbSections.SelectedIndex = 0; // Sélectionner l'élément "-- Toutes --" par défaut
            }
        }

        public void ChargerOptionsDansComboBox()
        {
            DataTable dt = ac.ObtenirToutesLesOptions();

            if (dt != null)
            {
                // Créer et insérer la ligne "-- Toutes les options --" à l'index 0
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["Option / Filière"] = "-- Toutes les options --";
                dt.Rows.InsertAt(dr, 0);

                cmbOptions.DataSource = dt;
                cmbOptions.DisplayMember = "Option / Filière";
                cmbOptions.ValueMember = "ID";
                cmbOptions.SelectedIndex = 0; // Sélectionner l'élément "-- Toutes --" par défaut
            }
        }

        private void FiltrerClasses()
        {
            int? sectionId = null;
            int? optionId = null;

            // Récupérer la section si elle est sélectionnée et différente de 0
            if (cmbSections.SelectedValue != null && int.TryParse(cmbSections.SelectedValue.ToString(), out int sId))
            {
                if (sId > 0) // Si sId == 0, sectionId reste null (tout afficher)
                    sectionId = sId;
            }

            // Récupérer l'option si elle est sélectionnée et différente de 0
            if (cmbOptions.SelectedValue != null && int.TryParse(cmbOptions.SelectedValue.ToString(), out int oId))
            {
                if (oId > 0) // Si oId == 0, optionId reste null (tout afficher)
                    optionId = oId;
            }

            // Mettre à jour le DataGridView avec les classes filtrées
            dgvClasses.DataSource = ac.ObtenirClassesFiltrees(sectionId, optionId);

            if (dgvClasses.Columns["ID"] != null)
                dgvClasses.Columns["ID"].Visible = false;
        }

        private void checkBoxClotureAnner_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClotureAnner.Checked)
            {
                btnCloturerAnnee.Enabled = true;
            }
            else
            {
                btnCloturerAnnee.Enabled = false;
            }
        }

        private void btnCloturerAnnee_Click(object sender, EventArgs e)
        {
            // Vérification qu'une année est bien sélectionnée
            if (selectedAnneeId <= 0)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une année scolaire dans la liste.",
                                "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupération du libellé affiché dans le MaskedTextBox
            string libelleAnnee = maskedTextBox1.Text;

            // Ouverture du popup en lui passant les paramètres
            Popup_CloturerAnnee cloturerAnnee = new Popup_CloturerAnnee();
            cloturerAnnee.AnneeId = selectedAnneeId;
            cloturerAnnee.LibelleAnnee = libelleAnnee;

            if (cloturerAnnee.ShowDialog() == DialogResult.OK)
            {
                // Recharger la liste après la clôture
                AuDemmarage();
            }
        }

        private void btnAjouterSection_Click(object sender, EventArgs e)
        {
            Popup_Section ps = new Popup_Section();
            ps.ShowDialog();
            AuDemmarage();
        }

        private void btnAjouterClasse_Click(object sender, EventArgs e)
        {
            Popup_Classe cl = new Popup_Classe();
            cl.ShowDialog();
            AuDemmarage();
        }
        private void Clicker_Bouton_Menu(Button btn)
        {
            foreach (Control c in tableLayoutPanelBouton.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.FromArgb(65, 105, 225);
                    btn.ForeColor = Color.Silver;
                }
            }
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(22, 52, 141);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControlAnneAcademique.SelectedTab = tabPageClasse;
            Clicker_Bouton_Menu(btnAfficheClass);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControlAnneAcademique.SelectedTab = tabPageSectionsOptions;
            Clicker_Bouton_Menu(btnAfficheSection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlAnneAcademique.SelectedTab = tabPageAnneeScolaire;
            Clicker_Bouton_Menu(btnAfficheAnnee);
        }

        private void dgvSections_Click(object sender, EventArgs e)
        {
            if (dgvSections.CurrentRow != null && dgvSections.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvSections.CurrentRow;

                if (row.Cells["ID"].Value != null && int.TryParse(row.Cells["ID"].Value.ToString(), out int sectionId))
                {
                    dgvOptions.DataSource = ac.ObtenirOptionsParSection(sectionId);

                    if (dgvOptions.Columns["ID"] != null)
                        dgvOptions.Columns["ID"].Visible = false;
                }
            }
        }

        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filtrer le DGV dès que la section change
            FiltrerClasses();
        }

        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filtrer le DGV dès que l'option change
            FiltrerClasses();
        }

        private void btnAjouterAnnee_Click(object sender, EventArgs e)
        {
            string libelleAnnee = maskedTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(libelleAnnee))
            {
                MessageBox.Show("Veuillez entrer une année scolaire valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (libelleAnnee.Length != 9 || !libelleAnnee.Contains("-"))
            {
                MessageBox.Show("Veuillez entrer une année scolaire au format correct (ex: 2023-2024).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifier si l'année existe déjà en BDD
            if (ac.ExisteAnneeScolaire(libelleAnnee))
            {
                MessageBox.Show($"L'année scolaire '{libelleAnnee}' existe déjà dans le système.", "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Effectuer l'insertion si la vérification est passée
            if (ac.InsererAnneeScolaire(libelleAnnee, checkBoxAnneEstActive.Checked))
            {
                MessageBox.Show("Année scolaire ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTextBox1.Clear();
                AuDemmarage();
                btnModifierAnnee.Visible = false;
                btnSupprimerAnnee.Visible = false;

                // Optionnel : Recharger ton DGV ou ComboBox des années scolaires ici
            }
        }

        private void dgvAnnees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAnnees.Rows[e.RowIndex];

                if (row.Cells["ID"].Value != null && int.TryParse(row.Cells["ID"].Value.ToString(), out selectedAnneeId))
                {
                    // Charger le libellé dans le maskedTextBox
                    maskedTextBox1.Text = row.Cells["Année Scolaire"].Value.ToString();

                    // Vérification textuelle de la colonne Statut
                    if (row.Cells["Statut"].Value != null)
                    {
                        string statut = row.Cells["Statut"].Value.ToString();
                        checkBoxAnneEstActive.Checked = (statut == "Active");
                    }

                    btnSupprimerAnnee.Visible = true;
                    btnModifierAnnee.Visible = true;
                    AuDemmarage();
                }
            }
        }



        private int selectedAnneeId = 0; // Stocke l'ID sélectionné
        private void btnModifierAnnee_Click(object sender, EventArgs e)
        {
            if (selectedAnneeId == 0)
            {
                MessageBox.Show("Veuillez d'abord double-cliquer sur une année dans la liste à modifier.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string libelleAnnee = maskedTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(libelleAnnee) || libelleAnnee.Length != 9 || !libelleAnnee.Contains("-"))
            {
                MessageBox.Show("Veuillez entrer une année scolaire au format correct (ex: 2023-2024).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ac.ModifierAnneeScolaire(selectedAnneeId, libelleAnnee, checkBoxAnneEstActive.Checked))
            {
                MessageBox.Show("Année scolaire modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTextBox1.Clear();
                checkBoxAnneEstActive.Checked = false;
                selectedAnneeId = 0; // Réinitialisation de l'ID
                AuDemmarage();
                btnSupprimerAnnee.Visible = false;
                btnModifierAnnee.Visible = false;
            }
        }

        private void btnSupprimerAnnee_Click(object sender, EventArgs e)
        {
            if (selectedAnneeId == 0)
            {
                MessageBox.Show("Veuillez d'abord double-cliquer sur l'année à supprimer dans le tableau.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer l'année scolaire '{maskedTextBox1.Text}' ?",
                                                        "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (ac.SupprimerAnneeScolaire(selectedAnneeId))
                {
                    MessageBox.Show("Année scolaire supprimée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maskedTextBox1.Clear();
                    checkBoxAnneEstActive.Checked = false;
                    selectedAnneeId = 0; // Réinitialisation de l'ID
                    AuDemmarage();
                    btnSupprimerAnnee.Visible = false;
                    btnModifierAnnee.Visible = false;
                }
            }
        }

        private void dgvSections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSections.Rows[e.RowIndex];

                Popup_Section ps = new Popup_Section();
                ps.ActionBoutonSection = "Modifier";

                // Transfert des données vers le Form Popup
                ps.sectionId = Convert.ToInt32(row.Cells["ID"].Value);
                ps.nomSection = row.Cells["Nom de la Section"].Value.ToString();

                ps.ShowDialog();

                // Rafraîchir l'affichage après fermeture du dialogue
                AuDemmarage();
            }
        }

        private void dgvOptions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOptions.Rows[e.RowIndex];

                // Remplacer Popup_Section par Popup_Option (ou ton formulaire popup dédié aux options)
                Popup_Section po = new Popup_Section();
                po.ActionBoutonOption = "Modifier";

                // Transfert des données
                po.optionId = Convert.ToInt32(row.Cells["ID"].Value);
                po.nomOption = row.Cells["Option / Filière"].Value.ToString();

                // Transfert du SectionId s'il est présent dans la grille (masqué ou visible)
                if (dgvOptions.Columns.Contains("SectionId") && row.Cells["SectionId"].Value != null)
                {
                    po.sectionId = Convert.ToInt32(row.Cells["SectionId"].Value);
                }

                po.ShowDialog();

                // Rafraîchir l'affichage après la fermeture
                AuDemmarage();
            }
        }

        private void dgvClasses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClasses.Rows[e.RowIndex];

                Popup_Classe cl = new Popup_Classe();
                cl.ActionBoutonClasse = "Modifier";

                // Récupération sécurisée avec vérification d'existence de colonne
                cl.classeId = Convert.ToInt32(ObtenirValeurCellule(row, "ID"));
                cl.nomClasse = ObtenirValeurCellule(row, "Nom de la Classe")?.ToString() ?? string.Empty;

                object valSection = ObtenirValeurCellule(row, "SectionId");
                cl.sectionId = valSection != null ? Convert.ToInt32(valSection) : 0;

                object valOption = ObtenirValeurCellule(row, "OptionId");
                if (valOption != null && valOption != DBNull.Value)
                {
                    cl.optionId = Convert.ToInt32(valOption);
                }
                else
                {
                    cl.optionId = null;
                }

                cl.ShowDialog();

                // Rafraîchissement
                AuDemmarage();
            }
        }

        // Méthode helper pour éviter l'exception d'absence de colonne
        private object ObtenirValeurCellule(DataGridViewRow row, string columnName)
        {
            if (row.DataGridView.Columns.Contains(columnName))
            {
                return row.Cells[columnName].Value;
            }
            return null;
        }

        private void dgvAnnees_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAnnees.Rows[e.RowIndex];

                if (row.Cells["ID"].Value != null && int.TryParse(row.Cells["ID"].Value.ToString(), out selectedAnneeId))
                {
                    maskedTextBox1.Text = row.Cells["Année Scolaire"].Value.ToString();

                    // Vérification si la colonne EstCloturee existe ou si le Statut est 'Clôturée'
                    bool estCloturee = false;

                    if (dgvAnnees.Columns.Contains("EstCloturee") && row.Cells["EstCloturee"].Value != DBNull.Value)
                    {
                        estCloturee = Convert.ToBoolean(row.Cells["EstCloturee"].Value);
                    }
                    else if (row.Cells["Statut"].Value != null)
                    {
                        estCloturee = row.Cells["Statut"].Value.ToString() == "Clôturée";
                    }

             

                    btnSupprimerAnnee.Visible = true;
                    btnModifierAnnee.Visible = true;
                }
            }
        }

        private void btnrestaurerAnner_Click(object sender, EventArgs e)
        {
            // 1. Vérification qu'une année a été sélectionnée dans le DGV
            if (selectedAnneeId <= 0)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une année scolaire à restaurer.",
                                "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string libelleAnnee = maskedTextBox1.Text;

            // 2. Boîte de confirmation explicite
            DialogResult confirm = MessageBox.Show(
                $"Voulez-vous vraiment restaurer / réouvrir l'année scolaire '{libelleAnnee}' ?\n\n" +
                "Cela autorisera de nouveau la modification et l'enregistrement des paiements pour cette année.",
                "Confirmation de Restauration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // 3. Appel à la couche d'accès aux données
                if (ac.RestaurerAnneeScolaire(selectedAnneeId))
                {
                    MessageBox.Show($"L'année scolaire {libelleAnnee} a été restaurée avec succès.",
                                    "Restauration réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Rafraîchissement du formulaire et de la grille
                    AuDemmarage();
                }
            }
        }
    




}
}
