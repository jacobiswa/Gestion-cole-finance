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
    public partial class UC_User : UserControl
    {
        private readonly UserService userService = new UserService();
        private int selectedUserId = 0;
        public UC_User()
        {
            InitializeComponent();
        }

        private void UC_User_Load(object sender, EventArgs e)
        {

            ChargerRolesCombo();
            ChargerUtilisateurs();

            dtpLogDebut.Value = DateTime.Today.AddDays(-7);
            dtpLogFin.Value = DateTime.Today;
            ChargerLogs();
        }

        private void ChargerRolesCombo()
        {
            cboRole.Items.Clear();
            cboRole.Items.Add("Admin");
            cboRole.Items.Add("Caissier");
            cboRole.Items.Add("Recouvrement");
            cboRole.SelectedIndex = 0;
        }

        private void ChargerUtilisateurs()
        {
            dgvUsers.DataSource = userService.ObtenirTousLesUtilisateurs();
            ReinitialiserFormulaire();
        }

        private void ReinitialiserFormulaire()
        {
            selectedUserId = 0;
            txtNomComplet.Clear();
            txtNomUtilisateur.Clear();
            txtMotDePasse.Clear();
            txtMotDePasse.Enabled = true;
            cboRole.SelectedIndex = 0;
            btnEnregistrer.Text = "Ajouter";
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomComplet.Text) || string.IsNullOrWhiteSpace(txtNomUtilisateur.Text))
            {
                MessageBox.Show("Veuillez remplir le nom complet et le nom d'utilisateur.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedUserId == 0) // Nouveau
            {
                if (string.IsNullOrWhiteSpace(txtMotDePasse.Text))
                {
                    MessageBox.Show("Le mot de passe est obligatoire pour un nouvel utilisateur.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Utilisateur user = new Utilisateur
                {
                    NomComplet = txtNomComplet.Text.Trim(),
                    NomUtilisateur = txtNomUtilisateur.Text.Trim(),
                    Role = cboRole.SelectedItem.ToString()
                };

                if (userService.AjouterUtilisateur(user, txtMotDePasse.Text))
                {
                    MessageBox.Show("Utilisateur créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerUtilisateurs();
                }
            }
            else // Modification
            {
                Utilisateur user = new Utilisateur
                {
                    Id = selectedUserId,
                    NomComplet = txtNomComplet.Text.Trim(),
                    NomUtilisateur = txtNomUtilisateur.Text.Trim(),
                    Role = cboRole.SelectedItem.ToString()
                };

                if (userService.ModifierUtilisateur(user))
                {
                    MessageBox.Show("Utilisateur mis à jour !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerUtilisateurs();
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNomUtilisateur.Text = row.Cells["NomUtilisateur"].Value.ToString();
                txtNomComplet.Text = row.Cells["NomComplet"].Value.ToString();
                cboRole.SelectedItem = row.Cells["Role"].Value.ToString();

                txtMotDePasse.Enabled = false; // Le MDP ne se modifie pas directement ici
                btnEnregistrer.Text = "Modifier";
            }
        }

        private void btnReinitialiserMdp_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur dans le tableau.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nouveauMdp = Prompt.ShowDialog("Entrez le nouveau mot de passe :", "Réinitialiser le Mot de Passe");
            if (!string.IsNullOrWhiteSpace(nouveauMdp))
            {
                if (userService.ReinitialiserMotDePasse(selectedUserId, nouveauMdp))
                {
                    MessageBox.Show("Mot de passe mis à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReinitialiserFormulaire();
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0) return;

            if (selectedUserId == SessionUtilisateur.UtilisateurConnecte?.Id)
            {
                MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte connecté !", "Sécurité", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialog = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (userService.SupprimerUtilisateur(selectedUserId))
                {
                    MessageBox.Show("Utilisateur supprimé !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerUtilisateurs();
                }
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ReinitialiserFormulaire();
        }

        // --- SECTION JOURNAL D'AUDIT (LOGS) ---
        private void btnFiltrerLogs_Click(object sender, EventArgs e)
        {
            ChargerLogs();
        }

        private void ChargerLogs()
        {
            dgvLogs.DataSource = userService.ObtenirLogsAudit(dtpLogDebut.Value, dtpLogFin.Value, txtRechercheLog.Text.Trim());
        }
    }

    // Boîte de dialogue simple pour la saisie du nouveau mot de passe
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label lblText = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 340, PasswordChar = '*' };
            Button btnOk = new Button() { Text = "Valider", Left = 260, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(txtInput);
            prompt.Controls.Add(btnOk);
            prompt.AcceptButton = btnOk;

            return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
        }
    









}
}
