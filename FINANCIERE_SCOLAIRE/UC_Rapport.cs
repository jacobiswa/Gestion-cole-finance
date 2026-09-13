using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public partial class UC_Rapport : UserControl
    {
        private readonly RapportService service = new RapportService();
        private readonly RecouvrementService recouvrementService = new RecouvrementService();
        private DataTable dtGraphiqueEtGrille = new DataTable();
        public UC_Rapport()
        {
            InitializeComponent();
        }

        private void UC_Rapport_Load(object sender, EventArgs e)
        {
            dtpJournalier.Value = DateTime.Today;
            dtpDebut.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFin.Value = DateTime.Today;

            ChargerAnneesScolaires();
            ChargerFrais();
        }

        private void ChargerAnneesScolaires()
        {
            cboAnneeScolaire.DataSource = service.ObtenirAnneesScolaires();
            cboAnneeScolaire.DisplayMember = "Libelle";
            cboAnneeScolaire.ValueMember = "Id";
        }

        private void ChargerFrais()
        {
            cboFrais.DataSource = recouvrementService.ObtenirConfigurationsFrais();
            cboFrais.DisplayMember = "LibelleFrais";
            cboFrais.ValueMember = "Id";
        }

        // --- 1. RAPPORT JOURNALIER ---
        private void btnChargerJournalier_Click(object sender, EventArgs e)
        {
            var liste = service.ObtenirJournalCaisse(dtpJournalier.Value);
            dtGraphiqueEtGrille = ConvertToDataTable(liste);
            dgvRapports.DataSource = dtGraphiqueEtGrille;
            lblTitreRapport.Text = $"Journal de Caisse du {dtpJournalier.Value:dd/MM/yyyy}";
        }

        // --- 2. BILAN MENSUEL / TRIMESTRIEL ---
        private void btnChargerBilanPeriodique_Click(object sender, EventArgs e)
        {
            var liste = service.ObtenirBilanPeriodique(dtpDebut.Value, dtpFin.Value);
            dtGraphiqueEtGrille = ConvertToDataTable(liste);
            dgvRapports.DataSource = dtGraphiqueEtGrille;
            lblTitreRapport.Text = $"Bilan des entrées du {dtpDebut.Value:dd/MM/yyyy} au {dtpFin.Value:dd/MM/yyyy}";
        }

        // --- 3. TAUX DE RECOUVREMENT ---
        private void btnChargerTaux_Click(object sender, EventArgs e)
        {
            if (cboFrais.SelectedValue == null || cboFrais.SelectedValue is DataRowView) return;

            int fraisId = Convert.ToInt32(cboFrais.SelectedValue);
            var liste = service.ObtenirTauxRecouvrement(fraisId);
            dtGraphiqueEtGrille = ConvertToDataTable(liste);
            dgvRapports.DataSource = dtGraphiqueEtGrille;
            lblTitreRapport.Text = $"Analyse du Taux de Recouvrement - {cboFrais.Text}";
        }

        // --- 4. SYNTHÈSE ANNUELLE ---
        private void btnChargerAnnuel_Click(object sender, EventArgs e)
        {
            if (cboAnneeScolaire.SelectedValue == null || cboAnneeScolaire.SelectedValue is DataRowView) return;

            int anneeId = Convert.ToInt32(cboAnneeScolaire.SelectedValue);
            SyntheseAnnuelle syn = service.ObtenirSyntheseAnnuelle(anneeId);

            DataTable dt = new DataTable();
            dt.Columns.Add("Indicateur");
            dt.Columns.Add("Valeur");

            dt.Rows.Add("Total Élèves Inscrits", syn.TotalElevesInscrits);
            dt.Rows.Add("Montant Total Attendu ($)", $"{syn.MontantTotalAttenduUSD:N2} USD");
            dt.Rows.Add("Montant Total Recouvré ($)", $"{syn.MontantTotalRecouvreUSD:N2} USD");
            dt.Rows.Add("Reste à Recouvrer ($)", $"{syn.MontantTotalResteUSD:N2} USD");
            dt.Rows.Add("Taux Global de Recouvrement (%)", $"{syn.TauxGlobalRecouvrement:N2} %");

            dtGraphiqueEtGrille = dt;
            dgvRapports.DataSource = dtGraphiqueEtGrille;
            lblTitreRapport.Text = $"Synthèse Financière Globale - Année {cboAnneeScolaire.Text}";
        }

        // --- EXPORTATION PDF ---
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvRapports.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Fichier PDF (*.pdf)|*.pdf",
                FileName = $"Rapport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable dtEcole = service.ObtenirParametresEcole();
                PdfRapportService.GenererRapportPDF(sfd.FileName, dtGraphiqueEtGrille, dtEcole, lblTitreRapport.Text);
                MessageBox.Show("Rapport PDF généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
        }

        // --- EXPORTATION EXCEL ---
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvRapports.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Fichier Excel (*.xls)|*.xls",
                FileName = $"Rapport_{DateTime.Now:yyyyMMdd_HHmmss}.xls"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExcelExportService.ExporterDataTableVersExcel(dtGraphiqueEtGrille, sfd.FileName, lblTitreRapport.Text);
                MessageBox.Show("Rapport Excel généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
        }

        // Convertisseur générique List<T> -> DataTable
        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection properties = System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    













}
}
