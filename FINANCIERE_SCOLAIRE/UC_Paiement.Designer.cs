namespace FINANCIERE_SCOLAIRE
{
    partial class UC_Paiement
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
            panel1 = new Panel();
            label5 = new Label();
            btnValiderPaiement = new Button();
            txtRechercherHistorique = new TextBox();
            dgvPaiements = new DataGridView();
            panel7 = new Panel();
            label1 = new Label();
            panel_rond1 = new imj_Tools.Panel_rond();
            lblNbrPaiement = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaiements).BeginInit();
            panel7.SuspendLayout();
            panel_rond1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnValiderPaiement);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 0, 10, 0);
            panel1.Size = new Size(751, 71);
            panel1.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(224, 224, 224);
            label5.Location = new Point(488, 26);
            label5.Name = "label5";
            label5.Size = new Size(255, 21);
            label5.TabIndex = 19;
            label5.Text = "Caisse, Paiements et Facturation";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnValiderPaiement
            // 
            btnValiderPaiement.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnValiderPaiement.ForeColor = Color.Black;
            btnValiderPaiement.Location = new Point(13, 6);
            btnValiderPaiement.Name = "btnValiderPaiement";
            btnValiderPaiement.Size = new Size(167, 62);
            btnValiderPaiement.TabIndex = 14;
            btnValiderPaiement.Text = "ValidePaiement";
            btnValiderPaiement.UseVisualStyleBackColor = true;
            btnValiderPaiement.Click += btnValiderPaiement_Click_1;
            // 
            // txtRechercherHistorique
            // 
            txtRechercherHistorique.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRechercherHistorique.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRechercherHistorique.Location = new Point(13, 100);
            txtRechercherHistorique.Name = "txtRechercherHistorique";
            txtRechercherHistorique.Size = new Size(504, 33);
            txtRechercherHistorique.TabIndex = 20;
            txtRechercherHistorique.TextChanged += txtRechercherHistorique_TextChanged;
            // 
            // dgvPaiements
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dgvPaiements.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPaiements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPaiements.BackgroundColor = Color.White;
            dgvPaiements.BorderStyle = BorderStyle.None;
            dgvPaiements.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPaiements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPaiements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPaiements.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPaiements.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPaiements.Dock = DockStyle.Fill;
            dgvPaiements.EnableHeadersVisualStyles = false;
            dgvPaiements.GridColor = Color.White;
            dgvPaiements.Location = new Point(10, 10);
            dgvPaiements.MultiSelect = false;
            dgvPaiements.Name = "dgvPaiements";
            dgvPaiements.ReadOnly = true;
            dgvPaiements.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPaiements.RowHeadersVisible = false;
            dgvPaiements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaiements.Size = new Size(708, 222);
            dgvPaiements.TabIndex = 13;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(dgvPaiements);
            panel7.Location = new Point(10, 145);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10);
            panel7.Size = new Size(728, 242);
            panel7.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 80);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 21;
            label1.Text = "Filtre";
            // 
            // panel_rond1
            // 
            panel_rond1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel_rond1.BorderColor = Color.White;
            panel_rond1.BorderRadius = 5;
            panel_rond1.BorderThickness = 2;
            panel_rond1.Controls.Add(lblNbrPaiement);
            panel_rond1.GradientAngle = 90F;
            panel_rond1.GradientBottomColor = Color.LightGray;
            panel_rond1.GradientTopColor = Color.White;
            panel_rond1.Location = new Point(574, 87);
            panel_rond1.Name = "panel_rond1";
            panel_rond1.Padding = new Padding(10, 0, 10, 0);
            panel_rond1.Size = new Size(164, 46);
            panel_rond1.TabIndex = 31;
            // 
            // lblNbrPaiement
            // 
            lblNbrPaiement.BackColor = Color.Transparent;
            lblNbrPaiement.Dock = DockStyle.Fill;
            lblNbrPaiement.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNbrPaiement.Location = new Point(10, 0);
            lblNbrPaiement.Name = "lblNbrPaiement";
            lblNbrPaiement.Size = new Size(144, 46);
            lblNbrPaiement.TabIndex = 0;
            lblNbrPaiement.Text = "00";
            lblNbrPaiement.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_Paiement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_rond1);
            Controls.Add(label1);
            Controls.Add(panel7);
            Controls.Add(txtRechercherHistorique);
            Controls.Add(panel1);
            Name = "UC_Paiement";
            Size = new Size(751, 400);
            Load += UC_Paiement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaiements).EndInit();
            panel7.ResumeLayout(false);
            panel_rond1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Button btnValiderPaiement;
        private DataGridView dgvPaiements;
        private Panel panel7;
        private TextBox txtRechercherHistorique;
        private Label label1;
        private imj_Tools.Panel_rond panel_rond1;
        private Label lblNbrPaiement;
    }
}
