namespace FINANCIERE_SCOLAIRE
{
    partial class UC_Dashboard
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblTotalEleves = new Label();
            lblEncaisseJour = new Label();
            lblEncaisseMois = new Label();
            lblTauxRecouvrement = new Label();
            chartSection = new System.Windows.Forms.DataVisualization.Charting.Chart();
            progressTauxRecouvrement = new imj_Tools.RJProgressBar();
            progressEleves = new imj_Tools.RJProgressBar();
            progressEncaisseMois = new imj_Tools.RJProgressBar();
            panel_rond1 = new imj_Tools.Panel_rond();
            label1 = new Label();
            panel_rond2 = new imj_Tools.Panel_rond();
            label4 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel7 = new Panel();
            dgvDerniersPaiements = new DataGridView();
            panel_rond3 = new imj_Tools.Panel_rond();
            label2 = new Label();
            chartEvolution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)chartSection).BeginInit();
            panel_rond1.SuspendLayout();
            panel_rond2.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDerniersPaiements).BeginInit();
            panel_rond3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartEvolution).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotalEleves
            // 
            lblTotalEleves.AutoSize = true;
            lblTotalEleves.Location = new Point(14, 210);
            lblTotalEleves.Name = "lblTotalEleves";
            lblTotalEleves.Size = new Size(68, 15);
            lblTotalEleves.TabIndex = 0;
            lblTotalEleves.Text = "Total Eleves";
            // 
            // lblEncaisseJour
            // 
            lblEncaisseJour.AutoSize = true;
            lblEncaisseJour.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEncaisseJour.Location = new Point(14, 61);
            lblEncaisseJour.Name = "lblEncaisseJour";
            lblEncaisseJour.Size = new Size(160, 21);
            lblEncaisseJour.TabIndex = 0;
            lblEncaisseJour.Text = "Encaissent Journalier";
            // 
            // lblEncaisseMois
            // 
            lblEncaisseMois.AutoSize = true;
            lblEncaisseMois.Location = new Point(14, 115);
            lblEncaisseMois.Name = "lblEncaisseMois";
            lblEncaisseMois.Size = new Size(80, 15);
            lblEncaisseMois.TabIndex = 0;
            lblEncaisseMois.Text = "Encaisse Mois";
            // 
            // lblTauxRecouvrement
            // 
            lblTauxRecouvrement.AutoSize = true;
            lblTauxRecouvrement.Location = new Point(14, 162);
            lblTauxRecouvrement.Name = "lblTauxRecouvrement";
            lblTauxRecouvrement.Size = new Size(111, 15);
            lblTauxRecouvrement.TabIndex = 0;
            lblTauxRecouvrement.Text = "Taux Recouvrement";
            // 
            // chartSection
            // 
            chartSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chartSection.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartSection.Legends.Add(legend1);
            chartSection.Location = new Point(14, 48);
            chartSection.Name = "chartSection";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartSection.Series.Add(series1);
            chartSection.Size = new Size(366, 160);
            chartSection.TabIndex = 31;
            chartSection.Text = "chart1";
            // 
            // progressTauxRecouvrement
            // 
            progressTauxRecouvrement.ChannelColor = Color.FromArgb(255, 224, 192);
            progressTauxRecouvrement.ChannelHeight = 6;
            progressTauxRecouvrement.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            progressTauxRecouvrement.ForeBackColor = Color.FromArgb(192, 64, 0);
            progressTauxRecouvrement.ForeColor = Color.White;
            progressTauxRecouvrement.Location = new Point(14, 136);
            progressTauxRecouvrement.Name = "progressTauxRecouvrement";
            progressTauxRecouvrement.ShowMaximun = false;
            progressTauxRecouvrement.ShowValue = imj_Tools.TextPosition.Left;
            progressTauxRecouvrement.Size = new Size(224, 23);
            progressTauxRecouvrement.SliderColor = Color.RoyalBlue;
            progressTauxRecouvrement.SliderHeight = 6;
            progressTauxRecouvrement.SymbolAfter = "%";
            progressTauxRecouvrement.SymbolBefore = "";
            progressTauxRecouvrement.TabIndex = 32;
            // 
            // progressEleves
            // 
            progressEleves.ChannelColor = Color.LightSteelBlue;
            progressEleves.ChannelHeight = 6;
            progressEleves.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            progressEleves.ForeBackColor = Color.RoyalBlue;
            progressEleves.ForeColor = Color.White;
            progressEleves.Location = new Point(14, 184);
            progressEleves.Name = "progressEleves";
            progressEleves.ShowMaximun = false;
            progressEleves.ShowValue = imj_Tools.TextPosition.Left;
            progressEleves.Size = new Size(224, 23);
            progressEleves.SliderColor = Color.RoyalBlue;
            progressEleves.SliderHeight = 6;
            progressEleves.SymbolAfter = "";
            progressEleves.SymbolBefore = "";
            progressEleves.TabIndex = 32;
            // 
            // progressEncaisseMois
            // 
            progressEncaisseMois.ChannelColor = Color.LightSteelBlue;
            progressEncaisseMois.ChannelHeight = 6;
            progressEncaisseMois.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            progressEncaisseMois.ForeBackColor = Color.RoyalBlue;
            progressEncaisseMois.ForeColor = Color.White;
            progressEncaisseMois.Location = new Point(14, 89);
            progressEncaisseMois.Name = "progressEncaisseMois";
            progressEncaisseMois.ShowMaximun = false;
            progressEncaisseMois.ShowValue = imj_Tools.TextPosition.Left;
            progressEncaisseMois.Size = new Size(224, 23);
            progressEncaisseMois.SliderColor = Color.RoyalBlue;
            progressEncaisseMois.SliderHeight = 6;
            progressEncaisseMois.SymbolAfter = "$";
            progressEncaisseMois.SymbolBefore = "";
            progressEncaisseMois.TabIndex = 32;
            // 
            // panel_rond1
            // 
            panel_rond1.BorderColor = Color.FromArgb(192, 192, 255);
            panel_rond1.BorderRadius = 10;
            panel_rond1.BorderThickness = 2;
            panel_rond1.Controls.Add(progressEncaisseMois);
            panel_rond1.Controls.Add(lblTotalEleves);
            panel_rond1.Controls.Add(progressEleves);
            panel_rond1.Controls.Add(lblEncaisseMois);
            panel_rond1.Controls.Add(label1);
            panel_rond1.Controls.Add(lblEncaisseJour);
            panel_rond1.Controls.Add(progressTauxRecouvrement);
            panel_rond1.Controls.Add(lblTauxRecouvrement);
            panel_rond1.ForeColor = Color.FromArgb(64, 64, 64);
            panel_rond1.GradientAngle = 90F;
            panel_rond1.GradientBottomColor = Color.White;
            panel_rond1.GradientTopColor = Color.White;
            panel_rond1.Location = new Point(3, 3);
            panel_rond1.Name = "panel_rond1";
            panel_rond1.Size = new Size(255, 243);
            panel_rond1.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(14, 8);
            label1.Name = "label1";
            label1.Size = new Size(227, 37);
            label1.TabIndex = 0;
            label1.Text = "Synthèse Globale";
            // 
            // panel_rond2
            // 
            panel_rond2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_rond2.BorderColor = Color.FromArgb(192, 192, 255);
            panel_rond2.BorderRadius = 10;
            panel_rond2.BorderThickness = 2;
            panel_rond2.Controls.Add(label4);
            panel_rond2.Controls.Add(chartSection);
            panel_rond2.ForeColor = Color.FromArgb(64, 64, 64);
            panel_rond2.GradientAngle = 90F;
            panel_rond2.GradientBottomColor = Color.White;
            panel_rond2.GradientTopColor = Color.White;
            panel_rond2.Location = new Point(264, 3);
            panel_rond2.Name = "panel_rond2";
            panel_rond2.Size = new Size(394, 243);
            panel_rond2.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SteelBlue;
            label4.Location = new Point(14, 8);
            label4.Name = "label4";
            label4.Size = new Size(265, 37);
            label4.TabIndex = 0;
            label4.Text = "Recettes par Section";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel_rond3);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(719, 644);
            panel1.TabIndex = 34;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(10, 845);
            panel2.Name = "panel2";
            panel2.Size = new Size(682, 95);
            panel2.TabIndex = 37;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvDerniersPaiements);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(10, 475);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(682, 370);
            panel7.TabIndex = 36;
            // 
            // dgvDerniersPaiements
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvDerniersPaiements.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDerniersPaiements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDerniersPaiements.BackgroundColor = Color.White;
            dgvDerniersPaiements.BorderStyle = BorderStyle.None;
            dgvDerniersPaiements.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDerniersPaiements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDerniersPaiements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDerniersPaiements.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDerniersPaiements.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDerniersPaiements.Dock = DockStyle.Fill;
            dgvDerniersPaiements.EnableHeadersVisualStyles = false;
            dgvDerniersPaiements.GridColor = Color.White;
            dgvDerniersPaiements.Location = new Point(10, 10);
            dgvDerniersPaiements.MultiSelect = false;
            dgvDerniersPaiements.Name = "dgvDerniersPaiements";
            dgvDerniersPaiements.ReadOnly = true;
            dgvDerniersPaiements.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDerniersPaiements.RowHeadersVisible = false;
            dgvDerniersPaiements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDerniersPaiements.Size = new Size(662, 350);
            dgvDerniersPaiements.TabIndex = 13;
            // 
            // panel_rond3
            // 
            panel_rond3.BorderColor = Color.FromArgb(192, 192, 255);
            panel_rond3.BorderRadius = 10;
            panel_rond3.BorderThickness = 2;
            panel_rond3.Controls.Add(label2);
            panel_rond3.Controls.Add(chartEvolution);
            panel_rond3.Dock = DockStyle.Top;
            panel_rond3.ForeColor = Color.FromArgb(64, 64, 64);
            panel_rond3.GradientAngle = 90F;
            panel_rond3.GradientBottomColor = Color.White;
            panel_rond3.GradientTopColor = Color.White;
            panel_rond3.Location = new Point(10, 267);
            panel_rond3.Name = "panel_rond3";
            panel_rond3.Size = new Size(682, 208);
            panel_rond3.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(14, 8);
            label2.Name = "label2";
            label2.Size = new Size(367, 37);
            label2.TabIndex = 0;
            label2.Text = "Évolution des Encaissements";
            // 
            // chartEvolution
            // 
            chartEvolution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea2.Name = "ChartArea1";
            chartEvolution.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartEvolution.Legends.Add(legend2);
            chartEvolution.Location = new Point(17, 48);
            chartEvolution.Name = "chartEvolution";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartEvolution.Series.Add(series2);
            chartEvolution.Size = new Size(652, 149);
            chartEvolution.TabIndex = 31;
            chartEvolution.Text = "chart1";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(panel_rond1);
            flowLayoutPanel1.Controls.Add(panel_rond2);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(10, 10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(682, 257);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Name = "UC_Dashboard";
            Padding = new Padding(10);
            Size = new Size(739, 664);
            Load += UC_Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)chartSection).EndInit();
            panel_rond1.ResumeLayout(false);
            panel_rond1.PerformLayout();
            panel_rond2.ResumeLayout(false);
            panel_rond2.PerformLayout();
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDerniersPaiements).EndInit();
            panel_rond3.ResumeLayout(false);
            panel_rond3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartEvolution).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTotalEleves;
        private Label lblEncaisseJour;
        private Label lblEncaisseMois;
        private Label lblTauxRecouvrement;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSection;
        private imj_Tools.RJProgressBar progressTauxRecouvrement;
        private imj_Tools.RJProgressBar progressEleves;
        private imj_Tools.RJProgressBar progressEncaisseMois;
        private imj_Tools.Panel_rond panel_rond1;
        private Label label1;
        private imj_Tools.Panel_rond panel_rond2;
        private Label label4;
        private Panel panel1;
        private imj_Tools.Panel_rond panel_rond3;
        private Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEvolution;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Panel panel7;
        private DataGridView dgvDerniersPaiements;
    }
}
