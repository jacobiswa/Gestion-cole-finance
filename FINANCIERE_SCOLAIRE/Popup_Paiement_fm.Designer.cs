namespace FINANCIERE_SCOLAIRE
{
    partial class Popup_Paiement_fm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup_Paiement_fm));
            panel1 = new Panel();
            label5 = new Label();
            cmbFraisMotif = new ComboBox();
            label6 = new Label();
            panel2 = new Panel();
            pnlDroit = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblMatricule = new Label();
            lblNomEleve = new Label();
            lblCategorie = new Label();
            lblTotalDu = new Label();
            lblResteAPayer = new Label();
            lblDevise = new Label();
            lblMoisConcerne = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            panel7 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            txtObservations = new TextBox();
            label4 = new Label();
            cmbModePaiement = new ComboBox();
            txtMontantVerses = new TextBox();
            label1 = new Label();
            resizePanel1 = new imj_Tools.ResizePanel();
            pnlCentre = new Panel();
            pnlDgv = new Panel();
            dgvResultatEleves = new DataGridView();
            panel6 = new Panel();
            panel5 = new Panel();
            btnValiderPaiement = new Button();
            panel3 = new Panel();
            txtRechercheEleve = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            pnlDroit.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            pnlCentre.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultatEleves).BeginInit();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 42, 59);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(921, 47);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(224, 224, 224);
            label5.Location = new Point(12, 8);
            label5.Name = "label5";
            label5.Size = new Size(255, 21);
            label5.TabIndex = 22;
            label5.Text = "Caisse, Paiements et Facturation";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbFraisMotif
            // 
            cmbFraisMotif.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbFraisMotif.BackColor = Color.FromArgb(64, 64, 64);
            cmbFraisMotif.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFraisMotif.FlatStyle = FlatStyle.Flat;
            cmbFraisMotif.Font = new Font("Segoe UI", 12F);
            cmbFraisMotif.ForeColor = Color.White;
            cmbFraisMotif.FormattingEnabled = true;
            cmbFraisMotif.Location = new Point(13, 99);
            cmbFraisMotif.Name = "cmbFraisMotif";
            cmbFraisMotif.Size = new Size(411, 29);
            cmbFraisMotif.TabIndex = 21;
            cmbFraisMotif.SelectedIndexChanged += cmbFraisMotif_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 81);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 20;
            label6.Text = "Frais Motif";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(19, 32, 45);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(921, 1);
            panel2.TabIndex = 1;
            // 
            // pnlDroit
            // 
            pnlDroit.Controls.Add(tableLayoutPanel1);
            pnlDroit.Controls.Add(panel7);
            pnlDroit.Controls.Add(panel4);
            pnlDroit.Dock = DockStyle.Right;
            pnlDroit.Location = new Point(472, 48);
            pnlDroit.Name = "pnlDroit";
            pnlDroit.Padding = new Padding(5, 5, 5, 10);
            pnlDroit.Size = new Size(449, 448);
            pnlDroit.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.6575336F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.34247F));
            tableLayoutPanel1.Controls.Add(lblMatricule, 1, 0);
            tableLayoutPanel1.Controls.Add(lblNomEleve, 1, 1);
            tableLayoutPanel1.Controls.Add(lblCategorie, 1, 2);
            tableLayoutPanel1.Controls.Add(lblTotalDu, 1, 3);
            tableLayoutPanel1.Controls.Add(lblResteAPayer, 1, 4);
            tableLayoutPanel1.Controls.Add(lblDevise, 1, 5);
            tableLayoutPanel1.Controls.Add(lblMoisConcerne, 1, 6);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label8, 0, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(label10, 0, 3);
            tableLayoutPanel1.Controls.Add(label11, 0, 2);
            tableLayoutPanel1.Controls.Add(label12, 0, 1);
            tableLayoutPanel1.Controls.Add(label13, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = Color.FromArgb(224, 224, 224);
            tableLayoutPanel1.Location = new Point(5, 193);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.Size = new Size(439, 245);
            tableLayoutPanel1.TabIndex = 32;
            // 
            // lblMatricule
            // 
            lblMatricule.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblMatricule.AutoSize = true;
            lblMatricule.Font = new Font("Segoe UI", 12F);
            lblMatricule.Location = new Point(112, 7);
            lblMatricule.Name = "lblMatricule";
            lblMatricule.Size = new Size(323, 21);
            lblMatricule.TabIndex = 16;
            lblMatricule.Text = "Matricule";
            lblMatricule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNomEleve
            // 
            lblNomEleve.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblNomEleve.AutoSize = true;
            lblNomEleve.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNomEleve.ForeColor = Color.White;
            lblNomEleve.Location = new Point(112, 41);
            lblNomEleve.Name = "lblNomEleve";
            lblNomEleve.Size = new Size(323, 21);
            lblNomEleve.TabIndex = 16;
            lblNomEleve.Text = "Nom Eleve";
            lblNomEleve.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategorie
            // 
            lblCategorie.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCategorie.AutoSize = true;
            lblCategorie.Font = new Font("Segoe UI", 11.25F);
            lblCategorie.ForeColor = Color.FromArgb(255, 192, 128);
            lblCategorie.Location = new Point(112, 75);
            lblCategorie.Name = "lblCategorie";
            lblCategorie.Size = new Size(323, 20);
            lblCategorie.TabIndex = 16;
            lblCategorie.Text = "Categorie";
            lblCategorie.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalDu
            // 
            lblTotalDu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTotalDu.AutoSize = true;
            lblTotalDu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTotalDu.ForeColor = Color.Cyan;
            lblTotalDu.Location = new Point(112, 107);
            lblTotalDu.Name = "lblTotalDu";
            lblTotalDu.Size = new Size(323, 25);
            lblTotalDu.TabIndex = 16;
            lblTotalDu.Text = "Total Du";
            lblTotalDu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblResteAPayer
            // 
            lblResteAPayer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblResteAPayer.AutoSize = true;
            lblResteAPayer.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblResteAPayer.ForeColor = Color.FromArgb(255, 128, 128);
            lblResteAPayer.Location = new Point(112, 141);
            lblResteAPayer.Name = "lblResteAPayer";
            lblResteAPayer.Size = new Size(323, 25);
            lblResteAPayer.TabIndex = 16;
            lblResteAPayer.Text = "Reste A Payer";
            lblResteAPayer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDevise
            // 
            lblDevise.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDevise.AutoSize = true;
            lblDevise.Font = new Font("Segoe UI", 11.25F);
            lblDevise.Location = new Point(112, 177);
            lblDevise.Name = "lblDevise";
            lblDevise.Size = new Size(323, 20);
            lblDevise.TabIndex = 16;
            lblDevise.Text = "Devise";
            lblDevise.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMoisConcerne
            // 
            lblMoisConcerne.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblMoisConcerne.AutoSize = true;
            lblMoisConcerne.Font = new Font("Segoe UI", 11.25F);
            lblMoisConcerne.Location = new Point(112, 214);
            lblMoisConcerne.Name = "lblMoisConcerne";
            lblMoisConcerne.Size = new Size(323, 20);
            lblMoisConcerne.TabIndex = 16;
            lblMoisConcerne.Text = "Mois Concerne";
            lblMoisConcerne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(4, 216);
            label7.Name = "label7";
            label7.Size = new Size(101, 17);
            label7.TabIndex = 16;
            label7.Text = "Mois Concerne";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(4, 179);
            label8.Name = "label8";
            label8.Size = new Size(101, 17);
            label8.TabIndex = 16;
            label8.Text = "Devise";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(4, 145);
            label9.Name = "label9";
            label9.Size = new Size(101, 17);
            label9.TabIndex = 16;
            label9.Text = "Reste A Payer";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(4, 111);
            label10.Name = "label10";
            label10.Size = new Size(101, 17);
            label10.TabIndex = 16;
            label10.Text = "Total Du";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.ForeColor = Color.Gray;
            label11.Location = new Point(4, 77);
            label11.Name = "label11";
            label11.Size = new Size(101, 17);
            label11.TabIndex = 16;
            label11.Text = "Categorie";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F);
            label12.ForeColor = Color.Gray;
            label12.Location = new Point(4, 43);
            label12.Name = "label12";
            label12.Size = new Size(101, 17);
            label12.TabIndex = 16;
            label12.Text = "Nom Eleve";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F);
            label13.ForeColor = Color.Gray;
            label13.Location = new Point(4, 9);
            label13.Name = "label13";
            label13.Size = new Size(101, 17);
            label13.TabIndex = 16;
            label13.Text = "Matricule";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(19, 32, 45);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(5, 192);
            panel7.Name = "panel7";
            panel7.Size = new Size(439, 1);
            panel7.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Blue;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(cmbFraisMotif);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtObservations);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(cmbModePaiement);
            panel4.Controls.Add(txtMontantVerses);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(5, 5);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(439, 187);
            panel4.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 131);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 23;
            label3.Text = "Observations";
            // 
            // txtObservations
            // 
            txtObservations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservations.BackColor = Color.White;
            txtObservations.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtObservations.ForeColor = Color.Navy;
            txtObservations.Location = new Point(13, 149);
            txtObservations.Name = "txtObservations";
            txtObservations.Size = new Size(254, 29);
            txtObservations.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(242, 131);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 18;
            label4.Text = "Mode Paiement";
            // 
            // cmbModePaiement
            // 
            cmbModePaiement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbModePaiement.BackColor = Color.White;
            cmbModePaiement.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModePaiement.FlatStyle = FlatStyle.Flat;
            cmbModePaiement.Font = new Font("Segoe UI", 12F);
            cmbModePaiement.ForeColor = Color.Navy;
            cmbModePaiement.FormattingEnabled = true;
            cmbModePaiement.Location = new Point(273, 149);
            cmbModePaiement.Name = "cmbModePaiement";
            cmbModePaiement.Size = new Size(153, 29);
            cmbModePaiement.TabIndex = 19;
            // 
            // txtMontantVerses
            // 
            txtMontantVerses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMontantVerses.BackColor = Color.Black;
            txtMontantVerses.BorderStyle = BorderStyle.FixedSingle;
            txtMontantVerses.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMontantVerses.ForeColor = Color.White;
            txtMontantVerses.Location = new Point(13, 22);
            txtMontantVerses.Name = "txtMontantVerses";
            txtMontantVerses.Size = new Size(413, 50);
            txtMontantVerses.TabIndex = 17;
            txtMontantVerses.KeyPress += txtMontantVerses_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 4);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 18;
            label1.Text = "Montant Verses";
            // 
            // resizePanel1
            // 
            resizePanel1.BackColor = Color.FromArgb(19, 32, 45);
            resizePanel1.Direction = imj_Tools.ResizePanel.ResizeDirection.Right;
            resizePanel1.Dock = DockStyle.Right;
            resizePanel1.Location = new Point(467, 48);
            resizePanel1.Name = "resizePanel1";
            resizePanel1.Size = new Size(5, 448);
            resizePanel1.TabIndex = 3;
            resizePanel1.TargetPanel = pnlDroit;
            // 
            // pnlCentre
            // 
            pnlCentre.Controls.Add(pnlDgv);
            pnlCentre.Controls.Add(panel6);
            pnlCentre.Controls.Add(panel5);
            pnlCentre.Controls.Add(panel3);
            pnlCentre.Dock = DockStyle.Fill;
            pnlCentre.Location = new Point(0, 48);
            pnlCentre.Name = "pnlCentre";
            pnlCentre.Padding = new Padding(5, 5, 5, 10);
            pnlCentre.Size = new Size(467, 448);
            pnlCentre.TabIndex = 4;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.Transparent;
            pnlDgv.Controls.Add(dgvResultatEleves);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(5, 71);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(10);
            pnlDgv.Size = new Size(457, 296);
            pnlDgv.TabIndex = 34;
            // 
            // dgvResultatEleves
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(29, 49, 68);
            dataGridViewCellStyle1.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(39, 66, 90);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(255, 128, 0);
            dgvResultatEleves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvResultatEleves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResultatEleves.BackgroundColor = Color.FromArgb(29, 49, 68);
            dgvResultatEleves.BorderStyle = BorderStyle.None;
            dgvResultatEleves.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvResultatEleves.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionBackColor = Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvResultatEleves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvResultatEleves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(29, 49, 68);
            dataGridViewCellStyle3.Font = new Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(39, 66, 90);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvResultatEleves.DefaultCellStyle = dataGridViewCellStyle3;
            dgvResultatEleves.Dock = DockStyle.Fill;
            dgvResultatEleves.EnableHeadersVisualStyles = false;
            dgvResultatEleves.GridColor = Color.White;
            dgvResultatEleves.Location = new Point(10, 10);
            dgvResultatEleves.MultiSelect = false;
            dgvResultatEleves.Name = "dgvResultatEleves";
            dgvResultatEleves.ReadOnly = true;
            dgvResultatEleves.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(29, 49, 68);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionBackColor = Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvResultatEleves.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvResultatEleves.RowHeadersVisible = false;
            dgvResultatEleves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultatEleves.Size = new Size(437, 276);
            dgvResultatEleves.TabIndex = 13;
            dgvResultatEleves.CellClick += dgvResultatEleves_CellClick;
            dgvResultatEleves.CellDoubleClick += dgvResultatEleves_CellDoubleClick;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(19, 32, 45);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(5, 367);
            panel6.Name = "panel6";
            panel6.Size = new Size(457, 1);
            panel6.TabIndex = 33;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(25, 42, 59);
            panel5.Controls.Add(btnValiderPaiement);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(5, 368);
            panel5.Name = "panel5";
            panel5.Size = new Size(457, 70);
            panel5.TabIndex = 32;
            // 
            // btnValiderPaiement
            // 
            btnValiderPaiement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnValiderPaiement.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnValiderPaiement.ForeColor = Color.Black;
            btnValiderPaiement.Location = new Point(303, 8);
            btnValiderPaiement.Name = "btnValiderPaiement";
            btnValiderPaiement.Size = new Size(144, 54);
            btnValiderPaiement.TabIndex = 22;
            btnValiderPaiement.Text = "ValidePaiement";
            btnValiderPaiement.UseVisualStyleBackColor = true;
            btnValiderPaiement.Click += btnValiderPaiement_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtRechercheEleve);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(5, 5);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(457, 66);
            panel3.TabIndex = 3;
            // 
            // txtRechercheEleve
            // 
            txtRechercheEleve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRechercheEleve.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRechercheEleve.Location = new Point(78, 13);
            txtRechercheEleve.Name = "txtRechercheEleve";
            txtRechercheEleve.Size = new Size(368, 43);
            txtRechercheEleve.TabIndex = 17;
            txtRechercheEleve.TextChanged += txtRechercheEleve_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(10, 29);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 18;
            label2.Text = "Recherche";
            // 
            // Popup_Paiement_fm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 49, 68);
            ClientSize = new Size(921, 496);
            Controls.Add(pnlCentre);
            Controls.Add(resizePanel1);
            Controls.Add(pnlDroit);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(224, 224, 224);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Popup_Paiement_fm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popup_Paiement_fm";
            Load += Popup_Paiement_fm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlDroit.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pnlCentre.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultatEleves).EndInit();
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel pnlDroit;
        private Panel panel4;
        private imj_Tools.ResizePanel resizePanel1;
        private Panel pnlCentre;
        private Panel panel3;
        private TextBox txtRechercheEleve;
        private Label label2;
        private TextBox txtMontantVerses;
        private Label label1;
        private ComboBox cmbModePaiement;
        private Label label4;
        private Label label6;
        private ComboBox cmbFraisMotif;
        private TextBox txtObservations;
        private Label label3;
        private Panel panel6;
        private Panel panel5;
        private Panel pnlDgv;
        private DataGridView dgvResultatEleves;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblMatricule;
        private Label lblNomEleve;
        private Label lblCategorie;
        private Label lblTotalDu;
        private Label lblResteAPayer;
        private Label lblDevise;
        private Label lblMoisConcerne;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button btnValiderPaiement;
        private Label label5;
    }
}