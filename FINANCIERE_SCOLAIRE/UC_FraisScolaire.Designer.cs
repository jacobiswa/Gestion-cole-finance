namespace FINANCIERE_SCOLAIRE
{
    partial class UC_FraisScolaire
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
            btnNouveau = new Button();
            label5 = new Label();
            btnSuprimmer = new Button();
            btnEnregistrer = new Button();
            pnlForm = new Panel();
            txtMontant = new TextBox();
            label4 = new Label();
            txtLibelleFrais = new TextBox();
            label3 = new Label();
            label2 = new Label();
            cmbDevise = new ComboBox();
            cmbAnneeScolaire = new ComboBox();
            label7 = new Label();
            label1 = new Label();
            label6 = new Label();
            cmbClasse = new ComboBox();
            cmbEcheance = new ComboBox();
            panel3 = new Panel();
            dgvFrais = new DataGridView();
            panel4 = new Panel();
            panel7 = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanelBouton.SuspendLayout();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFrais).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(tableLayoutPanelBouton);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 0, 10, 0);
            panel1.Size = new Size(833, 47);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanelBouton
            // 
            tableLayoutPanelBouton.ColumnCount = 5;
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5328722F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.5625763F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.4981546F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.241082F));
            tableLayoutPanelBouton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.06642F));
            tableLayoutPanelBouton.Controls.Add(btnNouveau, 0, 0);
            tableLayoutPanelBouton.Controls.Add(label5, 4, 0);
            tableLayoutPanelBouton.Controls.Add(btnSuprimmer, 2, 0);
            tableLayoutPanelBouton.Controls.Add(btnEnregistrer, 1, 0);
            tableLayoutPanelBouton.Dock = DockStyle.Fill;
            tableLayoutPanelBouton.ForeColor = Color.FromArgb(0, 0, 192);
            tableLayoutPanelBouton.Location = new Point(10, 0);
            tableLayoutPanelBouton.Name = "tableLayoutPanelBouton";
            tableLayoutPanelBouton.RowCount = 1;
            tableLayoutPanelBouton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBouton.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelBouton.Size = new Size(813, 47);
            tableLayoutPanelBouton.TabIndex = 28;
            // 
            // btnNouveau
            // 
            btnNouveau.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNouveau.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnNouveau.Location = new Point(11, 3);
            btnNouveau.Name = "btnNouveau";
            btnNouveau.Size = new Size(104, 38);
            btnNouveau.TabIndex = 15;
            btnNouveau.Text = "Nouveau";
            btnNouveau.UseVisualStyleBackColor = true;
            btnNouveau.Click += btnNouveau_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 255, 255);
            label5.Location = new Point(473, 11);
            label5.Name = "label5";
            label5.Size = new Size(337, 25);
            label5.TabIndex = 19;
            label5.Text = "Configuration des Frais Scolaires";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSuprimmer
            // 
            btnSuprimmer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSuprimmer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSuprimmer.ForeColor = Color.Red;
            btnSuprimmer.Location = new Point(280, 3);
            btnSuprimmer.Name = "btnSuprimmer";
            btnSuprimmer.Size = new Size(120, 38);
            btnSuprimmer.TabIndex = 15;
            btnSuprimmer.Text = "Supprimer";
            btnSuprimmer.UseVisualStyleBackColor = true;
            btnSuprimmer.Click += btnSuprimmer_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEnregistrer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEnregistrer.ForeColor = Color.Black;
            btnEnregistrer.Location = new Point(122, 3);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(152, 41);
            btnEnregistrer.TabIndex = 15;
            btnEnregistrer.Text = "Enregistre";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistreFrais_Click;
            // 
            // pnlForm
            // 
            pnlForm.BackColor = SystemColors.Control;
            pnlForm.Controls.Add(txtMontant);
            pnlForm.Controls.Add(label4);
            pnlForm.Controls.Add(txtLibelleFrais);
            pnlForm.Controls.Add(label3);
            pnlForm.Controls.Add(label2);
            pnlForm.Controls.Add(cmbDevise);
            pnlForm.Controls.Add(cmbAnneeScolaire);
            pnlForm.Controls.Add(label7);
            pnlForm.Controls.Add(label1);
            pnlForm.Controls.Add(label6);
            pnlForm.Controls.Add(cmbClasse);
            pnlForm.Controls.Add(cmbEcheance);
            pnlForm.Dock = DockStyle.Top;
            pnlForm.ForeColor = Color.FromArgb(64, 64, 64);
            pnlForm.Location = new Point(5, 52);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(833, 197);
            pnlForm.TabIndex = 3;
            // 
            // txtMontant
            // 
            txtMontant.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMontant.BackColor = Color.Black;
            txtMontant.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMontant.ForeColor = Color.White;
            txtMontant.Location = new Point(79, 33);
            txtMontant.Multiline = true;
            txtMontant.Name = "txtMontant";
            txtMontant.Size = new Size(292, 49);
            txtMontant.TabIndex = 14;
            txtMontant.KeyPress += txtMontant_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(393, 134);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 31;
            label4.Text = "Annee Scolaire";
            // 
            // txtLibelleFrais
            // 
            txtLibelleFrais.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLibelleFrais.BackColor = Color.FromArgb(19, 32, 45);
            txtLibelleFrais.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLibelleFrais.ForeColor = Color.White;
            txtLibelleFrais.Location = new Point(393, 33);
            txtLibelleFrais.Multiline = true;
            txtLibelleFrais.Name = "txtLibelleFrais";
            txtLibelleFrais.Size = new Size(329, 49);
            txtLibelleFrais.TabIndex = 14;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(393, 85);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 31;
            label3.Text = "Devise";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 134);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 31;
            label2.Text = "Classe";
            // 
            // cmbDevise
            // 
            cmbDevise.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbDevise.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDevise.Font = new Font("Segoe UI", 12F);
            cmbDevise.ForeColor = Color.Black;
            cmbDevise.FormattingEnabled = true;
            cmbDevise.Location = new Point(393, 102);
            cmbDevise.Name = "cmbDevise";
            cmbDevise.Size = new Size(123, 29);
            cmbDevise.TabIndex = 15;
            // 
            // cmbAnneeScolaire
            // 
            cmbAnneeScolaire.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbAnneeScolaire.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnneeScolaire.Font = new Font("Segoe UI", 12F);
            cmbAnneeScolaire.ForeColor = Color.Black;
            cmbAnneeScolaire.FormattingEnabled = true;
            cmbAnneeScolaire.Location = new Point(393, 152);
            cmbAnneeScolaire.Name = "cmbAnneeScolaire";
            cmbAnneeScolaire.Size = new Size(123, 29);
            cmbAnneeScolaire.TabIndex = 15;
            cmbAnneeScolaire.SelectedIndexChanged += cmbAnneeScolaire_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(393, 15);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 31;
            label7.Text = "Libelle Frais";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 85);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 31;
            label1.Text = "Echeance";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(79, 15);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 31;
            label6.Text = "Montant";
            // 
            // cmbClasse
            // 
            cmbClasse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbClasse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasse.Font = new Font("Segoe UI", 12F);
            cmbClasse.ForeColor = Color.Black;
            cmbClasse.FormattingEnabled = true;
            cmbClasse.Location = new Point(79, 152);
            cmbClasse.Name = "cmbClasse";
            cmbClasse.Size = new Size(292, 29);
            cmbClasse.TabIndex = 15;
            // 
            // cmbEcheance
            // 
            cmbEcheance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbEcheance.Font = new Font("Segoe UI", 12F);
            cmbEcheance.ForeColor = Color.Black;
            cmbEcheance.FormattingEnabled = true;
            cmbEcheance.Location = new Point(79, 103);
            cmbEcheance.Name = "cmbEcheance";
            cmbEcheance.Size = new Size(292, 29);
            cmbEcheance.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(5, 249);
            panel3.Name = "panel3";
            panel3.Size = new Size(833, 1);
            panel3.TabIndex = 4;
            // 
            // dgvFrais
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvFrais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvFrais.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvFrais.BackgroundColor = Color.White;
            dgvFrais.BorderStyle = BorderStyle.None;
            dgvFrais.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvFrais.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvFrais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFrais.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Teal;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvFrais.DefaultCellStyle = dataGridViewCellStyle3;
            dgvFrais.Dock = DockStyle.Fill;
            dgvFrais.EnableHeadersVisualStyles = false;
            dgvFrais.GridColor = Color.White;
            dgvFrais.Location = new Point(10, 10);
            dgvFrais.MultiSelect = false;
            dgvFrais.Name = "dgvFrais";
            dgvFrais.ReadOnly = true;
            dgvFrais.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFrais.RowHeadersVisible = false;
            dgvFrais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFrais.Size = new Size(813, 148);
            dgvFrais.TabIndex = 13;
            dgvFrais.CellClick += dgvFrais_CellClick;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 64, 64);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(5, 250);
            panel4.Name = "panel4";
            panel4.Size = new Size(833, 1);
            panel4.TabIndex = 32;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvFrais);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(5, 251);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(833, 168);
            panel7.TabIndex = 33;
            // 
            // UC_FraisScolaire
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel7);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(pnlForm);
            Controls.Add(panel1);
            ForeColor = Color.Teal;
            Name = "UC_FraisScolaire";
            Padding = new Padding(5, 5, 5, 10);
            Size = new Size(843, 429);
            Load += UC_FraisScolaire_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanelBouton.ResumeLayout(false);
            tableLayoutPanelBouton.PerformLayout();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFrais).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanelBouton;
        private Label label5;
        private Panel pnlForm;
        private Panel panel3;
        private TextBox txtMontant;
        private ComboBox cmbAnneeScolaire;
        private ComboBox cmbClasse;
        private ComboBox cmbDevise;
        private ComboBox cmbEcheance;
        private DataGridView dgvFrais;
        private Button btnEnregistrer;
        private Button btnSuprimmer;
        private Button btnNouveau;
        private TextBox txtLibelleFrais;
        private Label label7;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel4;
        private Panel panel7;
    }
}
