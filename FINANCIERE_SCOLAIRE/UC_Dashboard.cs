using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FINANCIERE_SCOLAIRE
{
    public partial class UC_Dashboard : UserControl
    {
        private readonly DashboardService _dashboardService = new DashboardService();
        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            ChargerDonneesDashboard();
        }
        public void ChargerDonneesDashboard()
        {
            try
            {

                DashboardMetrics metrics = _dashboardService.ObtenirMetriquesGlobales();

                // 1. Mise à jour de vos Labels
                lblTotalEleves.Text ="Nombre Total des élèves : "+ metrics.TotalEleves.ToString("N0");
                lblEncaisseJour.Text = $"Encaissent Journalier : {metrics.TotalEncaisseJour:N2} $";
                lblEncaisseMois.Text = $"Encaissement mensuel : {metrics.TotalEncaisseMois:N2} $";
                lblTauxRecouvrement.Text = $"Taux du Recouvrement : {metrics.TauxRecouvrement} %";

                // 2. ProgressBar pour le Taux de Recouvrement (0 à 100 %)
                progressTauxRecouvrement.Minimum = 0;
                progressTauxRecouvrement.Maximum = 100;

                int tauxInt = (int)Math.Round(metrics.TauxRecouvrement);
                // Math.Clamp évite que l'application plante si le taux dépasse 100% ou est inférieur à 0%
                progressTauxRecouvrement.Value = Math.Clamp(tauxInt, 0, 100);

                // 3. ProgressBar pour les Élèves (par rapport à la capacité de l'école)
                int capaciteMaxEleves = 100000; // Définissez votre objectif ou capacité maximale
                progressEleves.Minimum = 0;
                progressEleves.Maximum = capaciteMaxEleves;
                progressEleves.Value = Math.Min(metrics.TotalEleves, capaciteMaxEleves);

                // 4. ProgressBar pour l'Encaissé du Mois (par rapport à un objectif financier)
                decimal objectifMensuel = 50000m; // Exemple d'objectif
                progressEncaisseMois.Minimum = 0;
                progressEncaisseMois.Maximum = (int)objectifMensuel;
                progressEncaisseMois.Value = Math.Min((int)metrics.TotalEncaisseMois, (int)objectifMensuel);


                // 2. Chargement du Tableau des derniers paiements
                dgvDerniersPaiements.DataSource = _dashboardService.ObtenirDerniersPaiements();
                AjusterGrillePaiements();

                // 3. Chargement des Graphiques
                ChargerGraphiqueRecettesParSection();
              ChargerGraphiqueEvolutionMensuelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement du Tableau de bord : {ex.Message}",
                                "Erreur Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChargerGraphiqueRecettesParSection()
        {
            DataTable dt = _dashboardService.ObtenirRecettesParSection();

            chartSection.Series.Clear();
            chartSection.Titles.Clear();
            chartSection.Titles.Add("Recettes par Section ($)");

            Series series = new Series("Recettes")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dt.Rows)
            {
                string section = row["NomSection"].ToString();
                decimal total = Convert.ToDecimal(row["TotalPerçu"]);
                series.Points.AddXY(section, total);
            }

            chartSection.Series.Add(series);
        }

        private void ChargerGraphiqueEvolutionMensuelle()
        {
            DataTable dt = _dashboardService.ObtenirEvolutionRecettesMensuelles();

            chartEvolution.Series.Clear();
            chartEvolution.Titles.Clear();
            chartEvolution.Titles.Add("Évolution des Encaissements ($)");

            Series series = new Series("Encaissements")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(41, 128, 185),
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dt.Rows)
            {
                string mois = row["Mois"].ToString();
                decimal total = Convert.ToDecimal(row["Total"]);
                series.Points.AddXY(mois, total);
            }

            chartEvolution.Series.Add(series);
        }




        private void AjusterGrillePaiements()
        {
            if (dgvDerniersPaiements.Columns.Count > 0)
            {
                dgvDerniersPaiements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDerniersPaiements.ReadOnly = true;
                dgvDerniersPaiements.AllowUserToAddRows = false;
                dgvDerniersPaiements.RowHeadersVisible = false;
                dgvDerniersPaiements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            ChargerDonneesDashboard();
        }












    }
}
