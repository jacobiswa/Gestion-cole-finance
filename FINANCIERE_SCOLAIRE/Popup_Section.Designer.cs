namespace FINANCIERE_SCOLAIRE
{
    partial class Popup_Section
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
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            btnAjouterOption = new Button();
            btnAjouterSection = new Button();
            txtNomOption = new TextBox();
            txtNomSection = new TextBox();
            label5 = new Label();
            label2 = new Label();
            label6 = new Label();
            cmbSections = new ComboBox();
            btnSupprimerSection = new Button();
            btnSupprimerOption = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(88, 9);
            label1.Name = "label1";
            label1.Size = new Size(491, 45);
            label1.TabIndex = 0;
            label1.Text = "Ajouter des Sections et Options";
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.header1;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(663, 63);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(663, 1);
            panel2.TabIndex = 2;
            // 
            // btnAjouterOption
            // 
            btnAjouterOption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterOption.Location = new Point(389, 165);
            btnAjouterOption.Name = "btnAjouterOption";
            btnAjouterOption.Size = new Size(159, 35);
            btnAjouterOption.TabIndex = 27;
            btnAjouterOption.Text = "Ajouter Option";
            btnAjouterOption.UseVisualStyleBackColor = true;
            btnAjouterOption.Click += btnAjouterOption_Click;
            // 
            // btnAjouterSection
            // 
            btnAjouterSection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjouterSection.Location = new Point(389, 99);
            btnAjouterSection.Name = "btnAjouterSection";
            btnAjouterSection.Size = new Size(159, 35);
            btnAjouterSection.TabIndex = 28;
            btnAjouterSection.Text = "Ajouter Section";
            btnAjouterSection.UseVisualStyleBackColor = true;
            btnAjouterSection.Click += btnAjouterSection_Click;
            // 
            // txtNomOption
            // 
            txtNomOption.Font = new Font("Segoe UI", 14.25F);
            txtNomOption.Location = new Point(32, 167);
            txtNomOption.Name = "txtNomOption";
            txtNomOption.Size = new Size(351, 33);
            txtNomOption.TabIndex = 25;
            // 
            // txtNomSection
            // 
            txtNomSection.Font = new Font("Segoe UI", 14.25F);
            txtNomSection.Location = new Point(32, 99);
            txtNomSection.Name = "txtNomSection";
            txtNomSection.Size = new Size(351, 33);
            txtNomSection.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 81);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 29;
            label5.Text = "Nom de la sélection";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 149);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 29;
            label2.Text = "Nom de l'option";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(32, 216);
            label6.Name = "label6";
            label6.Size = new Size(164, 15);
            label6.TabIndex = 31;
            label6.Text = "Sélectionner la section à gérer";
            // 
            // cmbSections
            // 
            cmbSections.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSections.FormattingEnabled = true;
            cmbSections.Location = new Point(32, 234);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(353, 29);
            cmbSections.TabIndex = 30;
            // 
            // btnSupprimerSection
            // 
            btnSupprimerSection.Enabled = false;
            btnSupprimerSection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupprimerSection.Location = new Point(554, 99);
            btnSupprimerSection.Name = "btnSupprimerSection";
            btnSupprimerSection.Size = new Size(97, 35);
            btnSupprimerSection.TabIndex = 28;
            btnSupprimerSection.Text = "Supprimer";
            btnSupprimerSection.UseVisualStyleBackColor = true;
            btnSupprimerSection.Click += btnSupprimerSection_Click;
            // 
            // btnSupprimerOption
            // 
            btnSupprimerOption.Enabled = false;
            btnSupprimerOption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupprimerOption.Location = new Point(554, 165);
            btnSupprimerOption.Name = "btnSupprimerOption";
            btnSupprimerOption.Size = new Size(97, 35);
            btnSupprimerOption.TabIndex = 28;
            btnSupprimerOption.Text = "Supprimer";
            btnSupprimerOption.UseVisualStyleBackColor = true;
            btnSupprimerOption.Click += btnSupprimerOption_Click;
            // 
            // Popup_Section
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 315);
            Controls.Add(label6);
            Controls.Add(cmbSections);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(btnAjouterOption);
            Controls.Add(btnSupprimerOption);
            Controls.Add(btnSupprimerSection);
            Controls.Add(btnAjouterSection);
            Controls.Add(txtNomOption);
            Controls.Add(txtNomSection);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(64, 64, 64);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Popup_Section";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popup_Section";
            Load += Popup_Section_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Button btnAjouterOption;
        private Button btnAjouterSection;
        private TextBox txtNomOption;
        private TextBox txtNomSection;
        private Label label5;
        private Label label2;
        private Label label6;
        private ComboBox cmbSections;
        private Button btnSupprimerSection;
        private Button btnSupprimerOption;
    }
}