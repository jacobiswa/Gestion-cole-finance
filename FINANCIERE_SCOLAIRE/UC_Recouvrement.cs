using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public partial class UC_Recouvrement : UserControl
    {
        private readonly RecouvrementService service = new RecouvrementService();
        private List<EleveSolvabilite> listeActuelle = new List<EleveSolvabilite>();
        public UC_Recouvrement()
        {
            InitializeComponent();
        }

        private void UC_Recouvrement_Load(object sender, EventArgs e)
        {
            ChargerFrais();
            ChargerSections();
            ChargerMois();
            ChargerStatuts();
        }
        private void ChargerFrais()
        {
            cboFrais.DataSource = service.ObtenirConfigurationsFrais();
            cboFrais.DisplayMember = "LibelleFrais";
            cboFrais.ValueMember = "Id";
        }

        private void ChargerSections()
        {
            DataTable dt = service.ObtenirSections();
            DataRow row = dt.NewRow();
            row["Id"] = 0;
            row["NomSection"] = "-- Toutes les sections --";
            dt.Rows.InsertAt(row, 0);

            cboSection.DataSource = dt;
            cboSection.DisplayMember = "NomSection";
            cboSection.ValueMember = "Id";
            cboSection.SelectedIndex = 0;
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Empêcher l'exécution si SelectedValue est null ou est encore un DataRowView (lors du bind)
            if (cboSection.SelectedValue == null || cboSection.SelectedValue is DataRowView)
                return;

            // 2. Traitement sécurisé de la valeur de SelectedValue
            int sectionId = 0;
            if (int.TryParse(cboSection.SelectedValue.ToString(), out int parsedId))
            {
                sectionId = parsedId;
            }

            // 3. Récupération et liaison des classes
            DataTable dt = service.ObtenirClassesParSection(sectionId);

            DataRow row = dt.NewRow();
            row["Id"] = 0;
            row["NomClasse"] = "-- Toutes les classes --";
            dt.Rows.InsertAt(row, 0);

            // Définir DisplayMember et ValueMember AVANT le DataSource évite des déclenchements parasites
            cboClasse.DataSource = null;
            cboClasse.DisplayMember = "NomClasse";
            cboClasse.ValueMember = "Id";
            cboClasse.DataSource = dt;
            cboClasse.SelectedIndex = 0;
        }

        private void ChargerMois()
        {
            cboMois.Items.Clear();
            cboMois.Items.Add("-- Tous les mois --");
            cboMois.Items.AddRange(new string[] {
                "Septembre", "Octobre", "Novembre", "Décembre",
                "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet"
            });
            cboMois.SelectedIndex = 0;
        }

        private void ChargerStatuts()
        {
            cboStatut.Items.Clear();
            cboStatut.Items.Add("TOUS");
            cboStatut.Items.Add("INSOLVABLE");
            cboStatut.Items.Add("A_JOUR");
            cboStatut.SelectedIndex = 0;
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (cboFrais.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un type de frais.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int fraisId = Convert.ToInt32(cboFrais.SelectedValue);
            int sectionId = Convert.ToInt32(cboSection.SelectedValue ?? 0);
            int classeId = Convert.ToInt32(cboClasse.SelectedValue ?? 0);
            string mois = cboMois.SelectedIndex > 0 ? cboMois.SelectedItem.ToString() : "";
            string statut = cboStatut.SelectedItem.ToString();

            listeActuelle = service.ObtenirRapportRecouvrement(fraisId, sectionId, classeId, mois, statut);
            dgvRecouvrement.DataSource = null;
            dgvRecouvrement.DataSource = listeActuelle;

            FormaterGrid();
        }

        private void FormaterGrid()
        {
            if (dgvRecouvrement.Columns["EleveId"] != null) dgvRecouvrement.Columns["EleveId"].Visible = false;

            dgvRecouvrement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecouvrement.ReadOnly = true;
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (listeActuelle == null || listeActuelle.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter. Effectuez d'abord une recherche.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Fichier PDF (*.pdf)|*.pdf",
                FileName = $"Bordereau_Recouvrement_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dtEcole = service.ObtenirParametresEcole();
                    string titre = $"Bordereau de Recouvrement - {cboFrais.Text}";

                    PdfRecouvrementService.GenererBordereauRecouvrement(sfd.FileName, listeActuelle, dtEcole, titre);

                    MessageBox.Show("Le bordereau PDF a été généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la génération du PDF : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    



}
}
