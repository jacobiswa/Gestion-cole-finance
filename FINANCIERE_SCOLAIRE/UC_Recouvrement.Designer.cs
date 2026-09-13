namespace FINANCIERE_SCOLAIRE
{
    partial class UC_Recouvrement
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
            btnExportPDF = new Button();
            label5 = new Label();
            cboFrais = new ComboBox();
            cboSection = new ComboBox();
            cboClasse = new ComboBox();
            cboMois = new ComboBox();
            cboStatut = new ComboBox();
            dgvRecouvrement = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            btnFiltrer = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecouvrement).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(btnExportPDF);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 86);
            panel1.TabIndex = 0;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPDF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportPDF.Location = new Point(722, 11);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(124, 62);
            btnExportPDF.TabIndex = 33;
            btnExportPDF.Text = "Export PDF";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 255, 255);
            label5.Location = new Point(10, 13);
            label5.Name = "label5";
            label5.Size = new Size(575, 45);
            label5.TabIndex = 20;
            label5.Text = "Recouvrement (Gestion des Impayés)";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboFrais
            // 
            cboFrais.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFrais.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFrais.ForeColor = Color.Teal;
            cboFrais.FormattingEnabled = true;
            cboFrais.Location = new Point(14, 27);
            cboFrais.Name = "cboFrais";
            cboFrais.Size = new Size(298, 29);
            cboFrais.TabIndex = 1;
            // 
            // cboSection
            // 
            cboSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboSection.ForeColor = Color.Teal;
            cboSection.FormattingEnabled = true;
            cboSection.Location = new Point(318, 27);
            cboSection.Name = "cboSection";
            cboSection.Size = new Size(201, 29);
            cboSection.TabIndex = 1;
            cboSection.SelectedIndexChanged += cboSection_SelectedIndexChanged;
            // 
            // cboClasse
            // 
            cboClasse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboClasse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClasse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboClasse.ForeColor = Color.Teal;
            cboClasse.FormattingEnabled = true;
            cboClasse.Location = new Point(525, 27);
            cboClasse.Name = "cboClasse";
            cboClasse.Size = new Size(321, 29);
            cboClasse.TabIndex = 1;
            // 
            // cboMois
            // 
            cboMois.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMois.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboMois.ForeColor = Color.Teal;
            cboMois.FormattingEnabled = true;
            cboMois.Location = new Point(318, 80);
            cboMois.Name = "cboMois";
            cboMois.Size = new Size(201, 29);
            cboMois.TabIndex = 1;
            // 
            // cboStatut
            // 
            cboStatut.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboStatut.ForeColor = Color.Teal;
            cboStatut.FormattingEnabled = true;
            cboStatut.Location = new Point(14, 80);
            cboStatut.Name = "cboStatut";
            cboStatut.Size = new Size(298, 29);
            cboStatut.TabIndex = 1;
            // 
            // dgvRecouvrement
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvRecouvrement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecouvrement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRecouvrement.BackgroundColor = Color.White;
            dgvRecouvrement.BorderStyle = BorderStyle.None;
            dgvRecouvrement.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRecouvrement.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRecouvrement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRecouvrement.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Teal;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRecouvrement.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRecouvrement.Dock = DockStyle.Fill;
            dgvRecouvrement.EnableHeadersVisualStyles = false;
            dgvRecouvrement.GridColor = Color.White;
            dgvRecouvrement.Location = new Point(10, 10);
            dgvRecouvrement.MultiSelect = false;
            dgvRecouvrement.Name = "dgvRecouvrement";
            dgvRecouvrement.ReadOnly = true;
            dgvRecouvrement.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRecouvrement.RowHeadersVisible = false;
            dgvRecouvrement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecouvrement.Size = new Size(835, 190);
            dgvRecouvrement.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 8);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 32;
            label1.Text = "Frais";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 8);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 32;
            label2.Text = "Section";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(525, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 32;
            label3.Text = "Classe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 61);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 32;
            label4.Text = "Mois";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 62);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 32;
            label6.Text = "Statut";
            // 
            // btnFiltrer
            // 
            btnFiltrer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrer.ForeColor = Color.FromArgb(0, 64, 64);
            btnFiltrer.Location = new Point(525, 61);
            btnFiltrer.Name = "btnFiltrer";
            btnFiltrer.Size = new Size(175, 62);
            btnFiltrer.TabIndex = 33;
            btnFiltrer.Text = "Filtrer";
            btnFiltrer.UseVisualStyleBackColor = true;
            btnFiltrer.Click += btnFiltrer_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(cboFrais);
            panel2.Controls.Add(btnFiltrer);
            panel2.Controls.Add(cboSection);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cboClasse);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(cboMois);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cboStatut);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = Color.Gray;
            panel2.Location = new Point(5, 91);
            panel2.Name = "panel2";
            panel2.Size = new Size(855, 136);
            panel2.TabIndex = 34;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(5, 227);
            panel3.Name = "panel3";
            panel3.Size = new Size(855, 1);
            panel3.TabIndex = 35;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(dgvRecouvrement);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(5, 228);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(855, 210);
            panel4.TabIndex = 36;
            // 
            // UC_Recouvrement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_Recouvrement";
            Padding = new Padding(5, 5, 5, 10);
            Size = new Size(865, 448);
            Load += UC_Recouvrement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecouvrement).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cboFrais;
        private ComboBox cboSection;
        private ComboBox cboClasse;
        private ComboBox cboMois;
        private ComboBox cboStatut;
        private DataGridView dgvRecouvrement;
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Button btnFiltrer;
        private Button btnExportPDF;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}
