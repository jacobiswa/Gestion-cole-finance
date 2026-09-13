using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public partial class UC_Paramettre : UserControl
    {
        public UC_Paramettre()
        {
            InitializeComponent();
        }

        Connexion_db db = new Connexion_db();
        Logique log = new Logique();

        private void UC_Paramettre_Load(object sender, EventArgs e)
        {
            ChargerParametres();
        }
        private void ChargerParametres()
        {
            string query = "SELECT * FROM Paramettres LIMIT 1;";

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPays.Text = reader["Pays"].ToString();
                            txtMinistere.Text = reader["Ministere"].ToString();
                            txtNomEcole.Text = reader["NomEcole"].ToString();
                            txtBoitePostale.Text = reader["BoitePostale"].ToString();
                            txtAdresse.Text = reader["Adresse"].ToString();
                            txtTelephone.Text = reader["Telephone"].ToString();
                            txtEmail.Text = reader["Email"].ToString();

                            // Traitement du Logo
                            if (reader["Logo"] != DBNull.Value)
                            {
                                byte[] imgData = (byte[])reader["Logo"];
                                pbLogo.Image = ByteArrayToImage(imgData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des paramètres : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ViderEtRafraichirStatut(string nomDbInitalisee)
        {
            Connexion_db db = new Connexion_db();

            // Vérification si la nouvelle base existe
            string nomBdExiste = db.ObtenirNomBdExiste(nomDbInitalisee);

            if (nomBdExiste != null)
            {
                lblBdName.Text = "Base de données : " + nomBdExiste;
                lblBdName.ForeColor = Color.Green;
            }
            else
            {
                lblBdName.Text = "Base de données : " + nomDbInitalisee + " (Erreur d'installation)";
                lblBdName.ForeColor = Color.Red;
            }
        }
        private void btn_Bd_initialiser_Click(object sender, EventArgs e)
        {
            Connexion_db db;

            // Si vous saisissez de nouveaux identifiants ou un nouveau nom de BD
            if (!string.IsNullOrWhiteSpace(txtServeur.Text) &&
                !string.IsNullOrWhiteSpace(txtNomBD.Text) &&
                !string.IsNullOrWhiteSpace(txtUser.Text))
            {
                db = new Connexion_db(
                    txtServeur.Text.Trim(),
                    txtNomBD.Text.Trim(),
                    txtUser.Text.Trim(),
                    txtPassword.Text
                );
            }
            else
            {
                // Sinon on utilise la configuration standard
                db = new Connexion_db();
            }

            // Exécution du script d'initialisation
            db.Initialize_db();

            // Mise à jour du label en lui passant le nom de la base qui vient d'être créée/modifiée
            ViderEtRafraichirStatut(db.Database);
        }

        private void btnBD_Supprimer_Click(object sender, EventArgs e)
        {

            db.Supprimer_db();
        }

        private void btnPardefault_Click(object sender, EventArgs e)
        {
            Logique log = new Logique();
            log.InsererDonneesEtAdminParDefaut();
        }

        private void btnChoisirLogo_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                ofd.Title = "Choisir le logo de l'école";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbLogo.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomEcole.Text))
            {
                MessageBox.Show("Le nom de l'école est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // On vérifie d'abord s'il y a déjà une ligne dans la table
            bool parametresExistent = FautIlMettreAJour();
            string query;

            if (parametresExistent)
            {
                query = @"UPDATE Paramettres SET 
                            Pays = @Pays, Ministere = @Ministere, NomEcole = @NomEcole, 
                            BoitePostale = @BoitePostale, Adresse = @Adresse, 
                            Telephone = @Telephone, Email = @Email, Logo = @Logo";
            }
            else
            {
                query = @"INSERT INTO Paramettres (Pays, Ministere, NomEcole, BoitePostale, Adresse, Telephone, Email, Logo) 
                          VALUES (@Pays, @Ministere, @NomEcole, @BoitePostale, @Adresse, @Telephone, @Email, @Logo)";
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Pays", string.IsNullOrWhiteSpace(txtPays.Text) ? "RÉPUBLIQUE DÉMOCRATIQUE DU CONGO" : txtPays.Text);
                        cmd.Parameters.AddWithValue("@Ministere", string.IsNullOrWhiteSpace(txtMinistere.Text) ? "MINISTÈRE DE L'ÉDUCATION NATIONALE ET ALPHABÉTISATION" : txtMinistere.Text);
                        cmd.Parameters.AddWithValue("@NomEcole", txtNomEcole.Text);
                        cmd.Parameters.AddWithValue("@BoitePostale", txtBoitePostale.Text);
                        cmd.Parameters.AddWithValue("@Adresse", txtAdresse.Text);
                        cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                        // Conversion de l'image en byte[]
                        if (pbLogo.Image != null)
                        {
                            cmd.Parameters.AddWithValue("@Logo", ImageToByteArray(pbLogo.Image));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Logo", DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Paramètres enregistrés avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FautIlMettreAJour()
        {
            int count = 0;
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Paramettres;", conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { }
            return count > 0;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // On clone l'image pour éviter l'erreur GDI+ générique
                using (Bitmap bmp = new Bitmap(imageIn))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnAjouterElevesTeste_Click(object sender, EventArgs e)
        {
            log.GenererDonneesTest100ElevesParClasse();
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbActive.Checked)
            {
                txtServeur.Enabled = true;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                txtNomBD.Enabled = true;
            }
        }

        private void txtActivePnl_TextChanged(object sender, EventArgs e)
        {
            if (txtActivePnl.Text == "111")
            {
                pnlBoutonConfig.Enabled = true;
            }
            else
            {
                pnlBoutonConfig.Enabled = false;
            }
        }
    }
}
