namespace FINANCIERE_SCOLAIRE
{
    partial class UC_GestionEleves
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
            tableLayoutPanelBouton = new TableLayoutPanel();
            label5 = new Label();
            tabControlAnneAcademique = new TabControl();
            tabPageEleves = new TabPage();
            cmbFiltreClasse = new ComboBox();
            label7 = new Label();
            panel7 = new Panel();
            dgvEleves = new DataGridView();
            panel3 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            btnFicheEleve = new Button();
            btnNouvelEleve = new Button();
            txtRecherche = new TextBox();
            panel1.SuspendLayout();
            tableLayoutPanelBouton.SuspendLayout();
            tabControlAnneAcademique.SuspendLayout();
            tabPageEleves.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEleves).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(tableLayoutPanelBouton);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 0, 10, 0);
            panel1.Size = new Size(911, 47);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanelBouton
            // 
            tableLayoutPanelBouton.ColumnCount = 5;
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5328722F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.3367939F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.4901962F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.4555941F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.99873F));
            tableLayoutPanelBouton.Controls.Add(label5, 3, 0);
            tableLayoutPanelBouton.Dock = DockStyle.Fill;
            tableLayoutPanelBouton.Location = new Point(10, 0);
            tableLayoutPanelBouton.Name = "tableLayoutPanelBouton";
            tableLayoutPanelBouton.RowCount = 1;
            tableLayoutPanelBouton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBouton.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelBouton.Size = new Size(891, 47);
            tableLayoutPanelBouton.TabIndex = 28;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            tableLayoutPanelBouton.SetColumnSpan(label5, 2);
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 255, 255);
            label5.Location = new Point(576, 13);
            label5.Name = "label5";
            label5.Size = new Size(312, 21);
            label5.TabIndex = 19;
            label5.Text = "Gestion des Élèves et Inscriptions";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControlAnneAcademique
            // 
            tabControlAnneAcademique.Controls.Add(tabPageEleves);
            tabControlAnneAcademique.Dock = DockStyle.Fill;
            tabControlAnneAcademique.Location = new Point(2, 49);
            tabControlAnneAcademique.Name = "tabControlAnneAcademique";
            tabControlAnneAcademique.SelectedIndex = 0;
            tabControlAnneAcademique.Size = new Size(911, 419);
            tabControlAnneAcademique.TabIndex = 20;
            // 
            // tabPageEleves
            // 
            tabPageEleves.Controls.Add(cmbFiltreClasse);
            tabPageEleves.Controls.Add(label7);
            tabPageEleves.Controls.Add(panel7);
            tabPageEleves.Controls.Add(panel3);
            tabPageEleves.Controls.Add(label2);
            tabPageEleves.Controls.Add(panel2);
            tabPageEleves.Controls.Add(txtRecherche);
            tabPageEleves.ForeColor = Color.FromArgb(64, 64, 64);
            tabPageEleves.Location = new Point(4, 24);
            tabPageEleves.Name = "tabPageEleves";
            tabPageEleves.Padding = new Padding(3);
            tabPageEleves.Size = new Size(903, 391);
            tabPageEleves.TabIndex = 1;
            tabPageEleves.Text = "Gestion des Elèves";
            tabPageEleves.UseVisualStyleBackColor = true;
            // 
            // cmbFiltreClasse
            // 
            cmbFiltreClasse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFiltreClasse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltreClasse.Font = new Font("Segoe UI", 12F);
            cmbFiltreClasse.FormattingEnabled = true;
            cmbFiltreClasse.Location = new Point(611, 86);
            cmbFiltreClasse.Name = "cmbFiltreClasse";
            cmbFiltreClasse.Size = new Size(283, 29);
            cmbFiltreClasse.TabIndex = 13;
            cmbFiltreClasse.SelectedIndexChanged += cmbFiltreClasse_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(611, 68);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 14;
            label7.Text = "Filtre Classe";
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvEleves);
            panel7.Location = new Point(3, 147);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(897, 241);
            panel7.TabIndex = 29;
            // 
            // dgvEleves
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvEleves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEleves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEleves.BackgroundColor = Color.White;
            dgvEleves.BorderStyle = BorderStyle.None;
            dgvEleves.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvEleves.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEleves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEleves.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEleves.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEleves.Dock = DockStyle.Fill;
            dgvEleves.EnableHeadersVisualStyles = false;
            dgvEleves.GridColor = Color.White;
            dgvEleves.Location = new Point(10, 10);
            dgvEleves.MultiSelect = false;
            dgvEleves.Name = "dgvEleves";
            dgvEleves.ReadOnly = true;
            dgvEleves.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEleves.RowHeadersVisible = false;
            dgvEleves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEleves.Size = new Size(877, 221);
            dgvEleves.TabIndex = 13;
            dgvEleves.CellClick += dgvEleves_CellClick;
            dgvEleves.CellDoubleClick += dgvEleves_CellDoubleClick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(192, 192, 255);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(897, 1);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 68);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 12;
            label2.Text = "Recherche";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnFicheEleve);
            panel2.Controls.Add(btnNouvelEleve);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(897, 57);
            panel2.TabIndex = 0;
            // 
            // btnFicheEleve
            // 
            btnFicheEleve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFicheEleve.Location = new Point(115, 14);
            btnFicheEleve.Name = "btnFicheEleve";
            btnFicheEleve.Size = new Size(99, 34);
            btnFicheEleve.TabIndex = 0;
            btnFicheEleve.Text = "Fiche de l'élève";
            btnFicheEleve.UseVisualStyleBackColor = true;
            btnFicheEleve.Click += btnFicheEleve_Click;
            // 
            // btnNouvelEleve
            // 
            btnNouvelEleve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNouvelEleve.Location = new Point(6, 14);
            btnNouvelEleve.Name = "btnNouvelEleve";
            btnNouvelEleve.Size = new Size(99, 34);
            btnNouvelEleve.TabIndex = 0;
            btnNouvelEleve.Text = "Nouveau";
            btnNouvelEleve.UseVisualStyleBackColor = true;
            btnNouvelEleve.Click += btnNouvelEleve_Click;
            // 
            // txtRecherche
            // 
            txtRecherche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRecherche.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRecherche.Location = new Point(9, 86);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.Size = new Size(579, 29);
            txtRecherche.TabIndex = 11;
            txtRecherche.TextChanged += txtRecherche_TextChanged;
            // 
            // UC_GestionEleves
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlAnneAcademique);
            Controls.Add(panel1);
            Name = "UC_GestionEleves";
            Padding = new Padding(2, 2, 2, 10);
            Size = new Size(915, 478);
            Load += UC_GestionEleves_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanelBouton.ResumeLayout(false);
            tableLayoutPanelBouton.PerformLayout();
            tabControlAnneAcademique.ResumeLayout(false);
            tabPageEleves.ResumeLayout(false);
            tabPageEleves.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEleves).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanelBouton;
        private Label label5;
        private TabControl tabControlAnneAcademique;
        private TabPage tabPageEleves;
        private Panel panel2;
        private Panel panel3;
        private Button btnNouvelEleve;
        private Panel panel7;
        private DataGridView dgvEleves;
        private Label label2;
        private TextBox txtRecherche;
        private ComboBox cmbFiltreClasse;
        private Label label7;
        private Button btnFicheEleve;
    }
}
