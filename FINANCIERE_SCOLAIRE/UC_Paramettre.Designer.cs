namespace FINANCIERE_SCOLAIRE
{
    partial class UC_Paramettre
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
            panel1 = new Panel();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            pbLogo = new PictureBox();
            btnEnregistrer = new Button();
            btnChoisirLogo = new Button();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtMinistere = new TextBox();
            txtAdresse = new TextBox();
            txtEmail = new TextBox();
            txtTelephone = new TextBox();
            txtBoitePostale = new TextBox();
            txtPays = new TextBox();
            txtNomEcole = new TextBox();
            tabPage1 = new TabPage();
            pnlBoutonConfig = new Panel();
            cbActive = new CheckBox();
            btnBD_Supprimer = new imj_Tools.Bouton_rond();
            btn_Bd_initialiser = new imj_Tools.Bouton_rond();
            btnPardefault = new imj_Tools.Bouton_rond();
            btnAjouterElevesTeste = new imj_Tools.Bouton_rond();
            cbActiveBd = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            lblBdName = new Label();
            label2 = new Label();
            txtNomBD = new TextBox();
            txtActivePnl = new TextBox();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            txtServeur = new TextBox();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            tabPage1.SuspendLayout();
            pnlBoutonConfig.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(875, 64);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(8, 10);
            label1.Name = "label1";
            label1.Size = new Size(185, 46);
            label1.TabIndex = 0;
            label1.Text = "Paramettre";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(2, 66);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(875, 412);
            tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(pbLogo);
            tabPage2.Controls.Add(btnEnregistrer);
            tabPage2.Controls.Add(btnChoisirLogo);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(txtMinistere);
            tabPage2.Controls.Add(txtAdresse);
            tabPage2.Controls.Add(txtEmail);
            tabPage2.Controls.Add(txtTelephone);
            tabPage2.Controls.Add(txtBoitePostale);
            tabPage2.Controls.Add(txtPays);
            tabPage2.Controls.Add(txtNomEcole);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(867, 384);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Appication";
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbLogo.BackColor = SystemColors.ActiveBorder;
            pbLogo.Location = new Point(638, 20);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(203, 166);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 12;
            pbLogo.TabStop = false;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEnregistrer.Location = new Point(668, 241);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(173, 36);
            btnEnregistrer.TabIndex = 11;
            btnEnregistrer.Text = "Enregistrer Parametre";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnChoisirLogo
            // 
            btnChoisirLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChoisirLogo.Location = new Point(714, 192);
            btnChoisirLogo.Name = "btnChoisirLogo";
            btnChoisirLogo.Size = new Size(127, 36);
            btnChoisirLogo.TabIndex = 11;
            btnChoisirLogo.Text = "Choisir Logo";
            btnChoisirLogo.UseVisualStyleBackColor = true;
            btnChoisirLogo.Click += btnChoisirLogo_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 329);
            label13.Name = "label13";
            label13.Size = new Size(56, 15);
            label13.TabIndex = 7;
            label13.Text = "Ministere";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 291);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 7;
            label12.Text = "Adresse";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(22, 253);
            label11.Name = "label11";
            label11.Size = new Size(36, 15);
            label11.TabIndex = 7;
            label11.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(22, 206);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 7;
            label8.Text = "Telephone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 168);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 7;
            label6.Text = "Boite Postale";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 119);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 7;
            label7.Text = "Pays";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(78, 35);
            label9.Name = "label9";
            label9.Size = new Size(163, 21);
            label9.TabIndex = 9;
            label9.Text = "Version proposée : 1.0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 76);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 10;
            label10.Text = "Nom Ecole";
            // 
            // txtMinistere
            // 
            txtMinistere.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinistere.Font = new Font("Segoe UI", 9.75F);
            txtMinistere.Location = new Point(102, 318);
            txtMinistere.Name = "txtMinistere";
            txtMinistere.Size = new Size(500, 25);
            txtMinistere.TabIndex = 5;
            // 
            // txtAdresse
            // 
            txtAdresse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAdresse.Font = new Font("Segoe UI", 9.75F);
            txtAdresse.Location = new Point(102, 280);
            txtAdresse.Name = "txtAdresse";
            txtAdresse.Size = new Size(500, 25);
            txtAdresse.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 9.75F);
            txtEmail.Location = new Point(102, 242);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(500, 25);
            txtEmail.TabIndex = 5;
            // 
            // txtTelephone
            // 
            txtTelephone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelephone.Font = new Font("Segoe UI", 9.75F);
            txtTelephone.Location = new Point(102, 195);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(500, 25);
            txtTelephone.TabIndex = 5;
            // 
            // txtBoitePostale
            // 
            txtBoitePostale.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoitePostale.Font = new Font("Segoe UI", 9.75F);
            txtBoitePostale.Location = new Point(102, 157);
            txtBoitePostale.Name = "txtBoitePostale";
            txtBoitePostale.Size = new Size(500, 25);
            txtBoitePostale.TabIndex = 5;
            // 
            // txtPays
            // 
            txtPays.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPays.Font = new Font("Segoe UI", 9.75F);
            txtPays.Location = new Point(102, 119);
            txtPays.Name = "txtPays";
            txtPays.Size = new Size(500, 25);
            txtPays.TabIndex = 5;
            // 
            // txtNomEcole
            // 
            txtNomEcole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNomEcole.Font = new Font("Segoe UI", 9.75F);
            txtNomEcole.Location = new Point(102, 67);
            txtNomEcole.Name = "txtNomEcole";
            txtNomEcole.Size = new Size(500, 25);
            txtNomEcole.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(235, 235, 235);
            tabPage1.Controls.Add(pnlBoutonConfig);
            tabPage1.Controls.Add(cbActiveBd);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(lblBdName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtNomBD);
            tabPage1.Controls.Add(txtActivePnl);
            tabPage1.Controls.Add(txtPassword);
            tabPage1.Controls.Add(txtUser);
            tabPage1.Controls.Add(txtServeur);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(867, 384);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Base des donner";
            // 
            // pnlBoutonConfig
            // 
            pnlBoutonConfig.Controls.Add(cbActive);
            pnlBoutonConfig.Controls.Add(btnBD_Supprimer);
            pnlBoutonConfig.Controls.Add(btn_Bd_initialiser);
            pnlBoutonConfig.Controls.Add(btnPardefault);
            pnlBoutonConfig.Controls.Add(btnAjouterElevesTeste);
            pnlBoutonConfig.Enabled = false;
            pnlBoutonConfig.Location = new Point(73, 280);
            pnlBoutonConfig.Name = "pnlBoutonConfig";
            pnlBoutonConfig.Size = new Size(695, 76);
            pnlBoutonConfig.TabIndex = 4;
            // 
            // cbActive
            // 
            cbActive.AutoSize = true;
            cbActive.Location = new Point(596, 30);
            cbActive.Name = "cbActive";
            cbActive.Size = new Size(15, 14);
            cbActive.TabIndex = 3;
            cbActive.UseVisualStyleBackColor = true;
            cbActive.CheckedChanged += cbActive_CheckedChanged;
            // 
            // btnBD_Supprimer
            // 
            btnBD_Supprimer.BackColor = Color.Transparent;
            btnBD_Supprimer.BorderColor = Color.White;
            btnBD_Supprimer.BorderRadius = 10;
            btnBD_Supprimer.BorderThickness = 0;
            btnBD_Supprimer.FlatAppearance.BorderSize = 0;
            btnBD_Supprimer.FlatStyle = FlatStyle.Flat;
            btnBD_Supprimer.ForeColor = Color.White;
            btnBD_Supprimer.GradientAngle = 90F;
            btnBD_Supprimer.GradientBottomColor = Color.Crimson;
            btnBD_Supprimer.GradientTopColor = Color.PaleVioletRed;
            btnBD_Supprimer.HoverBorderColor = Color.Transparent;
            btnBD_Supprimer.HoverBorderThickness = 0;
            btnBD_Supprimer.HoverGradientBottomColor = Color.DeepSkyBlue;
            btnBD_Supprimer.HoverGradientTopColor = Color.SkyBlue;
            btnBD_Supprimer.Location = new Point(128, 18);
            btnBD_Supprimer.Name = "btnBD_Supprimer";
            btnBD_Supprimer.PressedGradientBottomColor = Color.Crimson;
            btnBD_Supprimer.PressedGradientTopColor = Color.PaleVioletRed;
            btnBD_Supprimer.Size = new Size(104, 40);
            btnBD_Supprimer.TabIndex = 2;
            btnBD_Supprimer.Text = "Supprimer";
            btnBD_Supprimer.UseVisualStyleBackColor = false;
            btnBD_Supprimer.Click += btnBD_Supprimer_Click;
            // 
            // btn_Bd_initialiser
            // 
            btn_Bd_initialiser.BackColor = Color.Transparent;
            btn_Bd_initialiser.BorderColor = Color.White;
            btn_Bd_initialiser.BorderRadius = 10;
            btn_Bd_initialiser.BorderThickness = 0;
            btn_Bd_initialiser.FlatAppearance.BorderSize = 0;
            btn_Bd_initialiser.FlatStyle = FlatStyle.Flat;
            btn_Bd_initialiser.ForeColor = Color.White;
            btn_Bd_initialiser.GradientAngle = 90F;
            btn_Bd_initialiser.GradientBottomColor = Color.RoyalBlue;
            btn_Bd_initialiser.GradientTopColor = Color.DodgerBlue;
            btn_Bd_initialiser.HoverBorderColor = Color.Transparent;
            btn_Bd_initialiser.HoverBorderThickness = 0;
            btn_Bd_initialiser.HoverGradientBottomColor = Color.DeepSkyBlue;
            btn_Bd_initialiser.HoverGradientTopColor = Color.SkyBlue;
            btn_Bd_initialiser.Location = new Point(18, 18);
            btn_Bd_initialiser.Name = "btn_Bd_initialiser";
            btn_Bd_initialiser.PressedGradientBottomColor = Color.DarkBlue;
            btn_Bd_initialiser.PressedGradientTopColor = Color.MediumBlue;
            btn_Bd_initialiser.Size = new Size(104, 40);
            btn_Bd_initialiser.TabIndex = 2;
            btn_Bd_initialiser.Text = "Initialiser";
            btn_Bd_initialiser.UseVisualStyleBackColor = false;
            btn_Bd_initialiser.Click += btn_Bd_initialiser_Click;
            // 
            // btnPardefault
            // 
            btnPardefault.BackColor = Color.Transparent;
            btnPardefault.BorderColor = Color.White;
            btnPardefault.BorderRadius = 5;
            btnPardefault.BorderThickness = 0;
            btnPardefault.FlatAppearance.BorderSize = 0;
            btnPardefault.FlatStyle = FlatStyle.Flat;
            btnPardefault.ForeColor = Color.White;
            btnPardefault.GradientAngle = 90F;
            btnPardefault.GradientBottomColor = Color.RoyalBlue;
            btnPardefault.GradientTopColor = Color.DodgerBlue;
            btnPardefault.HoverBorderColor = Color.Transparent;
            btnPardefault.HoverBorderThickness = 0;
            btnPardefault.HoverGradientBottomColor = Color.DeepSkyBlue;
            btnPardefault.HoverGradientTopColor = Color.SkyBlue;
            btnPardefault.Location = new Point(251, 18);
            btnPardefault.Name = "btnPardefault";
            btnPardefault.PressedGradientBottomColor = Color.DarkBlue;
            btnPardefault.PressedGradientTopColor = Color.MediumBlue;
            btnPardefault.Size = new Size(161, 40);
            btnPardefault.TabIndex = 2;
            btnPardefault.Text = "Par défaut";
            btnPardefault.UseVisualStyleBackColor = false;
            btnPardefault.Click += btnPardefault_Click;
            // 
            // btnAjouterElevesTeste
            // 
            btnAjouterElevesTeste.BackColor = Color.Transparent;
            btnAjouterElevesTeste.BorderColor = Color.White;
            btnAjouterElevesTeste.BorderRadius = 5;
            btnAjouterElevesTeste.BorderThickness = 0;
            btnAjouterElevesTeste.FlatAppearance.BorderSize = 0;
            btnAjouterElevesTeste.FlatStyle = FlatStyle.Flat;
            btnAjouterElevesTeste.ForeColor = Color.White;
            btnAjouterElevesTeste.GradientAngle = 90F;
            btnAjouterElevesTeste.GradientBottomColor = Color.RoyalBlue;
            btnAjouterElevesTeste.GradientTopColor = Color.DodgerBlue;
            btnAjouterElevesTeste.HoverBorderColor = Color.Transparent;
            btnAjouterElevesTeste.HoverBorderThickness = 0;
            btnAjouterElevesTeste.HoverGradientBottomColor = Color.DeepSkyBlue;
            btnAjouterElevesTeste.HoverGradientTopColor = Color.SkyBlue;
            btnAjouterElevesTeste.Location = new Point(418, 18);
            btnAjouterElevesTeste.Name = "btnAjouterElevesTeste";
            btnAjouterElevesTeste.PressedGradientBottomColor = Color.DarkBlue;
            btnAjouterElevesTeste.PressedGradientTopColor = Color.MediumBlue;
            btnAjouterElevesTeste.Size = new Size(161, 40);
            btnAjouterElevesTeste.TabIndex = 2;
            btnAjouterElevesTeste.Text = "Eleves pour teste";
            btnAjouterElevesTeste.UseVisualStyleBackColor = false;
            btnAjouterElevesTeste.Click += btnAjouterElevesTeste_Click;
            // 
            // cbActiveBd
            // 
            cbActiveBd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbActiveBd.AutoSize = true;
            cbActiveBd.Location = new Point(1305, 18);
            cbActiveBd.Name = "cbActiveBd";
            cbActiveBd.Size = new Size(59, 19);
            cbActiveBd.TabIndex = 3;
            cbActiveBd.Text = "Active";
            cbActiveBd.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 167);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 1;
            label4.Text = "mot de passe";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 129);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 1;
            label5.Text = "Utilisateur";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 205);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 1;
            label3.Text = "Bd Nom";
            // 
            // lblBdName
            // 
            lblBdName.AutoSize = true;
            lblBdName.Font = new Font("Segoe UI", 12F);
            lblBdName.Location = new Point(22, 39);
            lblBdName.Name = "lblBdName";
            lblBdName.Size = new Size(133, 21);
            lblBdName.TabIndex = 1;
            lblBdName.Text = "Base des données";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 86);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Adresse";
            // 
            // txtNomBD
            // 
            txtNomBD.Enabled = false;
            txtNomBD.Font = new Font("Segoe UI", 14F);
            txtNomBD.Location = new Point(102, 191);
            txtNomBD.Name = "txtNomBD";
            txtNomBD.Size = new Size(319, 32);
            txtNomBD.TabIndex = 0;
            txtNomBD.Text = "financeBelElan_db";
            // 
            // txtActivePnl
            // 
            txtActivePnl.Font = new Font("Segoe UI", 14F);
            txtActivePnl.Location = new Point(427, 153);
            txtActivePnl.Name = "txtActivePnl";
            txtActivePnl.Size = new Size(74, 32);
            txtActivePnl.TabIndex = 0;
            txtActivePnl.UseSystemPasswordChar = true;
            txtActivePnl.TextChanged += txtActivePnl_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Font = new Font("Segoe UI", 14F);
            txtPassword.Location = new Point(102, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(319, 32);
            txtPassword.TabIndex = 0;
            // 
            // txtUser
            // 
            txtUser.Enabled = false;
            txtUser.Font = new Font("Segoe UI", 14F);
            txtUser.Location = new Point(102, 115);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(319, 32);
            txtUser.TabIndex = 0;
            txtUser.Text = "root";
            // 
            // txtServeur
            // 
            txtServeur.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServeur.Enabled = false;
            txtServeur.Font = new Font("Segoe UI", 14F);
            txtServeur.Location = new Point(102, 77);
            txtServeur.Name = "txtServeur";
            txtServeur.Size = new Size(687, 32);
            txtServeur.TabIndex = 0;
            txtServeur.Text = "localhost";
            // 
            // UC_Paramettre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "UC_Paramettre";
            Padding = new Padding(2, 2, 2, 10);
            Size = new Size(879, 488);
            Load += UC_Paramettre_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            pnlBoutonConfig.ResumeLayout(false);
            pnlBoutonConfig.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Label label7;
        private Label label9;
        private Label label10;
        private TextBox txtNomEcole;
        private TabPage tabPage1;
        private CheckBox cbActiveBd;
        private imj_Tools.Bouton_rond btnBD_Supprimer;
        private imj_Tools.Bouton_rond btnPardefault;
        private imj_Tools.Bouton_rond btn_Bd_initialiser;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label lblBdName;
        private Label label2;
        private TextBox txtNomBD;
        private TextBox txtPassword;
        private TextBox txtUser;
        private TextBox txtServeur;
        private Button btnChoisirLogo;
        private Button btnEnregistrer;
        private Label label11;
        private Label label8;
        private Label label6;
        private TextBox txtEmail;
        private TextBox txtTelephone;
        private TextBox txtBoitePostale;
        private TextBox txtPays;
        private Label label12;
        private TextBox txtMinistere;
        private TextBox txtAdresse;
        private Label label13;
        private PictureBox pbLogo;
        private imj_Tools.Bouton_rond btnAjouterElevesTeste;
        private Panel pnlBoutonConfig;
        private CheckBox cbActive;
        private TextBox txtActivePnl;
    }
}
