namespace FINANCIERE_SCOLAIRE
{
    partial class DashBoard_fm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard_fm));
            panel1 = new Panel();
            lblBienvenue = new Label();
            panel_rond1_Menu = new imj_Tools.Panel_rond();
            btnParamettre = new Button();
            btnUser = new Button();
            btnRapport = new Button();
            btnRecouvrement = new Button();
            btnPaiement = new Button();
            btnEleves = new Button();
            btnFraisColaire = new Button();
            btnStructureScolaire = new Button();
            btnDashBoard = new Button();
            panel2 = new Panel();
            lblNomEcole = new Label();
            resizePanel1 = new imj_Tools.ResizePanel();
            panel3 = new Panel();
            btnMenu = new Button();
            panel4 = new Panel();
            pnlMain = new Panel();
            panel1.SuspendLayout();
            panel_rond1_Menu.SuspendLayout();
            panel3.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(lblBienvenue);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.FromArgb(224, 224, 224);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 10, 10, 2);
            panel1.Size = new Size(800, 39);
            panel1.TabIndex = 1;
            // 
            // lblBienvenue
            // 
            lblBienvenue.AutoSize = true;
            lblBienvenue.Dock = DockStyle.Left;
            lblBienvenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenue.Location = new Point(10, 10);
            lblBienvenue.Name = "lblBienvenue";
            lblBienvenue.Size = new Size(90, 21);
            lblBienvenue.TabIndex = 0;
            lblBienvenue.Text = "UserName";
            // 
            // panel_rond1_Menu
            // 
            panel_rond1_Menu.AutoScroll = true;
            panel_rond1_Menu.BorderColor = Color.Transparent;
            panel_rond1_Menu.BorderRadius = 0;
            panel_rond1_Menu.BorderThickness = 2;
            panel_rond1_Menu.Controls.Add(btnParamettre);
            panel_rond1_Menu.Controls.Add(btnUser);
            panel_rond1_Menu.Controls.Add(btnRapport);
            panel_rond1_Menu.Controls.Add(btnRecouvrement);
            panel_rond1_Menu.Controls.Add(btnPaiement);
            panel_rond1_Menu.Controls.Add(btnEleves);
            panel_rond1_Menu.Controls.Add(btnFraisColaire);
            panel_rond1_Menu.Controls.Add(btnStructureScolaire);
            panel_rond1_Menu.Controls.Add(btnDashBoard);
            panel_rond1_Menu.Controls.Add(panel2);
            panel_rond1_Menu.Dock = DockStyle.Left;
            panel_rond1_Menu.GradientAngle = 305F;
            panel_rond1_Menu.GradientBottomColor = Color.LightSeaGreen;
            panel_rond1_Menu.GradientTopColor = Color.RoyalBlue;
            panel_rond1_Menu.Location = new Point(0, 39);
            panel_rond1_Menu.Name = "panel_rond1_Menu";
            panel_rond1_Menu.Padding = new Padding(15, 10, 15, 10);
            panel_rond1_Menu.Size = new Size(327, 438);
            panel_rond1_Menu.TabIndex = 6;
            // 
            // btnParamettre
            // 
            btnParamettre.BackColor = Color.Transparent;
            btnParamettre.Dock = DockStyle.Top;
            btnParamettre.FlatAppearance.BorderSize = 0;
            btnParamettre.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnParamettre.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnParamettre.FlatStyle = FlatStyle.Flat;
            btnParamettre.Font = new Font("Segoe UI", 10F);
            btnParamettre.ForeColor = Color.FromArgb(224, 224, 224);
            btnParamettre.Image = Properties.Resources.icons8_settings_25px;
            btnParamettre.ImageAlign = ContentAlignment.MiddleLeft;
            btnParamettre.Location = new Point(15, 384);
            btnParamettre.Name = "btnParamettre";
            btnParamettre.Size = new Size(297, 35);
            btnParamettre.TabIndex = 8;
            btnParamettre.Text = "Paramettre";
            btnParamettre.UseVisualStyleBackColor = false;
            btnParamettre.Click += btnParamettre_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Transparent;
            btnUser.Dock = DockStyle.Top;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI", 10F);
            btnUser.ForeColor = Color.FromArgb(224, 224, 224);
            btnUser.Image = Properties.Resources.icons8_user_25px_1;
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Location = new Point(15, 349);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(297, 35);
            btnUser.TabIndex = 7;
            btnUser.Text = "Profils Utilisateurs";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnRapport
            // 
            btnRapport.BackColor = Color.Transparent;
            btnRapport.Dock = DockStyle.Top;
            btnRapport.FlatAppearance.BorderSize = 0;
            btnRapport.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnRapport.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnRapport.FlatStyle = FlatStyle.Flat;
            btnRapport.Font = new Font("Segoe UI", 10F);
            btnRapport.ForeColor = Color.FromArgb(224, 224, 224);
            btnRapport.Image = Properties.Resources.icons8_test_passed_25px1;
            btnRapport.ImageAlign = ContentAlignment.MiddleLeft;
            btnRapport.Location = new Point(15, 314);
            btnRapport.Name = "btnRapport";
            btnRapport.Size = new Size(297, 35);
            btnRapport.TabIndex = 6;
            btnRapport.Text = "Rapports ";
            btnRapport.UseVisualStyleBackColor = false;
            btnRapport.Click += btnRapport_Click;
            // 
            // btnRecouvrement
            // 
            btnRecouvrement.BackColor = Color.Transparent;
            btnRecouvrement.Dock = DockStyle.Top;
            btnRecouvrement.FlatAppearance.BorderSize = 0;
            btnRecouvrement.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnRecouvrement.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnRecouvrement.FlatStyle = FlatStyle.Flat;
            btnRecouvrement.Font = new Font("Segoe UI", 10F);
            btnRecouvrement.ForeColor = Color.FromArgb(224, 224, 224);
            btnRecouvrement.Image = Properties.Resources.icons8_rental_house_contract_25px;
            btnRecouvrement.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecouvrement.Location = new Point(15, 279);
            btnRecouvrement.Name = "btnRecouvrement";
            btnRecouvrement.Size = new Size(297, 35);
            btnRecouvrement.TabIndex = 5;
            btnRecouvrement.Text = "Recouvrement";
            btnRecouvrement.UseVisualStyleBackColor = false;
            btnRecouvrement.Click += btnRecouvrement_Click;
            // 
            // btnPaiement
            // 
            btnPaiement.BackColor = Color.FromArgb(39, 66, 90);
            btnPaiement.Dock = DockStyle.Top;
            btnPaiement.FlatAppearance.BorderSize = 0;
            btnPaiement.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnPaiement.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnPaiement.FlatStyle = FlatStyle.Flat;
            btnPaiement.Font = new Font("Segoe UI", 10F);
            btnPaiement.ForeColor = Color.FromArgb(224, 224, 224);
            btnPaiement.Image = Properties.Resources.icons8_stack_of_money_25px;
            btnPaiement.ImageAlign = ContentAlignment.MiddleLeft;
            btnPaiement.Location = new Point(15, 244);
            btnPaiement.Name = "btnPaiement";
            btnPaiement.Size = new Size(297, 35);
            btnPaiement.TabIndex = 4;
            btnPaiement.Text = "Paiements et Facturation";
            btnPaiement.UseVisualStyleBackColor = false;
            btnPaiement.Click += btnPaiement_Click;
            // 
            // btnEleves
            // 
            btnEleves.BackColor = Color.Transparent;
            btnEleves.Dock = DockStyle.Top;
            btnEleves.FlatAppearance.BorderSize = 0;
            btnEleves.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnEleves.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnEleves.FlatStyle = FlatStyle.Flat;
            btnEleves.Font = new Font("Segoe UI", 10F);
            btnEleves.ForeColor = Color.FromArgb(224, 224, 224);
            btnEleves.Image = Properties.Resources.icons8_user_25px;
            btnEleves.ImageAlign = ContentAlignment.MiddleLeft;
            btnEleves.Location = new Point(15, 209);
            btnEleves.Name = "btnEleves";
            btnEleves.Size = new Size(297, 35);
            btnEleves.TabIndex = 3;
            btnEleves.Text = "Élèves et Inscriptions";
            btnEleves.UseVisualStyleBackColor = false;
            btnEleves.Click += btnEleves_Click;
            // 
            // btnFraisColaire
            // 
            btnFraisColaire.BackColor = Color.Transparent;
            btnFraisColaire.Dock = DockStyle.Top;
            btnFraisColaire.FlatAppearance.BorderSize = 0;
            btnFraisColaire.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnFraisColaire.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnFraisColaire.FlatStyle = FlatStyle.Flat;
            btnFraisColaire.Font = new Font("Segoe UI", 10F);
            btnFraisColaire.ForeColor = Color.FromArgb(224, 224, 224);
            btnFraisColaire.Image = Properties.Resources.icons8_money_bag_franc_25px;
            btnFraisColaire.ImageAlign = ContentAlignment.MiddleLeft;
            btnFraisColaire.Location = new Point(15, 174);
            btnFraisColaire.Name = "btnFraisColaire";
            btnFraisColaire.Size = new Size(297, 35);
            btnFraisColaire.TabIndex = 2;
            btnFraisColaire.Text = "Frais Scolaires";
            btnFraisColaire.UseVisualStyleBackColor = false;
            btnFraisColaire.Click += btnFraisColaire_Click;
            // 
            // btnStructureScolaire
            // 
            btnStructureScolaire.BackColor = Color.Transparent;
            btnStructureScolaire.Dock = DockStyle.Top;
            btnStructureScolaire.FlatAppearance.BorderSize = 0;
            btnStructureScolaire.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnStructureScolaire.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnStructureScolaire.FlatStyle = FlatStyle.Flat;
            btnStructureScolaire.Font = new Font("Segoe UI", 10F);
            btnStructureScolaire.ForeColor = Color.FromArgb(224, 224, 224);
            btnStructureScolaire.Image = Properties.Resources.icons8_school_backpack_25px1;
            btnStructureScolaire.ImageAlign = ContentAlignment.MiddleLeft;
            btnStructureScolaire.Location = new Point(15, 139);
            btnStructureScolaire.Name = "btnStructureScolaire";
            btnStructureScolaire.Size = new Size(297, 35);
            btnStructureScolaire.TabIndex = 1;
            btnStructureScolaire.Text = "Structure Scolaire";
            btnStructureScolaire.UseVisualStyleBackColor = false;
            btnStructureScolaire.Click += btnStructureScolaire_Click;
            // 
            // btnDashBoard
            // 
            btnDashBoard.BackColor = Color.Transparent;
            btnDashBoard.Dock = DockStyle.Top;
            btnDashBoard.FlatAppearance.BorderSize = 0;
            btnDashBoard.FlatAppearance.MouseDownBackColor = Color.FromArgb(16, 91, 104);
            btnDashBoard.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 58, 68);
            btnDashBoard.FlatStyle = FlatStyle.Flat;
            btnDashBoard.Font = new Font("Segoe UI", 10F);
            btnDashBoard.ForeColor = Color.FromArgb(224, 224, 224);
            btnDashBoard.Image = Properties.Resources.icons8_dashboard_25px;
            btnDashBoard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashBoard.Location = new Point(15, 92);
            btnDashBoard.Name = "btnDashBoard";
            btnDashBoard.Size = new Size(297, 47);
            btnDashBoard.TabIndex = 0;
            btnDashBoard.Text = "Tableu de bord";
            btnDashBoard.UseVisualStyleBackColor = false;
            btnDashBoard.Click += btnDashBoard_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources.LogoFinanceEcole;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(15, 10);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 0, 10);
            panel2.Size = new Size(297, 82);
            panel2.TabIndex = 0;
            // 
            // lblNomEcole
            // 
            lblNomEcole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNomEcole.BackColor = Color.Transparent;
            lblNomEcole.Font = new Font("Segoe UI Black", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomEcole.ForeColor = Color.White;
            lblNomEcole.Location = new Point(17, 13);
            lblNomEcole.Name = "lblNomEcole";
            lblNomEcole.Size = new Size(439, 352);
            lblNomEcole.TabIndex = 1;
            lblNomEcole.Text = "Nom Ecole";
            // 
            // resizePanel1
            // 
            resizePanel1.BackColor = SystemColors.ActiveCaption;
            resizePanel1.Direction = imj_Tools.ResizePanel.ResizeDirection.Left;
            resizePanel1.Dock = DockStyle.Left;
            resizePanel1.Location = new Point(327, 39);
            resizePanel1.Name = "resizePanel1";
            resizePanel1.Size = new Size(5, 438);
            resizePanel1.TabIndex = 7;
            resizePanel1.TargetPanel = panel_rond1_Menu;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnMenu);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(332, 39);
            panel3.Name = "panel3";
            panel3.Size = new Size(468, 63);
            panel3.TabIndex = 8;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Transparent;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 10F);
            btnMenu.ForeColor = Color.FromArgb(224, 224, 224);
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.Location = new Point(3, 10);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(40, 35);
            btnMenu.TabIndex = 11;
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(332, 102);
            panel4.Name = "panel4";
            panel4.Size = new Size(468, 1);
            panel4.TabIndex = 9;
            // 
            // pnlMain
            // 
            pnlMain.BackgroundImage = Properties.Resources.bg3;
            pnlMain.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMain.Controls.Add(lblNomEcole);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(332, 103);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(468, 374);
            pnlMain.TabIndex = 10;
            // 
            // DashBoard_fm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 477);
            Controls.Add(pnlMain);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(resizePanel1);
            Controls.Add(panel_rond1_Menu);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DashBoard_fm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard_fm";
            Load += DashBoard_fm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_rond1_Menu.ResumeLayout(false);
            panel3.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblBienvenue;
        private imj_Tools.Panel_rond panel_rond1_Menu;
        private Button btnDashBoard;
        private Panel panel2;
        private imj_Tools.ResizePanel resizePanel1;
        private Panel panel3;
        private Button btnMenu;
        private Panel panel4;
        private Button btnPaiement;
        private Button btnEleves;
        private Button btnFraisColaire;
        private Button btnStructureScolaire;
        private Button btnParamettre;
        private Button btnUser;
        private Button btnRapport;
        private Button btnRecouvrement;
        private Label lblNomEcole;
        private Panel pnlMain;
    }
}