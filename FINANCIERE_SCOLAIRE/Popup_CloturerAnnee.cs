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
    public partial class Popup_CloturerAnnee : Form
    {
        AnneeAcademique ac = new AnneeAcademique();
        public int AnneeId { get; set; } = 0;
        public string LibelleAnnee { get; set; } = "";
        public Popup_CloturerAnnee()
        {
            InitializeComponent();
        }

        private void Popup_CloturerAnnee_Load(object sender, EventArgs e)
        {
            lblInfoAnnee.Text = $"Année Scolaire : {LibelleAnnee}";
        }

        private void btnCloturerAnnee_Click(object sender, EventArgs e)
        {
            if (AnneeId <= 0)
            {
                MessageBox.Show("Aucune année valide n'a été transmise.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Boîte de dialogue de confirmation stricte
            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir clôturer définitivement l'année scolaire '{LibelleAnnee}' ?\n\n" +
                "ATTENTION : Cette action est irréversible !\n" +
                "• La modification et la suppression des paiements de cette année seront bloquées.\n" +
                "• L'année ne sera plus marquée comme active.",
                "Confirmation de Clôture / Archivage",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Appel de la méthode d'accès aux données (ac)
                if (ac.CloturerAnneeScolaire(AnneeId))
                {
                    MessageBox.Show($"L'année scolaire {LibelleAnnee} a été clôturée avec succès.",
                                    "Clôture Réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

      
    }
}
