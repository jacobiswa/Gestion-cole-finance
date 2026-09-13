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
    public partial class UC_GestionEleves : UserControl
    {
        AnneeAcademique ac = new AnneeAcademique();
        Eleves ev = new Eleves();
        public UC_GestionEleves()
        {
            InitializeComponent();
        }

        private void UC_GestionEleves_Load(object sender, EventArgs e)
        {
            ChargerClassesDansComboBox();
            ChargerListeEleves();
        }
        private void ChargerListeEleves()
        {
            DataTable dt = ev.ObtenirTousLesEleves();
            dgvEleves.DataSource = dt;

            // Masquer la colonne ID si elle existe dans le DataGridView
            if (dgvEleves.Columns.Contains("Id"))
            {
                dgvEleves.Columns["Id"].Visible = false;
            }

            // Facultatif : Masquer ClasseId, SectionId ou OptionId s'ils sont retournés dans le DataTable
            if (dgvEleves.Columns.Contains("ClasseId"))
            {
                dgvEleves.Columns["ClasseId"].Visible = false;
            }
        }

        public void ChargerClassesDansComboBox()
        {
            DataTable dt = ac.ObtenirToutesLesClasses();

            if (dt != null && dt.Rows.Count > 0)
            {
                cmbFiltreClasse.DataSource = dt;
                cmbFiltreClasse.DisplayMember = "Nom de la Classe"; // Le nom de la classe
                cmbFiltreClasse.ValueMember = "ID";                 // L'ID de la classe
                cmbFiltreClasse.SelectedIndex = -1;
            }
        }

        private void btnNouvelEleve_Click(object sender, EventArgs e)
        {
            Popup_Eleve popup = new Popup_Eleve();
            popup.ActionBoutonEleve = "Ajouter";

            // Si le popup se ferme avec succès, rafraîchir la liste des élèves
            if (popup.ShowDialog() == DialogResult.OK)
            {
                ChargerListeEleves(); // Votre méthode de rechargement de la grille
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            string recherche = txtRecherche.Text.Trim();

            if (dgvEleves.DataSource is DataTable dt)
            {
                if (string.IsNullOrWhiteSpace(recherche))
                {
                    dt.DefaultView.RowFilter = "";
                    return;
                }

                // Découpage de la recherche en plusieurs mots
                string[] mots = recherche.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<string> conditionsMots = new List<string>();

                foreach (string mot in mots)
                {
                    // Protection contre les guillemets simples pour éviter les erreurs de syntaxe DataView
                    string motEchape = mot.Replace("'", "''");

                    // Pour chaque mot, il doit correspondre à au moins une des colonnes
                    string condition = $"(" +
                                       $"Matricule LIKE '%{motEchape}%' OR " +
                                       $"Nom LIKE '%{motEchape}%' OR " +
                                       $"Postnom LIKE '%{motEchape}%' OR " +
                                       $"Prenom LIKE '%{motEchape}%' OR " +
                                       $"Classe LIKE '%{motEchape}%' OR " +
                                       $"Tuteur LIKE '%{motEchape}%'" +
                                       $")";

                    conditionsMots.Add(condition);
                }

                // Combinaison des mots avec AND
                dt.DefaultView.RowFilter = string.Join(" AND ", conditionsMots);
            }
        }
        public int selectedEleveId = 0; // Variable globale pour stocker l'ID de l'élève sélectionné
        private void dgvEleves_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. S'assurer que le double-clic est sur une vraie ligne et non sur l'en-tête de la grille
            if (e.RowIndex >= 0)
            {
                // 2. Récupérer la ligne sélectionnée
                DataGridViewRow row = dgvEleves.Rows[e.RowIndex];

                // 3. Extraire l'ID de l'élève depuis la colonne "Id"
                if (row.Cells["Id"].Value != null && int.TryParse(row.Cells["Id"].Value.ToString(), out int idEleve))
                {
                    selectedEleveId = idEleve; // Mettre à jour la variable globale/locale

                    // 4. Instancier et configurer le Popup en mode Modification
                    Popup_Eleve popup = new Popup_Eleve();
                    popup.ActionBoutonEleve = "Modifier";
                    popup.SelectedEleveId = selectedEleveId;

                    // 5. Afficher le popup de manière modale et rafraîchir si la modification a été validée
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        ChargerListeEleves();
                    }
                }
            }
        }

        private void btnFicheEleve_Click(object sender, EventArgs e)
        {
            Infos_eleve_fm infosEleveForm = new Infos_eleve_fm();
            infosEleveForm.IdEleve = selectedEleveId; // Passer l'ID de l'élève sélectionné au formulaire
            infosEleveForm.ShowDialog();
        }

        private void dgvEleves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. S'assurer que le double-clic est sur une vraie ligne et non sur l'en-tête de la grille
            if (e.RowIndex >= 0)
            {
                // 2. Récupérer la ligne sélectionnée
                DataGridViewRow row = dgvEleves.Rows[e.RowIndex];
                // 3. Extraire l'ID de l'élève depuis la colonne "Id"
                if (row.Cells["Id"].Value != null && int.TryParse(row.Cells["Id"].Value.ToString(), out int idEleve))
                {
                    selectedEleveId = idEleve; // Mettre à jour la variable globale/locale
                }
            }
        }

        private void cmbFiltreClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Récupération de l'ID de la classe sélectionnée dans le ComboBox
            if (cmbFiltreClasse.SelectedValue != null && int.TryParse(cmbFiltreClasse.SelectedValue.ToString(), out int idClasse))
            {
                // Si 0 représente "Toutes les classes", on passe null pour charger tout
                int? filtreId = idClasse > 0 ? idClasse : (int?)null;

                DataTable dtEleves = ev.ObtenirElevesParClasse(filtreId);
                dgvEleves.DataSource = dtEleves; // Remplacer par le nom de votre DataGridView
            }
        }

     
    }
}
