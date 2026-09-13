namespace FINANCIERE_SCOLAIRE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnLogin = new Button();
            label3 = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            btnOeil = new Button();
            label2 = new Label();
            label1 = new Label();
            lblInfoUser = new Label();
            btnDefault = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.logoBelElan;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(397, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.69841F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.30159F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.999999F));
            tableLayoutPanel1.Controls.Add(btnLogin, 1, 4);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 3);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 2);
            tableLayoutPanel1.Controls.Add(btnOeil, 2, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(lblInfoUser, 1, 1);
            tableLayoutPanel1.ForeColor = SystemColors.AppWorkspace;
            tableLayoutPanel1.Location = new Point(128, 159);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21.0300426F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.446352F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0634918F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0634918F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.74603F));
            tableLayoutPanel1.Size = new Size(631, 262);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(0, 0, 192);
            btnLogin.Location = new Point(146, 199);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(418, 39);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(146, 7);
            label3.Name = "label3";
            label3.Size = new Size(418, 40);
            label3.TabIndex = 3;
            label3.Text = "Connection";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI", 14F);
            txtPassword.Location = new Point(146, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(418, 32);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 14F);
            txtEmail.Location = new Point(146, 93);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(418, 32);
            txtEmail.TabIndex = 1;
            // 
            // btnOeil
            // 
            btnOeil.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnOeil.BackgroundImage = Properties.Resources.icons8_visible_25px;
            btnOeil.BackgroundImageLayout = ImageLayout.Zoom;
            btnOeil.Location = new Point(570, 134);
            btnOeil.Name = "btnOeil";
            btnOeil.Size = new Size(58, 38);
            btnOeil.TabIndex = 3;
            btnOeil.UseVisualStyleBackColor = true;
            btnOeil.Click += btnOeil_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(3, 140);
            label2.Name = "label2";
            label2.Size = new Size(137, 25);
            label2.TabIndex = 0;
            label2.Text = "Mot de passe";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(3, 96);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 0;
            label1.Text = "Identifiant";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblInfoUser
            // 
            lblInfoUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblInfoUser.AutoSize = true;
            lblInfoUser.BackColor = Color.Transparent;
            lblInfoUser.Font = new Font("Segoe UI", 12F);
            lblInfoUser.ForeColor = Color.FromArgb(192, 192, 255);
            lblInfoUser.Location = new Point(146, 60);
            lblInfoUser.Name = "lblInfoUser";
            lblInfoUser.Size = new Size(418, 21);
            lblInfoUser.TabIndex = 2;
            lblInfoUser.Text = "Nom User";
            lblInfoUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDefault
            // 
            btnDefault.FlatStyle = FlatStyle.Flat;
            btnDefault.Location = new Point(2, 3);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new Size(34, 23);
            btnDefault.TabIndex = 8;
            btnDefault.Text = "P";
            btnDefault.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RoyalBlue;
            ClientSize = new Size(886, 512);
            Controls.Add(btnDefault);
            Controls.Add(pictureBox1);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLogin;
        private Label label3;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Button btnOeil;
        private Label label2;
        private Label label1;
        private Label lblInfoUser;
        private Button btnDefault;
    }
}
