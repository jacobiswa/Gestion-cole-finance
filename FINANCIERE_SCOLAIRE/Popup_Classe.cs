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
    public partial class Popup_Classe : Form
    {
        public string ActionBoutonClasse { get; set; } = "Ajouter";
        public int classeId { get; set; } = 0;
        public string nomClasse { get; set; } = "";
        public int sectionId { get; set; } = 0;
        public int? optionId { get; set; } = null;
        public Popup_Classe()
        {
            InitializeComponent();
        }
        AnneeAcademique ac = new AnneeAcademique();
        private void Popup_Classe_Load(object sender, EventArgs e)
        {

            ChargerOptionsDansComboBox();
            ChargerSectionsDansComboBox();
            ;

            if (ActionBoutonClasse == "Modifier")
            {
                lblTitre.Text = "Modifier la Classe";
                btnAjouterClasse.Text = "Modifier";
                btnSupprimerClasse.Visible = true;

                txtNomClasse.Text = nomClasse;
                cmbSections.SelectedValue = sectionId;

                if (optionId.HasValue && optionId.Value > 0)
                    cmbOptions.SelectedValue = optionId.Value;
                else
                    cmbOptions.SelectedIndex = 0; // "-- Aucune --"
            }
            else
            {
                lblTitre.Text = "Ajouter une Classe";
                btnAjouterClasse.Text = "Ajouter";
                btnSupprimerClasse.Visible = false;
            }
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

        public void ChargerOptionsDansComboBox()
        {
            DataTable dt = ac.ObtenirToutesLesOptions();
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbOptions.DataSource = dt;
                cmbOptions.DisplayMember = "Option / Filière"; // Le texte affiché
                cmbOptions.ValueMember = "ID";                 // L'ID de l'option
                cmbOptions.SelectedIndex = -1;
            }
        }

        private void btnAjouterClasse_Click(object sender, EventArgs e)
        {

            if (ActionBoutonClasse == "Ajouter")
                AjouterClasse();
            else if (ActionBoutonClasse == "Modifier")
                ModifierClasse();




        }

        private void AjouterClasse()
        {
            string nomClasse = txtNomClasse.Text.Trim();

            // 1. Validation du champ nom
            if (string.IsNullOrWhiteSpace(nomClasse))
            {
                MessageBox.Show("Veuillez saisir un nom de classe (ex: 1ère Maternelle, 7ème EB, 1ère Math-Physique).",
                                "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomClasse.Focus();
                return;
            }

            // 2. Validation et récupération de la Section
            if (cmbSections.SelectedValue == null ||
                !int.TryParse(cmbSections.SelectedValue.ToString(), out int sectionId) ||
                sectionId <= 0)
            {
                MessageBox.Show("Veuillez sélectionner une section valide.",
                                "Section requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Récupération de l'Option (null si non sélectionnée ou si "-- Toutes les options --" est choisi)
            int? optionId = null;
            if (cmbOptions.SelectedValue != null &&
                int.TryParse(cmbOptions.SelectedValue.ToString(), out int oId) &&
                oId > 0)
            {
                optionId = oId;
            }

            // 4. Vérification de doublon
            if (ac.ExisteClasse(nomClasse, sectionId, optionId))
            {
                MessageBox.Show($"La classe '{nomClasse}' existe déjà dans cette section / option.",
                                "Doublon détecté", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Insertion
            if (ac.InsererClasse(nomClasse, sectionId, optionId))
            {
                MessageBox.Show("Classe ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNomClasse.Clear();
                this.Close(); // Ferme la fenêtre après l'ajout
            }
        }

        private void ModifierClasse()
        {
            string nom = txtNomClasse.Text.Trim();

            if (string.IsNullOrWhiteSpace(nom))
            {
                MessageBox.Show("Veuillez saisir le nom de la classe.", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomClasse.Focus();
                return;
            }

            if (cmbSections.SelectedValue == null || !int.TryParse(cmbSections.SelectedValue.ToString(), out int secId))
            {
                MessageBox.Show("Veuillez sélectionner une section.", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? optId = null;
            if (cmbOptions.SelectedValue != null && int.TryParse(cmbOptions.SelectedValue.ToString(), out int oId) && oId > 0)
            {
                optId = oId;
            }

            if (ac.ModifierClasse(classeId, nom, secId, optId))
            {
                MessageBox.Show("Classe modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSupprimerClasse_Click(object sender, EventArgs e)
        {
            if (classeId <= 0) return;

            DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer la classe '{nomClasse}' ?",
                                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ac.SupprimerClasse(classeId))
                {
                    MessageBox.Show("Classe supprimée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
