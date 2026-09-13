namespace FINANCIERE_SCOLAIRE
{
    partial class Popup_Eleve
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
            panel2 = new Panel();
            lblTitre = new Label();
            btnAjouterEleve = new Button();
            panel1 = new Panel();
            pnlForm = new Panel();
            btnSupprimerEleve = new Button();
            groupBox3 = new GroupBox();
            cmbSection = new ComboBox();
            label7 = new Label();
            cmbOption = new ComboBox();
            label8 = new Label();
            cmbClasse = new ComboBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            label10 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtPostnom = new TextBox();
            txtPrenom = new TextBox();
            txtNom = new TextBox();
            mtxtTelTuteur = new MaskedTextBox();
            groupBox1 = new GroupBox();
            rbSexeF = new RadioButton();
            rbSexeM = new RadioButton();
            txtAdresse = new TextBox();
            cmbTypeEleve = new ComboBox();
            label14 = new Label();
            label6 = new Label();
            label3 = new Label();
            txtNomTuteur = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label1 = new Label();
            dtpDateNaissance = new DateTimePicker();
            txtLieuNaissance = new TextBox();
            txtMatricule = new TextBox();
            panel2.SuspendLayout();
            pnlForm.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.header11;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(lblTitre);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(897, 63);
            panel2.TabIndex = 1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.BackColor = Color.Transparent;
            lblTitre.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(52, 9);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(88, 40);
            lblTitre.TabIndex = 4;
            lblTitre.Text = "Eleve";
            // 
            // btnAjouterEleve
            // 
            btnAjouterEleve.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterEleve.Location = new Point(667, 397);
            btnAjouterEleve.Name = "btnAjouterEleve";
            btnAjouterEleve.Size = new Size(198, 44);
            btnAjouterEleve.TabIndex = 0;
            btnAjouterEleve.Text = "Inscrire";
            btnAjouterEleve.UseVisualStyleBackColor = true;
            btnAjouterEleve.Click += btnAjouterEleve_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 1);
            panel1.TabIndex = 2;
            // 
            // pnlForm
            // 
            pnlForm.AutoScroll = true;
            pnlForm.Controls.Add(btnSupprimerEleve);
            pnlForm.Controls.Add(btnAjouterEleve);
            pnlForm.Controls.Add(groupBox3);
            pnlForm.Controls.Add(groupBox2);
            pnlForm.Controls.Add(mtxtTelTuteur);
            pnlForm.Controls.Add(groupBox1);
            pnlForm.Controls.Add(txtAdresse);
            pnlForm.Controls.Add(cmbTypeEleve);
            pnlForm.Controls.Add(label14);
            pnlForm.Controls.Add(label6);
            pnlForm.Controls.Add(label3);
            pnlForm.Controls.Add(txtNomTuteur);
            pnlForm.Controls.Add(label13);
            pnlForm.Controls.Add(label12);
            pnlForm.Controls.Add(label11);
            pnlForm.Controls.Add(label1);
            pnlForm.Controls.Add(dtpDateNaissance);
            pnlForm.Controls.Add(txtLieuNaissance);
            pnlForm.Controls.Add(txtMatricule);
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.ForeColor = SystemColors.HotTrack;
            pnlForm.Location = new Point(0, 64);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(10);
            pnlForm.Size = new Size(897, 468);
            pnlForm.TabIndex = 3;
            // 
            // btnSupprimerEleve
            // 
            btnSupprimerEleve.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupprimerEleve.Location = new Point(501, 397);
            btnSupprimerEleve.Name = "btnSupprimerEleve";
            btnSupprimerEleve.Size = new Size(137, 44);
            btnSupprimerEleve.TabIndex = 0;
            btnSupprimerEleve.Text = "SupprimerEleve";
            btnSupprimerEleve.UseVisualStyleBackColor = true;
            btnSupprimerEleve.Click += btnSupprimerEleve_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbSection);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(cmbOption);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(cmbClasse);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(495, 21);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(389, 172);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Choix ";
            // 
            // cmbSection
            // 
            cmbSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.Font = new Font("Segoe UI", 12F);
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(6, 34);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(366, 29);
            cmbSection.TabIndex = 3;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 16);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 4;
            label7.Text = "Section";
            // 
            // cmbOption
            // 
            cmbOption.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbOption.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOption.Font = new Font("Segoe UI", 12F);
            cmbOption.FormattingEnabled = true;
            cmbOption.Location = new Point(6, 82);
            cmbOption.Name = "cmbOption";
            cmbOption.Size = new Size(366, 29);
            cmbOption.TabIndex = 3;
            cmbOption.SelectedIndexChanged += cmbOption_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 64);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 4;
            label8.Text = "Option";
            // 
            // cmbClasse
            // 
            cmbClasse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbClasse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasse.Font = new Font("Segoe UI", 12F);
            cmbClasse.FormattingEnabled = true;
            cmbClasse.Location = new Point(6, 135);
            cmbClasse.Name = "cmbClasse";
            cmbClasse.Size = new Size(366, 29);
            cmbClasse.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 117);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 4;
            label9.Text = "Classe";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtPostnom);
            groupBox2.Controls.Add(txtPrenom);
            groupBox2.Controls.Add(txtNom);
            groupBox2.Location = new Point(19, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(440, 122);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Saisie de l'identité de l'élève.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 69);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
            label10.TabIndex = 8;
            label10.Text = "PostNom";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 19);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 9;
            label4.Text = "PreNom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 10;
            label2.Text = "Nom";
            // 
            // txtPostnom
            // 
            txtPostnom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPostnom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPostnom.Location = new Point(6, 87);
            txtPostnom.Name = "txtPostnom";
            txtPostnom.Size = new Size(419, 29);
            txtPostnom.TabIndex = 5;
            // 
            // txtPrenom
            // 
            txtPrenom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrenom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrenom.Location = new Point(268, 37);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(157, 29);
            txtPrenom.TabIndex = 6;
            // 
            // txtNom
            // 
            txtNom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNom.Location = new Point(6, 37);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(255, 29);
            txtNom.TabIndex = 7;
            // 
            // mtxtTelTuteur
            // 
            mtxtTelTuteur.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mtxtTelTuteur.Location = new Point(499, 346);
            mtxtTelTuteur.Mask = "+24300 000 00 00";
            mtxtTelTuteur.Name = "mtxtTelTuteur";
            mtxtTelTuteur.Size = new Size(368, 29);
            mtxtTelTuteur.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbSexeF);
            groupBox1.Controls.Add(rbSexeM);
            groupBox1.Location = new Point(19, 198);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 47);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Genre";
            // 
            // rbSexeF
            // 
            rbSexeF.AutoSize = true;
            rbSexeF.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rbSexeF.ForeColor = Color.Black;
            rbSexeF.Location = new Point(105, 16);
            rbSexeF.Name = "rbSexeF";
            rbSexeF.Size = new Size(36, 25);
            rbSexeF.TabIndex = 1;
            rbSexeF.TabStop = true;
            rbSexeF.Text = "F";
            rbSexeF.UseVisualStyleBackColor = true;
            // 
            // rbSexeM
            // 
            rbSexeM.AutoSize = true;
            rbSexeM.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rbSexeM.ForeColor = Color.Black;
            rbSexeM.Location = new Point(44, 16);
            rbSexeM.Name = "rbSexeM";
            rbSexeM.Size = new Size(43, 25);
            rbSexeM.TabIndex = 1;
            rbSexeM.TabStop = true;
            rbSexeM.Text = "M";
            rbSexeM.UseVisualStyleBackColor = true;
            // 
            // txtAdresse
            // 
            txtAdresse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdresse.Location = new Point(19, 346);
            txtAdresse.Multiline = true;
            txtAdresse.Name = "txtAdresse";
            txtAdresse.Size = new Size(425, 95);
            txtAdresse.TabIndex = 0;
            // 
            // cmbTypeEleve
            // 
            cmbTypeEleve.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeEleve.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTypeEleve.FormattingEnabled = true;
            cmbTypeEleve.Location = new Point(495, 227);
            cmbTypeEleve.Name = "cmbTypeEleve";
            cmbTypeEleve.Size = new Size(370, 29);
            cmbTypeEleve.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(19, 327);
            label14.Name = "label14";
            label14.Size = new Size(99, 15);
            label14.TabIndex = 4;
            label14.Text = "Adresse Physique";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 268);
            label6.Name = "label6";
            label6.Size = new Size(101, 15);
            label6.TabIndex = 4;
            label6.Text = "Lieu de Naissance";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 204);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 4;
            label3.Text = "Date de naissance";
            // 
            // txtNomTuteur
            // 
            txtNomTuteur.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomTuteur.Location = new Point(497, 287);
            txtNomTuteur.Name = "txtNomTuteur";
            txtNomTuteur.Size = new Size(370, 29);
            txtNomTuteur.TabIndex = 0;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(495, 327);
            label13.Name = "label13";
            label13.Size = new Size(114, 15);
            label13.TabIndex = 4;
            label13.Text = "Tél Tuteur ou Parent";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(499, 268);
            label12.Name = "label12";
            label12.Size = new Size(72, 15);
            label12.TabIndex = 4;
            label12.Text = "Nom Tuteur";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(491, 208);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 4;
            label11.Text = "TypeEleve";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 17);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Matricule";
            // 
            // dtpDateNaissance
            // 
            dtpDateNaissance.Location = new Point(183, 222);
            dtpDateNaissance.Name = "dtpDateNaissance";
            dtpDateNaissance.Size = new Size(200, 23);
            dtpDateNaissance.TabIndex = 2;
            // 
            // txtLieuNaissance
            // 
            txtLieuNaissance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLieuNaissance.Location = new Point(25, 286);
            txtLieuNaissance.Name = "txtLieuNaissance";
            txtLieuNaissance.Size = new Size(419, 29);
            txtLieuNaissance.TabIndex = 0;
            // 
            // txtMatricule
            // 
            txtMatricule.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatricule.Location = new Point(15, 35);
            txtMatricule.Name = "txtMatricule";
            txtMatricule.ReadOnly = true;
            txtMatricule.Size = new Size(364, 29);
            txtMatricule.TabIndex = 0;
            // 
            // Popup_Eleve
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(897, 532);
            Controls.Add(pnlForm);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Popup_Eleve";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popup_Eleve";
            Load += Popup_Eleve_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnAjouterEleve;
        private Panel panel1;
        private Label lblTitre;
        private Panel pnlForm;
        private GroupBox groupBox3;
        private ComboBox cmbSection;
        private Label label7;
        private ComboBox cmbOption;
        private Label label8;
        private ComboBox cmbClasse;
        private Label label9;
        private GroupBox groupBox2;
        private Label label10;
        private Label label4;
        private Label label2;
        private TextBox txtPostnom;
        private TextBox txtPrenom;
        private TextBox txtNom;
        private MaskedTextBox mtxtTelTuteur;
        private GroupBox groupBox1;
        private RadioButton rbSexeF;
        private RadioButton rbSexeM;
        private TextBox txtAdresse;
        private ComboBox cmbTypeEleve;
        private Label label14;
        private Label label6;
        private Label label3;
        private TextBox txtNomTuteur;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label1;
        private DateTimePicker dtpDateNaissance;
        private TextBox txtLieuNaissance;
        private TextBox txtMatricule;
        private Button btnSupprimerEleve;
    }
}