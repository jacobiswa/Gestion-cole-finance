using iTextSharp.xmp.options;
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
    public partial class Popup_Section : Form
    {
        public Popup_Section()
        {
            InitializeComponent();
        }
        public string ActionBoutonSection { get; set; } = "Ajouter";
        public int sectionId { get; set; } = 0;
        public string nomSection { get; set; } = "";

        public string ActionBoutonOption { get; set; } = "Ajouter";
        public int optionId { get; set; } = 0;
        public string nomOption { get; set; } = "";
    

        AnneeAcademique ac = new AnneeAcademique();

        private void Popup_Section_Load(object sender, EventArgs e)
        {
            if (ActionBoutonSection == "Ajouter")
            {
                btnAjouterSection.Text = "Ajouter section";
                txtNomSection.Focus();
            }
            else if (ActionBoutonSection == "Modifier")
            {

                txtNomSection.Text = nomSection;
                btnAjouterSection.Text = "Modifier Option";
                btnSupprimerSection.Enabled=true; // Activer le bouton Supprimer lors de la modification
                txtNomSection.Focus();
            }

            if (ActionBoutonOption == "Ajouter")
            {
                btnAjouterOption.Visible = true;
                btnAjouterOption.Text = "Ajouter Option";
            }
            else if (ActionBoutonOption == "Modifier")
            {
                btnAjouterOption.Text = "Modifier Option";
                txtNomOption.Text = nomOption;
                btnSupprimerOption.Enabled = true; // Activer le bouton Supprimer lors de la modification
            }

            ChargerSectionsDansComboBox();
        }
        public void ChargerSectionsDansComboBox()

        {

            DataTable dt = ac.ObtenirToutesLesSections();

            if (dt != null && dt.Rows.Count > 0)
            {
                cmbSections.DataSource = dt;
                cmbSections.DisplayMember = "Nom de la Section"; // Le texte affiché dans la liste
                cmbSections.ValueMember = "ID";                   // L'ID sous-jacent récupérable via SelectedValue
                cmbSections.SelectedIndex = -1;                  // Aucune sélection par défaut
            }
        }

        private void btnAjouterSection_Click(object sender, EventArgs e)
        {
            if (ActionBoutonSection == "Ajouter")
            {
                AjouterSection();
            }
            else if (ActionBoutonSection == "Modifier")
            {
                ModifierSection();
                btnSupprimerSection.Enabled = true; // Activer le bouton Supprimer après la modification
            }
        }

        private void btnAjouterOption_Click(object sender, EventArgs e)
        {
           if (ActionBoutonOption == "Ajouter")
            {
                AjouterOption();
            }
            else if (ActionBoutonOption == "Modifier")
            {
                ModifierOption();
                btnSupprimerOption.Enabled = true; // Activer le bouton Supprimer après la modification
            }
        }
        private void AjouterSection()
        {
            string nomSection = txtNomSection.Text.Trim(); // Remplace txtNomSection par le nom de ton TextBox

            // 1. Validation du champ texte
            if (string.IsNullOrWhiteSpace(nomSection))
            {
                MessageBox.Show("Veuillez saisir le nom de la section (ex: Maternelle, Primaire, Secondaire).",
                                "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomSection.Focus();
                return;
            }

            // 2. Vérification avant insertion
            if (ac.ExisteSection(nomSection))
            {
                MessageBox.Show($"La section '{nomSection}' existe déjà dans la base de données.",
                                "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Insertion et rafraîchissement
            if (ac.InsererSection(nomSection))
            {
                MessageBox.Show("Section ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNomSection.Clear();
                ChargerSectionsDansComboBox();
            }
        }
        private void ModifierSection()
        {
            string nom = txtNomSection.Text.Trim();

            if (string.IsNullOrWhiteSpace(nom))
            {
                MessageBox.Show("Veuillez saisir un nom de section.", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomSection.Focus();
                return;
            }

            if (ac.ModifierSection(sectionId, nom))
            {
                MessageBox.Show("Section modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void AjouterOption()
        {
            string nomOption = txtNomOption.Text.Trim(); // Remplace txtNomOption par le nom de ton TextBox

            // 1. Validation du champ texte
            if (string.IsNullOrWhiteSpace(nomOption))
            {
                MessageBox.Show("Veuillez saisir le nom de l'option (ex: Pedagojie Générale, Bio-Chimie, Math-Physique).",
                                "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomOption.Focus();
                return;
            }

            // 2. Validation de la sélection de la Section
            if (cmbSections.SelectedValue == null ||
                !int.TryParse(cmbSections.SelectedValue.ToString(), out int sectionId) ||
                sectionId <= 0)
            {
                MessageBox.Show("Veuillez sélectionner une section valide.",
                                "Section requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Vérification des doublons dans la même section
            if (ac.ExisteOption(nomOption, sectionId))
            {
                MessageBox.Show($"L'option '{nomOption}' existe déjà pour cette section.",
                                "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Insertion et rafraîchissement
            if (ac.InsererOption(nomOption, sectionId))
            {
                MessageBox.Show("Option ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNomOption.Clear();
            }
        }
        private void ModifierOption()
        {
            string nom = txtNomOption.Text.Trim();

            if (string.IsNullOrWhiteSpace(nom))
            {
                MessageBox.Show("Veuillez saisir un nom d'option.", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomOption.Focus();
                return;
            }

            if (cmbSections.SelectedValue == null || !int.TryParse(cmbSections.SelectedValue.ToString(), out int secId))
            {
                MessageBox.Show("Veuillez sélectionner une section.", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ac.ModifierOption(optionId, nom, secId))
            {
                MessageBox.Show("Option modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSupprimerSection_Click(object sender, EventArgs e)
        {
            if (sectionId <= 0) return;

            DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer la section '{nomSection}' ?",
                                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ac.SupprimerSection(sectionId))
                {
                    MessageBox.Show("Section supprimée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnSupprimerOption_Click(object sender, EventArgs e)
        {
            if (optionId <= 0) return;

            DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer l'option '{nomOption}' ?",
                                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ac.SupprimerOption(optionId))
                {
                    MessageBox.Show("Option supprimée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }





    }
}
