namespace FINANCIERE_SCOLAIRE
{
    partial class UC_User
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel4 = new Panel();
            btnSupprimer = new Button();
            btnNouveau = new Button();
            txtNomComplet = new TextBox();
            txtNomUtilisateur = new TextBox();
            btnReinitialiserMdp = new Button();
            label3 = new Label();
            btnEnregistrer = new Button();
            cboRole = new ComboBox();
            label8 = new Label();
            label1 = new Label();
            txtMotDePasse = new TextBox();
            label2 = new Label();
            label4 = new Label();
            btnFiltrerLogs = new Button();
            dtpLogDebut = new DateTimePicker();
            dtpLogFin = new DateTimePicker();
            label7 = new Label();
            label6 = new Label();
            panel2 = new Panel();
            panel7 = new Panel();
            dgvUsers = new DataGridView();
            panel3 = new Panel();
            dgvLogs = new DataGridView();
            label5 = new Label();
            txtRechercheLog = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(btnSupprimer);
            panel1.Controls.Add(btnNouveau);
            panel1.Controls.Add(txtNomComplet);
            panel1.Controls.Add(txtNomUtilisateur);
            panel1.Controls.Add(btnReinitialiserMdp);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnEnregistrer);
            panel1.Controls.Add(cboRole);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtMotDePasse);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(879, 290);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 289);
            panel4.Name = "panel4";
            panel4.Size = new Size(879, 1);
            panel4.TabIndex = 42;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSupprimer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupprimer.Location = new Point(712, 102);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(139, 36);
            btnSupprimer.TabIndex = 37;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnNouveau
            // 
            btnNouveau.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNouveau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNouveau.Location = new Point(712, 59);
            btnNouveau.Name = "btnNouveau";
            btnNouveau.Size = new Size(139, 36);
            btnNouveau.TabIndex = 37;
            btnNouveau.Text = "Nouveau";
            btnNouveau.UseVisualStyleBackColor = true;
            btnNouveau.Click += btnNouveau_Click;
            // 
            // txtNomComplet
            // 
            txtNomComplet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNomComplet.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomComplet.Location = new Point(200, 87);
            txtNomComplet.Name = "txtNomComplet";
            txtNomComplet.Size = new Size(458, 29);
            txtNomComplet.TabIndex = 36;
            // 
            // txtNomUtilisateur
            // 
            txtNomUtilisateur.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNomUtilisateur.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomUtilisateur.Location = new Point(200, 129);
            txtNomUtilisateur.Name = "txtNomUtilisateur";
            txtNomUtilisateur.Size = new Size(458, 29);
            txtNomUtilisateur.TabIndex = 36;
            // 
            // btnReinitialiserMdp
            // 
            btnReinitialiserMdp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReinitialiserMdp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReinitialiserMdp.Location = new Point(712, 142);
            btnReinitialiserMdp.Name = "btnReinitialiserMdp";
            btnReinitialiserMdp.Size = new Size(139, 36);
            btnReinitialiserMdp.TabIndex = 37;
            btnReinitialiserMdp.Text = "Reinitialiser Mdp";
            btnReinitialiserMdp.UseVisualStyleBackColor = true;
            btnReinitialiserMdp.Click += btnReinitialiserMdp_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 137);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 4;
            label3.Text = " Nom Utilisateur";
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEnregistrer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnregistrer.Location = new Point(712, 184);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(139, 43);
            btnEnregistrer.TabIndex = 37;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // cboRole
            // 
            cboRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(200, 215);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(247, 29);
            cboRole.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(192, 255, 255);
            label8.Location = new Point(20, 11);
            label8.Name = "label8";
            label8.Size = new Size(340, 40);
            label8.TabIndex = 4;
            label8.Text = "Gestion des Utilisateurs";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 223);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 4;
            label1.Text = "Role";
            // 
            // txtMotDePasse
            // 
            txtMotDePasse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMotDePasse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMotDePasse.Location = new Point(200, 176);
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.Size = new Size(458, 29);
            txtMotDePasse.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 95);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 4;
            label2.Text = "Nom Complet";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(111, 184);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 4;
            label4.Text = "Mot De Passe";
            // 
            // btnFiltrerLogs
            // 
            btnFiltrerLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFiltrerLogs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrerLogs.Location = new Point(644, 325);
            btnFiltrerLogs.Name = "btnFiltrerLogs";
            btnFiltrerLogs.Size = new Size(225, 36);
            btnFiltrerLogs.TabIndex = 37;
            btnFiltrerLogs.Text = "JOURNAL D'AUDIT (LOGS)";
            btnFiltrerLogs.UseVisualStyleBackColor = true;
            btnFiltrerLogs.Click += btnFiltrerLogs_Click;
            // 
            // dtpLogDebut
            // 
            dtpLogDebut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpLogDebut.Format = DateTimePickerFormat.Short;
            dtpLogDebut.Location = new Point(419, 338);
            dtpLogDebut.Name = "dtpLogDebut";
            dtpLogDebut.Size = new Size(100, 23);
            dtpLogDebut.TabIndex = 2;
            // 
            // dtpLogFin
            // 
            dtpLogFin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpLogFin.Format = DateTimePickerFormat.Short;
            dtpLogFin.Location = new Point(525, 338);
            dtpLogFin.Name = "dtpLogFin";
            dtpLogFin.Size = new Size(100, 23);
            dtpLogFin.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(525, 320);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 4;
            label7.Text = "Date Fin";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(419, 320);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 4;
            label6.Text = "Date Debut";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(5, 295);
            panel2.Name = "panel2";
            panel2.Size = new Size(879, 1);
            panel2.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvUsers);
            panel7.Location = new Point(3, 3);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(417, 121);
            panel7.TabIndex = 35;
            // 
            // dgvUsers
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.White;
            dgvUsers.Location = new Point(10, 10);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(397, 101);
            dgvUsers.TabIndex = 13;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dgvLogs);
            panel3.Location = new Point(426, 3);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(418, 121);
            panel3.TabIndex = 35;
            // 
            // dgvLogs
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLogs.BackgroundColor = Color.White;
            dgvLogs.BorderStyle = BorderStyle.None;
            dgvLogs.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvLogs.ColumnHeadersHeight = 42;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvLogs.DefaultCellStyle = dataGridViewCellStyle6;
            dgvLogs.Dock = DockStyle.Fill;
            dgvLogs.EnableHeadersVisualStyles = false;
            dgvLogs.GridColor = Color.White;
            dgvLogs.Location = new Point(10, 10);
            dgvLogs.MultiSelect = false;
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(398, 101);
            dgvLogs.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 311);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 4;
            label5.Text = "Recherche Log";
            // 
            // txtRechercheLog
            // 
            txtRechercheLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRechercheLog.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRechercheLog.Location = new Point(25, 328);
            txtRechercheLog.Name = "txtRechercheLog";
            txtRechercheLog.Size = new Size(388, 33);
            txtRechercheLog.TabIndex = 36;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel7, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Location = new Point(22, 367);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(847, 127);
            tableLayoutPanel1.TabIndex = 38;
            // 
            // UC_User
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnFiltrerLogs);
            Controls.Add(dtpLogDebut);
            Controls.Add(txtRechercheLog);
            Controls.Add(dtpLogFin);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(label7);
            ForeColor = Color.FromArgb(64, 64, 64);
            Name = "UC_User";
            Padding = new Padding(5, 5, 5, 10);
            Size = new Size(889, 507);
            Load += UC_User_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DateTimePicker dtpLogDebut;
        private DateTimePicker dtpLogFin;
        private ComboBox cboRole;
        private Label label1;
        private Label label2;
        private Panel panel7;
        private DataGridView dgvUsers;
        private TextBox txtNomComplet;
        private TextBox txtNomUtilisateur;
        private Label label3;
        private Label label4;
        private TextBox txtMotDePasse;
        private Button btnEnregistrer;
        private Button btnReinitialiserMdp;
        private Button btnSupprimer;
        private Button btnNouveau;
        private Button btnFiltrerLogs;
        private Panel panel3;
        private DataGridView dgvLogs;
        private Label label5;
        private TextBox txtRechercheLog;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label6;
        private Label label8;
        private Label label7;
        private Panel panel4;
    }
}
