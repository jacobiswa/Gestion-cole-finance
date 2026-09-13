namespace FINANCIERE_SCOLAIRE
{
    partial class UC_StructureScolaire
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            panel1 = new Panel();
            tableLayoutPanelBouton = new TableLayoutPanel();
            label5 = new Label();
            btnAfficheAnnee = new Button();
            btnAfficheSection = new Button();
            btnAfficheClass = new Button();
            panel2 = new Panel();
            maskedTextBox1 = new MaskedTextBox();
            checkBoxAnneEstActive = new CheckBox();
            btnAjouterAnnee = new Button();
            btnCloturerAnnee = new Button();
            panel15 = new Panel();
            dgvAnnees = new DataGridView();
            tabControlAnneAcademique = new TabControl();
            tabPageClasse = new TabPage();
            panel7 = new Panel();
            dgvClasses = new DataGridView();
            panel6 = new Panel();
            label7 = new Label();
            label6 = new Label();
            cmbOptions = new ComboBox();
            cmbSections = new ComboBox();
            label4 = new Label();
            btnAjouterClasse = new Button();
            tabPageSectionsOptions = new TabPage();
            panel5 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvSections = new DataGridView();
            dgvOptions = new DataGridView();
            panel4 = new Panel();
            label3 = new Label();
            btnAjouterSection = new Button();
            tabPageAnneeScolaire = new TabPage();
            panel3 = new Panel();
            btnrestaurerAnner = new Button();
            label2 = new Label();
            checkBoxClotureAnner = new CheckBox();
            label1 = new Label();
            btnSupprimerAnnee = new Button();
            btnModifierAnnee = new Button();
            panel1.SuspendLayout();
            tableLayoutPanelBouton.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnnees).BeginInit();
            tabControlAnneAcademique.SuspendLayout();
            tabPageClasse.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            panel6.SuspendLayout();
            tabPageSectionsOptions.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOptions).BeginInit();
            panel4.SuspendLayout();
            tabPageAnneeScolaire.SuspendLayout();
            panel3.SuspendLayout();
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
            panel1.Size = new Size(887, 47);
            panel1.TabIndex = 0;
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
            tableLayoutPanelBouton.Controls.Add(btnAfficheAnnee, 2, 0);
            tableLayoutPanelBouton.Controls.Add(btnAfficheSection, 1, 0);
            tableLayoutPanelBouton.Controls.Add(btnAfficheClass, 0, 0);
            tableLayoutPanelBouton.Dock = DockStyle.Fill;
            tableLayoutPanelBouton.Location = new Point(10, 0);
            tableLayoutPanelBouton.Name = "tableLayoutPanelBouton";
            tableLayoutPanelBouton.RowCount = 1;
            tableLayoutPanelBouton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBouton.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelBouton.Size = new Size(867, 47);
            tableLayoutPanelBouton.TabIndex = 28;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            tableLayoutPanelBouton.SetColumnSpan(label5, 2);
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(192, 255, 255);
            label5.Location = new Point(561, 13);
            label5.Name = "label5";
            label5.Size = new Size(303, 21);
            label5.TabIndex = 19;
            label5.Text = "Gestion des Années Scolaires";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAfficheAnnee
            // 
            btnAfficheAnnee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAfficheAnnee.FlatAppearance.BorderSize = 0;
            btnAfficheAnnee.FlatStyle = FlatStyle.Flat;
            btnAfficheAnnee.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAfficheAnnee.Image = Properties.Resources.icons8_saturday_25px;
            btnAfficheAnnee.ImageAlign = ContentAlignment.MiddleLeft;
            btnAfficheAnnee.Location = new Point(340, 3);
            btnAfficheAnnee.Name = "btnAfficheAnnee";
            btnAfficheAnnee.Size = new Size(215, 41);
            btnAfficheAnnee.TabIndex = 4;
            btnAfficheAnnee.Text = "Année academique";
            btnAfficheAnnee.UseVisualStyleBackColor = true;
            btnAfficheAnnee.Click += button1_Click;
            // 
            // btnAfficheSection
            // 
            btnAfficheSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAfficheSection.FlatAppearance.BorderSize = 0;
            btnAfficheSection.FlatStyle = FlatStyle.Flat;
            btnAfficheSection.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAfficheSection.Image = Properties.Resources.icons8_school_backpack_25px;
            btnAfficheSection.ImageAlign = ContentAlignment.MiddleLeft;
            btnAfficheSection.Location = new Point(129, 3);
            btnAfficheSection.Name = "btnAfficheSection";
            btnAfficheSection.Size = new Size(205, 41);
            btnAfficheSection.TabIndex = 4;
            btnAfficheSection.Text = "Sections et Options";
            btnAfficheSection.UseVisualStyleBackColor = true;
            btnAfficheSection.Click += button2_Click;
            // 
            // btnAfficheClass
            // 
            btnAfficheClass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAfficheClass.FlatAppearance.BorderSize = 0;
            btnAfficheClass.FlatStyle = FlatStyle.Flat;
            btnAfficheClass.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAfficheClass.Image = Properties.Resources.icons8_school_25px;
            btnAfficheClass.ImageAlign = ContentAlignment.MiddleLeft;
            btnAfficheClass.Location = new Point(3, 3);
            btnAfficheClass.Name = "btnAfficheClass";
            btnAfficheClass.Size = new Size(120, 41);
            btnAfficheClass.TabIndex = 4;
            btnAfficheClass.Text = "Classes";
            btnAfficheClass.UseVisualStyleBackColor = true;
            btnAfficheClass.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(2, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(887, 1);
            panel2.TabIndex = 1;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            maskedTextBox1.Location = new Point(6, 79);
            maskedTextBox1.Mask = "0000-0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(132, 33);
            maskedTextBox1.TabIndex = 2;
            maskedTextBox1.Text = "20252026";
            // 
            // checkBoxAnneEstActive
            // 
            checkBoxAnneEstActive.AutoSize = true;
            checkBoxAnneEstActive.Location = new Point(10, 121);
            checkBoxAnneEstActive.Name = "checkBoxAnneEstActive";
            checkBoxAnneEstActive.Size = new Size(293, 19);
            checkBoxAnneEstActive.TabIndex = 3;
            checkBoxAnneEstActive.Text = "Indiquer si l'année créée est immédiatement active";
            checkBoxAnneEstActive.UseVisualStyleBackColor = true;
            // 
            // btnAjouterAnnee
            // 
            btnAjouterAnnee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterAnnee.Location = new Point(144, 78);
            btnAjouterAnnee.Name = "btnAjouterAnnee";
            btnAjouterAnnee.Size = new Size(159, 35);
            btnAjouterAnnee.TabIndex = 4;
            btnAjouterAnnee.Text = "Ajouter une année scolaire";
            btnAjouterAnnee.UseVisualStyleBackColor = true;
            btnAjouterAnnee.Click += btnAjouterAnnee_Click;
            // 
            // btnCloturerAnnee
            // 
            btnCloturerAnnee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloturerAnnee.BackColor = Color.FromArgb(192, 64, 0);
            btnCloturerAnnee.Enabled = false;
            btnCloturerAnnee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCloturerAnnee.ForeColor = Color.White;
            btnCloturerAnnee.Location = new Point(566, 7);
            btnCloturerAnnee.Name = "btnCloturerAnnee";
            btnCloturerAnnee.Size = new Size(273, 36);
            btnCloturerAnnee.TabIndex = 4;
            btnCloturerAnnee.Text = "Clôturer l'année en cours (Archiver)";
            btnCloturerAnnee.UseVisualStyleBackColor = false;
            btnCloturerAnnee.Click += btnCloturerAnnee_Click;
            // 
            // panel15
            // 
            panel15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel15.BackColor = SystemColors.Control;
            panel15.Controls.Add(dgvAnnees);
            panel15.Location = new Point(6, 182);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(10);
            panel15.Size = new Size(766, 223);
            panel15.TabIndex = 18;
            // 
            // dgvAnnees
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvAnnees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAnnees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAnnees.BackgroundColor = SystemColors.Control;
            dgvAnnees.BorderStyle = BorderStyle.None;
            dgvAnnees.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAnnees.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAnnees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAnnees.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAnnees.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAnnees.Dock = DockStyle.Fill;
            dgvAnnees.EnableHeadersVisualStyles = false;
            dgvAnnees.GridColor = Color.White;
            dgvAnnees.Location = new Point(10, 10);
            dgvAnnees.MultiSelect = false;
            dgvAnnees.Name = "dgvAnnees";
            dgvAnnees.ReadOnly = true;
            dgvAnnees.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAnnees.RowHeadersVisible = false;
            dgvAnnees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnnees.Size = new Size(746, 203);
            dgvAnnees.TabIndex = 13;
            dgvAnnees.CellClick += dgvAnnees_CellClick;
            dgvAnnees.CellDoubleClick += dgvAnnees_CellDoubleClick;
            // 
            // tabControlAnneAcademique
            // 
            tabControlAnneAcademique.Controls.Add(tabPageClasse);
            tabControlAnneAcademique.Controls.Add(tabPageSectionsOptions);
            tabControlAnneAcademique.Controls.Add(tabPageAnneeScolaire);
            tabControlAnneAcademique.Dock = DockStyle.Fill;
            tabControlAnneAcademique.Location = new Point(2, 50);
            tabControlAnneAcademique.Name = "tabControlAnneAcademique";
            tabControlAnneAcademique.SelectedIndex = 0;
            tabControlAnneAcademique.Size = new Size(887, 439);
            tabControlAnneAcademique.TabIndex = 19;
            // 
            // tabPageClasse
            // 
            tabPageClasse.Controls.Add(panel7);
            tabPageClasse.Controls.Add(panel6);
            tabPageClasse.Location = new Point(4, 24);
            tabPageClasse.Name = "tabPageClasse";
            tabPageClasse.Size = new Size(879, 411);
            tabPageClasse.TabIndex = 2;
            tabPageClasse.Text = "Gestion des Classes";
            tabPageClasse.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvClasses);
            panel7.Location = new Point(8, 92);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(868, 301);
            panel7.TabIndex = 28;
            // 
            // dgvClasses
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvClasses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClasses.BackgroundColor = Color.White;
            dgvClasses.BorderStyle = BorderStyle.None;
            dgvClasses.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvClasses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvClasses.ColumnHeadersHeight = 42;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvClasses.DefaultCellStyle = dataGridViewCellStyle6;
            dgvClasses.Dock = DockStyle.Fill;
            dgvClasses.EnableHeadersVisualStyles = false;
            dgvClasses.GridColor = Color.White;
            dgvClasses.Location = new Point(10, 10);
            dgvClasses.MultiSelect = false;
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClasses.RowHeadersVisible = false;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.Size = new Size(848, 281);
            dgvClasses.TabIndex = 13;
            dgvClasses.CellDoubleClick += dgvClasses_CellDoubleClick;
            // 
            // panel6
            // 
            panel6.Controls.Add(label7);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(cmbOptions);
            panel6.Controls.Add(cmbSections);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(btnAjouterClasse);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(879, 86);
            panel6.TabIndex = 22;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(604, 32);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 33;
            label7.Text = "Options";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(326, 32);
            label6.Name = "label6";
            label6.Size = new Size(164, 15);
            label6.TabIndex = 33;
            label6.Text = "Sélectionner la section à gérer";
            // 
            // cmbOptions
            // 
            cmbOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbOptions.FormattingEnabled = true;
            cmbOptions.Location = new Point(604, 50);
            cmbOptions.Name = "cmbOptions";
            cmbOptions.Size = new Size(269, 29);
            cmbOptions.TabIndex = 32;
            cmbOptions.SelectedIndexChanged += cmbOptions_SelectedIndexChanged;
            // 
            // cmbSections
            // 
            cmbSections.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSections.FormattingEnabled = true;
            cmbSections.Location = new Point(326, 50);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(272, 29);
            cmbSections.TabIndex = 32;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Teal;
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(181, 25);
            label4.TabIndex = 21;
            label4.Text = "Gestion des Classes";
            // 
            // btnAjouterClasse
            // 
            btnAjouterClasse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterClasse.Location = new Point(9, 46);
            btnAjouterClasse.Name = "btnAjouterClasse";
            btnAjouterClasse.Size = new Size(159, 35);
            btnAjouterClasse.TabIndex = 27;
            btnAjouterClasse.Text = "Ajouter Classe";
            btnAjouterClasse.UseVisualStyleBackColor = true;
            btnAjouterClasse.Click += btnAjouterClasse_Click;
            // 
            // tabPageSectionsOptions
            // 
            tabPageSectionsOptions.Controls.Add(panel5);
            tabPageSectionsOptions.Controls.Add(panel4);
            tabPageSectionsOptions.ForeColor = Color.FromArgb(64, 64, 64);
            tabPageSectionsOptions.Location = new Point(4, 24);
            tabPageSectionsOptions.Name = "tabPageSectionsOptions";
            tabPageSectionsOptions.Padding = new Padding(3);
            tabPageSectionsOptions.Size = new Size(879, 411);
            tabPageSectionsOptions.TabIndex = 1;
            tabPageSectionsOptions.Text = "Gestion des Sections & Options";
            tabPageSectionsOptions.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.White;
            panel5.Controls.Add(tableLayoutPanel1);
            panel5.Location = new Point(6, 103);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(766, 294);
            panel5.TabIndex = 25;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgvSections, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvOptions, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.3396225F));
            tableLayoutPanel1.Size = new Size(746, 274);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // dgvSections
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvSections.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvSections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSections.BackgroundColor = Color.White;
            dgvSections.BorderStyle = BorderStyle.None;
            dgvSections.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvSections.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(0, 64, 64);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvSections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvSections.ColumnHeadersHeight = 42;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvSections.DefaultCellStyle = dataGridViewCellStyle9;
            dgvSections.EnableHeadersVisualStyles = false;
            dgvSections.GridColor = Color.White;
            dgvSections.Location = new Point(4, 4);
            dgvSections.MultiSelect = false;
            dgvSections.Name = "dgvSections";
            dgvSections.ReadOnly = true;
            dgvSections.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSections.RowHeadersVisible = false;
            dgvSections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSections.Size = new Size(365, 266);
            dgvSections.TabIndex = 13;
            dgvSections.CellDoubleClick += dgvSections_CellDoubleClick;
            dgvSections.Click += dgvSections_Click;
            // 
            // dgvOptions
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvOptions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvOptions.BackgroundColor = Color.White;
            dgvOptions.BorderStyle = BorderStyle.None;
            dgvOptions.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvOptions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvOptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvOptions.ColumnHeadersHeight = 42;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dgvOptions.DefaultCellStyle = dataGridViewCellStyle12;
            dgvOptions.EnableHeadersVisualStyles = false;
            dgvOptions.GridColor = Color.White;
            dgvOptions.Location = new Point(376, 4);
            dgvOptions.MultiSelect = false;
            dgvOptions.Name = "dgvOptions";
            dgvOptions.ReadOnly = true;
            dgvOptions.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOptions.RowHeadersVisible = false;
            dgvOptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOptions.Size = new Size(366, 266);
            dgvOptions.TabIndex = 13;
            dgvOptions.CellDoubleClick += dgvOptions_CellDoubleClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(btnAjouterSection);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(873, 84);
            panel4.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(3, 11);
            label3.Name = "label3";
            label3.Size = new Size(291, 25);
            label3.TabIndex = 20;
            label3.Text = "Gestion des Sections et Options";
            // 
            // btnAjouterSection
            // 
            btnAjouterSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAjouterSection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterSection.Location = new Point(13, 41);
            btnAjouterSection.Name = "btnAjouterSection";
            btnAjouterSection.Size = new Size(130, 35);
            btnAjouterSection.TabIndex = 24;
            btnAjouterSection.Text = "Ajouter Section";
            btnAjouterSection.UseVisualStyleBackColor = true;
            btnAjouterSection.Click += btnAjouterSection_Click;
            // 
            // tabPageAnneeScolaire
            // 
            tabPageAnneeScolaire.Controls.Add(panel3);
            tabPageAnneeScolaire.Controls.Add(label1);
            tabPageAnneeScolaire.Controls.Add(maskedTextBox1);
            tabPageAnneeScolaire.Controls.Add(panel15);
            tabPageAnneeScolaire.Controls.Add(checkBoxAnneEstActive);
            tabPageAnneeScolaire.Controls.Add(btnSupprimerAnnee);
            tabPageAnneeScolaire.Controls.Add(btnModifierAnnee);
            tabPageAnneeScolaire.Controls.Add(btnAjouterAnnee);
            tabPageAnneeScolaire.ForeColor = Color.FromArgb(64, 64, 64);
            tabPageAnneeScolaire.Location = new Point(4, 24);
            tabPageAnneeScolaire.Name = "tabPageAnneeScolaire";
            tabPageAnneeScolaire.Padding = new Padding(3);
            tabPageAnneeScolaire.Size = new Size(879, 411);
            tabPageAnneeScolaire.TabIndex = 0;
            tabPageAnneeScolaire.Text = "Gestion des Années Scolaires";
            tabPageAnneeScolaire.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnrestaurerAnner);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnCloturerAnnee);
            panel3.Controls.Add(checkBoxClotureAnner);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(873, 46);
            panel3.TabIndex = 20;
            // 
            // btnrestaurerAnner
            // 
            btnrestaurerAnner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnrestaurerAnner.BackColor = Color.Green;
            btnrestaurerAnner.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnrestaurerAnner.ForeColor = Color.White;
            btnrestaurerAnner.Location = new Point(434, 7);
            btnrestaurerAnner.Name = "btnrestaurerAnner";
            btnrestaurerAnner.Size = new Size(126, 36);
            btnrestaurerAnner.TabIndex = 20;
            btnrestaurerAnner.Text = "Restaurer";
            btnrestaurerAnner.UseVisualStyleBackColor = false;
            btnrestaurerAnner.Click += btnrestaurerAnner_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(268, 25);
            label2.TabIndex = 19;
            label2.Text = "Gestion des Années Scolaires";
            // 
            // checkBoxClotureAnner
            // 
            checkBoxClotureAnner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxClotureAnner.AutoSize = true;
            checkBoxClotureAnner.Location = new Point(845, 20);
            checkBoxClotureAnner.Name = "checkBoxClotureAnner";
            checkBoxClotureAnner.Size = new Size(15, 14);
            checkBoxClotureAnner.TabIndex = 3;
            checkBoxClotureAnner.UseVisualStyleBackColor = true;
            checkBoxClotureAnner.CheckedChanged += checkBoxClotureAnner_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 61);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 19;
            label1.Text = "Nouvelle année scolaire";
            // 
            // btnSupprimerAnnee
            // 
            btnSupprimerAnnee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupprimerAnnee.Location = new Point(239, 141);
            btnSupprimerAnnee.Name = "btnSupprimerAnnee";
            btnSupprimerAnnee.Size = new Size(223, 35);
            btnSupprimerAnnee.TabIndex = 4;
            btnSupprimerAnnee.Text = "Supprimer  année scolaire";
            btnSupprimerAnnee.UseVisualStyleBackColor = true;
            btnSupprimerAnnee.Visible = false;
            btnSupprimerAnnee.Click += btnSupprimerAnnee_Click;
            // 
            // btnModifierAnnee
            // 
            btnModifierAnnee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModifierAnnee.Location = new Point(7, 141);
            btnModifierAnnee.Name = "btnModifierAnnee";
            btnModifierAnnee.Size = new Size(223, 35);
            btnModifierAnnee.TabIndex = 4;
            btnModifierAnnee.Text = "Modifier  année scolaire";
            btnModifierAnnee.UseVisualStyleBackColor = true;
            btnModifierAnnee.Visible = false;
            btnModifierAnnee.Click += btnModifierAnnee_Click;
            // 
            // UC_StructureScolaire
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlAnneAcademique);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_StructureScolaire";
            Padding = new Padding(2, 2, 2, 10);
            Size = new Size(891, 499);
            Load += UC_StructureScolaire_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanelBouton.ResumeLayout(false);
            tableLayoutPanelBouton.PerformLayout();
            panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnnees).EndInit();
            tabControlAnneAcademique.ResumeLayout(false);
            tabPageClasse.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPageSectionsOptions.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSections).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOptions).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPageAnneeScolaire.ResumeLayout(false);
            tabPageAnneeScolaire.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private MaskedTextBox maskedTextBox1;
        private CheckBox checkBoxAnneEstActive;
        private Button btnAjouterAnnee;
        private Button btnCloturerAnnee;
        private Panel panel15;
        private DataGridView dgvAnnees;
        private TabControl tabControlAnneAcademique;
        private TabPage tabPageAnneeScolaire;
        private TabPage tabPageSectionsOptions;
        private TabPage tabPageClasse;
        private Label label1;
        private Panel panel3;
        private Button btnAjouterSection;
        private Panel panel4;
        private Panel panel5;
        private DataGridView dgvOptions;
        private Panel panel7;
        private Button btnAjouterClasse;
        private Panel panel6;
        private Label label2;
        private CheckBox checkBoxClotureAnner;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvSections;
        private Label label4;
        private TableLayoutPanel tableLayoutPanelBouton;
        private Button btnAfficheAnnee;
        private Label label5;
        private Button btnAfficheSection;
        private Button btnAfficheClass;
        private Label label6;
        private ComboBox cmbSections;
        private Label label7;
        private ComboBox cmbOptions;
        private Button btnModifierAnnee;
        private Button btnSupprimerAnnee;
        private DataGridView dgvClasses;
        private Button btnrestaurerAnner;
    }
}
