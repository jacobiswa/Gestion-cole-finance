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
    public partial class Popup_Eleve : Form
    {
        AnneeAcademique ac = new AnneeAcademique();
        Eleves ev = new Eleves();

        public string ActionBoutonEleve { get; set; } = "Ajouter";
        public int SelectedEleveId { get; set; } = 0;

        public Popup_Eleve()
        {
            InitializeComponent();
        }

        private void Popup_Eleve_Load(object sender, EventArgs e)
        {
            // 1. Charger les ComboBox initiales
            ChargerSections();
            ChargerTypesEleves();

            // 2. Adapter le formulaire selon le mode (Ajouter ou Modifier)
            if (ActionBoutonEleve == "Modifier" && SelectedEleveId > 0)
            {
                lblTitre.Text = "Modifier l'élève";
                btnAjouterEleve.Text = "Modifier";
                if (btnSupprimerEleve != null) btnSupprimerEleve.Enabled = true;

                // Remplir les champs avec les données existantes de l'élève
                RemplirChampsPourModification(SelectedEleveId);
            }
            else
            {
                lblTitre.Text = "Ajouter un élève";
                btnAjouterEleve.Text = "Ajouter";
                if (btnSupprimerEleve != null) btnSupprimerEleve.Enabled = false;

                // Génération automatique du matricule pour un nouvel élève
                txtMatricule.Text = ev.GenererMatriculeAutomatique();
            }
        }
        private void ChargerTypesEleves()
        {
            // Nettoyer la liste existante s'il y en a une
            cmbTypeEleve.Items.Clear();

            // Ajouter les catégories d'élèves
            cmbTypeEleve.Items.Add("Régulier");
            cmbTypeEleve.Items.Add("Boursier");
            cmbTypeEleve.Items.Add("Enfant du personnel");
            cmbTypeEleve.Items.Add("Prise en charge");

            // Définir la valeur par défaut ("Régulier")
            cmbTypeEleve.SelectedIndex = 0;
        }
        private void ChargerSections()
        {
            cmbSection.DataSource = ac.ObtenirToutesLesSections();
            cmbSection.DisplayMember = "Nom de la Section";
            cmbSection.ValueMember = "Id";
            cmbSection.SelectedIndex = -1;
        }

        private void ChargerClasses(int sectionId, int? optionId)
        {
            cmbClasse.DataSource = ac.ObtenirClassesParSectionEtOption(sectionId, optionId);
            cmbClasse.DisplayMember = "NomClasse";
            cmbClasse.ValueMember = "Id";
            cmbClasse.SelectedIndex = -1;
        }
        private void RemplirChampsPourModification(int eleveId)
        {
            DataTable dt = ev.ObtenirEleveParId(eleveId);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                // 1. Informations de base
                txtMatricule.Text = dr["Matricule"].ToString();
                txtNom.Text = dr["Nom"].ToString();
                txtPostnom.Text = dr["Postnom"].ToString();
                txtPrenom.Text = dr["Prenom"].ToString();

                // 2. Genre
                string sexe = dr["Sexe"].ToString();
                rbSexeM.Checked = (sexe == "M");
                rbSexeF.Checked = (sexe == "F");

                // 3. Naissance
                if (dr["DateNaissance"] != DBNull.Value)
                    dtpDateNaissance.Value = Convert.ToDateTime(dr["DateNaissance"]);

                txtLieuNaissance.Text = dr["LieuNaissance"]?.ToString();

                // 4. Type d'élève
                if (dr["TypeEleve"] != DBNull.Value && !string.IsNullOrEmpty(dr["TypeEleve"].ToString()))
                {
                    cmbTypeEleve.SelectedItem = dr["TypeEleve"].ToString();
                }
                else
                {
                    cmbTypeEleve.SelectedIndex = 0; // "Régulier" par défaut
                }

                // 5. Sélection de la Section, Option et Classe (Ordre séquentiel strict)
                if (dr["SectionId"] != DBNull.Value)
                {
                    int sectionId = Convert.ToInt32(dr["SectionId"]);
                    cmbSection.SelectedValue = sectionId;

                    // Récupérer et affecter l'option si elle existe
                    int? optionId = null;
                    if (dr["OptionId"] != DBNull.Value)
                    {
                        optionId = Convert.ToInt32(dr["OptionId"]);
                        cmbOption.SelectedValue = optionId.Value;
                    }

                    // Forcer le rechargement explicite des classes correspondantes
                    ChargerClasses(sectionId, optionId);

                    // Sélectionner la classe de l'élève
                    if (dr["ClasseId"] != DBNull.Value)
                    {
                        cmbClasse.SelectedValue = Convert.ToInt32(dr["ClasseId"]);
                    }
                }

                // 6. Informations Tuteur & Adresse
                txtNomTuteur.Text = dr["NomTuteur"]?.ToString();
                mtxtTelTuteur.Text = dr["TelephoneTuteur"]?.ToString();
                txtAdresse.Text = dr["Adresse"]?.ToString();
            }
        }
        private void EnregistrerEleve()
        {
            // 1. Validations des champs obligatoires
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPostnom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Veuillez remplir le nom, postnom et prénom de l'élève.",
                                "Champ Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbClasse.SelectedValue == null || !int.TryParse(cmbClasse.SelectedValue.ToString(), out int classeId))
            {
                MessageBox.Show("Veuillez attribuer une classe valide à l'élève.",
                                "Champ Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Récupération des valeurs du formulaire
            string matricule = txtMatricule.Text.Trim();
            string nom = txtNom.Text.Trim();
            string postnom = txtPostnom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string sexe = rbSexeM.Checked ? "M" : "F";
            DateTime dateNaissance = dtpDateNaissance.Value;
            string lieuNaissance = txtLieuNaissance.Text.Trim();
            string typeEleve = cmbTypeEleve.SelectedItem != null ? cmbTypeEleve.SelectedItem.ToString() : "Régulier";
            string nomTuteur = txtNomTuteur.Text.Trim();
            string telTuteur = mtxtTelTuteur.Text.Trim();
            string adresse = txtAdresse.Text.Trim();

            bool succes = false;

            // 3. Traitement selon le mode
            if (ActionBoutonEleve == "Ajouter" || SelectedEleveId == 0)
            {
                if (string.IsNullOrWhiteSpace(matricule))
                {
                    matricule = ev.GenererMatriculeAutomatique();
                }

                succes = ev.AjouterEleve(matricule, nom, postnom, prenom, sexe, dateNaissance,
                                        lieuNaissance, classeId, typeEleve, nomTuteur, telTuteur, adresse);

                if (succes)
                {
                    MessageBox.Show("Élève enregistré avec succès !", "Succès",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ActionBoutonEleve == "Modifier" && SelectedEleveId > 0)
            {
                succes = ev.ModifierEleve(SelectedEleveId, nom, postnom, prenom, sexe, dateNaissance,
                                         lieuNaissance, classeId, typeEleve, nomTuteur, telTuteur, adresse);

                if (succes)
                {
                    MessageBox.Show("Élève modifié avec succès !", "Succès",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // 4. Fermeture avec succès pour notifier le formulaire parent
            if (succes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void btnAjouterEleve_Click(object sender, EventArgs e)
        {
            EnregistrerEleve();
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            ChargerSections();
        }


        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedValue != null && int.TryParse(cmbSection.SelectedValue.ToString(), out int sectionId))
            {
                DataTable dtOptions = ac.ObtenirOptionsParSection(sectionId);

                if (dtOptions != null && dtOptions.Rows.Count > 0)
                {
                    cmbOption.Enabled = true;
                    cmbOption.DataSource = dtOptions;
                    cmbOption.DisplayMember = "Option / Filière";
                    cmbOption.ValueMember = "Id";
                    cmbOption.SelectedIndex = -1;
                }
                else
                {
                    cmbOption.DataSource = null;
                    cmbOption.Enabled = false;
                }

                ChargerClasses(sectionId, null);
            }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedValue != null && int.TryParse(cmbSection.SelectedValue.ToString(), out int sectionId))
            {
                int? optionId = null;
                if (cmbOption.Enabled && cmbOption.SelectedValue != null && int.TryParse(cmbOption.SelectedValue.ToString(), out int optId))
                {
                    optionId = optId;
                }

                ChargerClasses(sectionId, optionId);
            }
        }

        private void btnSupprimerEleve_Click(object sender, EventArgs e)
        {        
            if (SelectedEleveId <= 0)
            {
                MessageBox.Show("Veuillez d'abord sélectionner un élève dans la liste.",
                                "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomEleve = $"{txtNom.Text} {txtPostnom.Text} {txtPrenom.Text}".Trim();

            DialogResult dialogResult = MessageBox.Show(
                $"Êtes-vous sûr de vouloir désactiver l'élève {nomEleve} ?\n\n" +
                "L'élève ne sera plus visible dans la liste active mais ses historiques comptables seront conservés.",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                if (ev.SupprimerEleve(SelectedEleveId))
                {
                    MessageBox.Show("Élève désactivé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si le code est dans un Popup, fermer le formulaire avec DialogResult.OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
