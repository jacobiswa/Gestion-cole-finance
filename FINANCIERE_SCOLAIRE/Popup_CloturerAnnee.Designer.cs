namespace FINANCIERE_SCOLAIRE
{
    partial class Popup_CloturerAnnee
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
            panel8 = new Panel();
            lblInfoAnnee = new Label();
            panel1 = new Panel();
            label3 = new Label();
            btnAnnuler = new Button();
            btnCloturerAnnee = new Button();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(255, 192, 192);
            panel8.Controls.Add(lblInfoAnnee);
            panel8.Controls.Add(panel1);
            panel8.Controls.Add(label3);
            panel8.Controls.Add(btnAnnuler);
            panel8.Controls.Add(btnCloturerAnnee);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(552, 208);
            panel8.TabIndex = 22;
            // 
            // lblInfoAnnee
            // 
            lblInfoAnnee.Dock = DockStyle.Top;
            lblInfoAnnee.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoAnnee.ForeColor = Color.FromArgb(192, 0, 0);
            lblInfoAnnee.Location = new Point(0, 104);
            lblInfoAnnee.Name = "lblInfoAnnee";
            lblInfoAnnee.Size = new Size(552, 34);
            lblInfoAnnee.TabIndex = 21;
            lblInfoAnnee.Text = "InfoAnnee";
            lblInfoAnnee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 128, 128);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 103);
            panel1.Name = "panel1";
            panel1.Size = new Size(552, 1);
            panel1.TabIndex = 20;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(552, 103);
            label3.TabIndex = 19;
            label3.Text = "Lorsque vous clôturez une année, \r\nla modification des paiements \r\nde cette année sera bloquée.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Anchor = AnchorStyles.Bottom;
            btnAnnuler.BackColor = Color.White;
            btnAnnuler.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnnuler.ForeColor = Color.FromArgb(192, 0, 0);
            btnAnnuler.Location = new Point(370, 160);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(126, 36);
            btnAnnuler.TabIndex = 4;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnCloturerAnnee
            // 
            btnCloturerAnnee.Anchor = AnchorStyles.Bottom;
            btnCloturerAnnee.BackColor = Color.FromArgb(192, 64, 0);
            btnCloturerAnnee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCloturerAnnee.ForeColor = Color.White;
            btnCloturerAnnee.Location = new Point(27, 160);
            btnCloturerAnnee.Name = "btnCloturerAnnee";
            btnCloturerAnnee.Size = new Size(337, 36);
            btnCloturerAnnee.TabIndex = 4;
            btnCloturerAnnee.Text = "Confirmer";
            btnCloturerAnnee.UseVisualStyleBackColor = false;
            btnCloturerAnnee.Click += btnCloturerAnnee_Click;
            // 
            // Popup_CloturerAnnee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(552, 208);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Popup_CloturerAnnee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CloturerAnnee";
            Load += Popup_CloturerAnnee_Load;
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel8;
        private Panel panel1;
        private Label label3;
        private Button btnCloturerAnnee;
        private Label lblInfoAnnee;
        private Button btnAnnuler;
    }
}