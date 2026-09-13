using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FINANCIERE_SCOLAIRE
{
    public partial class UC_Paiement : UserControl
    {
        private Connexion_db bd = new Connexion_db();
        PaiementService paiementService = new PaiementService();
        public UC_Paiement()
        {
            InitializeComponent();
        }

        private void UC_Paiement_Load(object sender, EventArgs e)
        {
          
            ChargerHistoriquePaiements(); // Charger la liste au démarrage
            
        }
        // Méthode pour charger et formater le DataGridView des paiements
        public void ChargerHistoriquePaiements(string filtre = "")
        {
            DataTable dtPaiements = paiementService.ObtenirTousLesPaiements(filtre);
            dgvPaiements.DataSource = dtPaiements;

            // Masquer la colonne ID
            if (dgvPaiements.Columns["Id"] != null)
            {
                dgvPaiements.Columns["Id"].Visible = false;
            }

            // Formatage des colonnes financières et dates
            if (dgvPaiements.Columns["Montant"] != null)
            {
                dgvPaiements.Columns["Montant"].DefaultCellStyle.Format = "N2";
                dgvPaiements.Columns["Montant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvPaiements.Columns["Date & Heure"] != null)
            {
                dgvPaiements.Columns["Date & Heure"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            lblNbrPaiement.Text = dgvPaiements.Rows.Count - 1 + "";
        }


        // Événement pour la recherche en temps réel dans l'historique
        private void txtRechercherHistorique_TextChanged(object sender, EventArgs e)
        {
            ChargerHistoriquePaiements(txtRechercherHistorique.Text.Trim());
        }
        private void btnValiderPaiement_Click_1(object sender, EventArgs e)
        {
            Popup_Paiement_fm popup = new Popup_Paiement_fm();
            popup.ShowDialog();
            ChargerHistoriquePaiements();
            
        }

    }
}