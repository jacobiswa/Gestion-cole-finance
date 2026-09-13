using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;

namespace FINANCIERE_SCOLAIRE
{
    public partial class Form1 : Form
    {
        Logique log = new Logique();
        Connexion_db bd = new Connexion_db();
        public Form1()
        {
            InitializeComponent();
        }
        bool passwordVisible = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Text = log.RestaurerDernierUser();
            txtPassword.Text = log.RestaurerDerniers_Pass();
            if (txtEmail.Text != "")
            {
                txtPassword.Focus();
            }
        }
    
        private void btnOeil_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                txtPassword.UseSystemPasswordChar = true;
                passwordVisible = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                passwordVisible = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin_Click(null, null);
                }
            }
        }

    

        private void btnDefault_Click(object sender, EventArgs e)
        {
            bd.Initialize_db();
          
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string identifier = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validation des champs
            if (string.IsNullOrEmpty(identifier) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir votre nom d'utilisateur et votre mot de passe.",
                                "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sauvegarde temporaire des champs si nécessaire
            log.EnregistrerDernierUser(identifier);
            log.EnregistrerDerniers_Pass(password);

            // Vérification dans la base de données
            UtilisateurSession session = bd.Authentifier(identifier, password);

            if (session != null)
            {
                // Enregistrer une trace d'audit
                EnregistrerLogAudit(session.Id, "Connexion", $"L'utilisateur {session.NomComplet} s'est connecté.");

                // Passer la session au DashBoard_fm via son constructeur
                DashBoard_fm dashboard = new DashBoard_fm();
                dashboard.userName = session.NomComplet;
                dashboard.Show();

                this.Hide();
                dashboard.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.",
                                "Échec de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Méthode helper optionnelle pour enregistrer l'action dans LogsAudit
        private void EnregistrerLogAudit(int utilisateurId, string action, string details)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(bd.ConnectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO LogsAudit (UtilisateurId, Action, Details) 
                            VALUES (@userId, @action, @details)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", utilisateurId);
                        cmd.Parameters.AddWithValue("@action", action);
                        cmd.Parameters.AddWithValue("@details", details);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Gestion discrète des erreurs de logs d'audit
            }
        }
    }
}
