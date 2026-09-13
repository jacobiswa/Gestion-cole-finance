namespace FINANCIERE_SCOLAIRE
{
    partial class Infos_eleve_fm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infos_eleve_fm));
            panel2 = new Panel();
            btnExporterFichePDF = new Button();
            lblTitre = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            rtbFiche = new RichTextBox();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.header11;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(btnExporterFichePDF);
            panel2.Controls.Add(lblTitre);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 63);
            panel2.TabIndex = 2;
            // 
            // btnExporterFichePDF
            // 
            btnExporterFichePDF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExporterFichePDF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExporterFichePDF.Location = new Point(618, 9);
            btnExporterFichePDF.Name = "btnExporterFichePDF";
            btnExporterFichePDF.Size = new Size(152, 48);
            btnExporterFichePDF.TabIndex = 5;
            btnExporterFichePDF.Text = "Exporter En pdf";
            btnExporterFichePDF.UseVisualStyleBackColor = true;
            btnExporterFichePDF.Click += btnExporterFichePDF_Click;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.BackColor = Color.Transparent;
            lblTitre.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(303, 9);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(166, 40);
            lblTitre.TabIndex = 4;
            lblTitre.Text = "Fiche Elève";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 505);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 1);
            panel3.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 63);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(30, 10, 30, 10);
            panel4.Size = new Size(800, 442);
            panel4.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(rtbFiche);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(30, 10);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(30, 5, 30, 5);
            panel5.Size = new Size(740, 422);
            panel5.TabIndex = 1;
            // 
            // rtbFiche
            // 
            rtbFiche.BackColor = Color.White;
            rtbFiche.BorderStyle = BorderStyle.None;
            rtbFiche.Dock = DockStyle.Fill;
            rtbFiche.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbFiche.Location = new Point(30, 5);
            rtbFiche.Name = "rtbFiche";
            rtbFiche.ReadOnly = true;
            rtbFiche.Size = new Size(680, 412);
            rtbFiche.TabIndex = 0;
            rtbFiche.Text = "";
            // 
            // Infos_eleve_fm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 506);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Infos_eleve_fm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Infos_eleve_fm";
            Load += Infos_eleve_fm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label lblTitre;
        private Panel panel3;
        private Panel panel4;
        private RichTextBox rtbFiche;
        private Panel panel5;
        private Button btnExporterFichePDF;
    }
}