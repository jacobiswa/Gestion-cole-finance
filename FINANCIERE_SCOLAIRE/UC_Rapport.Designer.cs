namespace FINANCIERE_SCOLAIRE
{
    partial class UC_Rapport
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            cboAnneeScolaire = new ComboBox();
            label1 = new Label();
            cboFrais = new ComboBox();
            lbl = new Label();
            lblTitreRapport = new Label();
            panel2 = new Panel();
            dtpJournalier = new DateTimePicker();
            dtpDebut = new DateTimePicker();
            dtpFin = new DateTimePicker();
            panel7 = new Panel();
            dgvRapports = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnChargerJournalier = new Button();
            btnChargerBilanPeriodique = new Button();
            btnChargerTaux = new Button();
            btnChargerAnnuel = new Button();
            btnExportPDF = new Button();
            btnExportExcel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRapports).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cboAnneeScolaire);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cboFrais);
            panel1.Controls.Add(lbl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(880, 72);
            panel1.TabIndex = 0;
            // 
            // cboAnneeScolaire
            // 
            cboAnneeScolaire.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboAnneeScolaire.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAnneeScolaire.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboAnneeScolaire.FormattingEnabled = true;
            cboAnneeScolaire.Location = new Point(680, 28);
            cboAnneeScolaire.Name = "cboAnneeScolaire";
            cboAnneeScolaire.Size = new Size(184, 29);
            cboAnneeScolaire.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(680, 10);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 4;
            label1.Text = " Annee Scolaire";
            // 
            // cboFrais
            // 
            cboFrais.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFrais.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFrais.FormattingEnabled = true;
            cboFrais.Location = new Point(13, 28);
            cboFrais.Name = "cboFrais";
            cboFrais.Size = new Size(411, 29);
            cboFrais.TabIndex = 3;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(13, 6);
            lbl.Name = "lbl";
            lbl.Size = new Size(31, 15);
            lbl.TabIndex = 4;
            lbl.Text = "Frais";
            // 
            // lblTitreRapport
            // 
            lblTitreRapport.AutoSize = true;
            lblTitreRapport.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitreRapport.ForeColor = Color.Teal;
            lblTitreRapport.Location = new Point(16, 155);
            lblTitreRapport.Name = "lblTitreRapport";
            lblTitreRapport.Size = new Size(116, 25);
            lblTitreRapport.TabIndex = 4;
            lblTitreRapport.Text = "Titre Rappor";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 72);
            panel2.Name = "panel2";
            panel2.Size = new Size(880, 1);
            panel2.TabIndex = 1;
            // 
            // dtpJournalier
            // 
            dtpJournalier.Location = new Point(13, 103);
            dtpJournalier.Name = "dtpJournalier";
            dtpJournalier.Size = new Size(200, 23);
            dtpJournalier.TabIndex = 2;
            // 
            // dtpDebut
            // 
            dtpDebut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDebut.Location = new Point(458, 103);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.Size = new Size(200, 23);
            dtpDebut.TabIndex = 2;
            // 
            // dtpFin
            // 
            dtpFin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFin.Location = new Point(664, 103);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvRapports);
            panel7.Location = new Point(13, 245);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(852, 160);
            panel7.TabIndex = 34;
            // 
            // dgvRapports
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvRapports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRapports.BackgroundColor = Color.White;
            dgvRapports.BorderStyle = BorderStyle.None;
            dgvRapports.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRapports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRapports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRapports.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRapports.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRapports.Dock = DockStyle.Fill;
            dgvRapports.EnableHeadersVisualStyles = false;
            dgvRapports.GridColor = Color.White;
            dgvRapports.Location = new Point(10, 10);
            dgvRapports.MultiSelect = false;
            dgvRapports.Name = "dgvRapports";
            dgvRapports.ReadOnly = true;
            dgvRapports.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRapports.RowHeadersVisible = false;
            dgvRapports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRapports.Size = new Size(832, 140);
            dgvRapports.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 85);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 4;
            label2.Text = "Date Journalier";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(458, 85);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 4;
            label3.Text = "Date Début";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(664, 85);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 4;
            label4.Text = "Date Fin";
            // 
            // btnChargerJournalier
            // 
            btnChargerJournalier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChargerJournalier.Location = new Point(3, 3);
            btnChargerJournalier.Name = "btnChargerJournalier";
            btnChargerJournalier.Size = new Size(135, 41);
            btnChargerJournalier.TabIndex = 35;
            btnChargerJournalier.Text = "RAPPORT JOURNALIER";
            btnChargerJournalier.UseVisualStyleBackColor = true;
            btnChargerJournalier.Click += btnChargerJournalier_Click;
            // 
            // btnChargerBilanPeriodique
            // 
            btnChargerBilanPeriodique.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChargerBilanPeriodique.Location = new Point(144, 3);
            btnChargerBilanPeriodique.Name = "btnChargerBilanPeriodique";
            btnChargerBilanPeriodique.Size = new Size(135, 41);
            btnChargerBilanPeriodique.TabIndex = 35;
            btnChargerBilanPeriodique.Text = "BILAN MENSUEL / TRIMESTRIEL";
            btnChargerBilanPeriodique.UseVisualStyleBackColor = true;
            btnChargerBilanPeriodique.Click += btnChargerBilanPeriodique_Click;
            // 
            // btnChargerTaux
            // 
            btnChargerTaux.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChargerTaux.Location = new Point(285, 3);
            btnChargerTaux.Name = "btnChargerTaux";
            btnChargerTaux.Size = new Size(135, 41);
            btnChargerTaux.TabIndex = 35;
            btnChargerTaux.Text = "ChargerTaux de recouvrement";
            btnChargerTaux.UseVisualStyleBackColor = true;
            btnChargerTaux.Click += btnChargerTaux_Click;
            // 
            // btnChargerAnnuel
            // 
            btnChargerAnnuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChargerAnnuel.Location = new Point(426, 3);
            btnChargerAnnuel.Name = "btnChargerAnnuel";
            btnChargerAnnuel.Size = new Size(135, 41);
            btnChargerAnnuel.TabIndex = 35;
            btnChargerAnnuel.Text = "SYNTHÈSE ANNUELLE";
            btnChargerAnnuel.UseVisualStyleBackColor = true;
            btnChargerAnnuel.Click += btnChargerAnnuel_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExportPDF.Location = new Point(567, 3);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(135, 41);
            btnExportPDF.TabIndex = 35;
            btnExportPDF.Text = " EXPORTATION PDF";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExportExcel.Location = new Point(708, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(140, 41);
            btnExportExcel.TabIndex = 35;
            btnExportExcel.Text = " EXPORTATION EXCEL";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(btnChargerJournalier, 0, 0);
            tableLayoutPanel1.Controls.Add(btnChargerBilanPeriodique, 1, 0);
            tableLayoutPanel1.Controls.Add(btnExportExcel, 5, 0);
            tableLayoutPanel1.Controls.Add(btnChargerTaux, 2, 0);
            tableLayoutPanel1.Controls.Add(btnExportPDF, 4, 0);
            tableLayoutPanel1.Controls.Add(btnChargerAnnuel, 3, 0);
            tableLayoutPanel1.Location = new Point(13, 192);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(851, 47);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // UC_Rapport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblTitreRapport);
            Controls.Add(panel7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpFin);
            Controls.Add(dtpDebut);
            Controls.Add(dtpJournalier);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(64, 64, 64);
            Name = "UC_Rapport";
            Size = new Size(880, 419);
            Load += UC_Rapport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRapports).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DateTimePicker dtpJournalier;
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private ComboBox cboAnneeScolaire;
        private Label label1;
        private ComboBox cboFrais;
        private Label lbl;
        private Label lblTitreRapport;
        private Panel panel7;
        private DataGridView dgvRapports;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnChargerJournalier;
        private Button btnChargerBilanPeriodique;
        private Button btnChargerTaux;
        private Button btnChargerAnnuel;
        private Button btnExportPDF;
        private Button btnExportExcel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
