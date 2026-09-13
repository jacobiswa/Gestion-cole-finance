namespace FINANCIERE_SCOLAIRE
{
    partial class Popup_Classe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup_Classe));
            panel1 = new Panel();
            lblTitre = new Label();
            panel2 = new Panel();
            txtNomClasse = new TextBox();
            btnAjouterClasse = new Button();
            cmbOptions = new ComboBox();
            cmbSections = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSupprimerClasse = new Button();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.header1;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(lblTitre);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 63);
            panel1.TabIndex = 2;
            // 
            // lblTitre
            // 
            lblTitre.Anchor = AnchorStyles.Top;
            lblTitre.AutoSize = true;
            lblTitre.BackColor = Color.Transparent;
            lblTitre.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(243, 9);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(307, 45);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Ajouter des Classes";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(774, 1);
            panel2.TabIndex = 3;
            // 
            // txtNomClasse
            // 
            txtNomClasse.Font = new Font("Segoe UI", 14.25F);
            txtNomClasse.Location = new Point(33, 122);
            txtNomClasse.Name = "txtNomClasse";
            txtNomClasse.Size = new Size(714, 33);
            txtNomClasse.TabIndex = 34;
            // 
            // btnAjouterClasse
            // 
            btnAjouterClasse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterClasse.Location = new Point(32, 266);
            btnAjouterClasse.Name = "btnAjouterClasse";
            btnAjouterClasse.Size = new Size(159, 35);
            btnAjouterClasse.TabIndex = 33;
            btnAjouterClasse.Text = "Ajouter Classe";
            btnAjouterClasse.UseVisualStyleBackColor = true;
            btnAjouterClasse.Click += btnAjouterClasse_Click;
            // 
            // cmbOptions
            // 
            cmbOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOptions.Font = new Font("Segoe UI", 14.25F);
            cmbOptions.FormattingEnabled = true;
            cmbOptions.Location = new Point(409, 191);
            cmbOptions.Name = "cmbOptions";
            cmbOptions.Size = new Size(338, 33);
            cmbOptions.TabIndex = 30;
            // 
            // cmbSections
            // 
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Font = new Font("Segoe UI", 14.25F);
            cmbSections.FormattingEnabled = true;
            cmbSections.Location = new Point(33, 191);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(338, 33);
            cmbSections.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 173);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 35;
            label4.Text = "Section";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 173);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 35;
            label2.Text = "Option";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 104);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 35;
            label3.Text = "Classe";
            // 
            // btnSupprimerClasse
            // 
            btnSupprimerClasse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupprimerClasse.Location = new Point(197, 266);
            btnSupprimerClasse.Name = "btnSupprimerClasse";
            btnSupprimerClasse.Size = new Size(159, 35);
            btnSupprimerClasse.TabIndex = 36;
            btnSupprimerClasse.Text = "Supprimer Classe";
            btnSupprimerClasse.UseVisualStyleBackColor = true;
            btnSupprimerClasse.Visible = false;
            btnSupprimerClasse.Click += btnSupprimerClasse_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(12, 67);
            label6.Name = "label6";
            label6.Size = new Size(533, 21);
            label6.TabIndex = 35;
            label6.Text = "Permet d'ajouter, modifier ou structurer les classes par section et par option";
            // 
            // Popup_Classe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 342);
            Controls.Add(btnSupprimerClasse);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(txtNomClasse);
            Controls.Add(btnAjouterClasse);
            Controls.Add(cmbOptions);
            Controls.Add(cmbSections);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(64, 64, 64);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Popup_Classe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popup_Classe";
            Load += Popup_Classe_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitre;
        private Panel panel2;
        private TextBox txtNomClasse;
        private Button btnAjouterClasse;
        private ComboBox cmbOptions;
        private ComboBox cmbSections;
        private Label label4;
        private Label label2;
        private Label label3;
        private Button btnSupprimerClasse;
        private Label label6;
    }
}