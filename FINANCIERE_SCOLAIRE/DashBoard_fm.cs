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
    public partial class DashBoard_fm : Form
    {
        Logique log = new Logique();
        public DashBoard_fm()
        {
            InitializeComponent();
            Size = new Size(1100, 650);
        }
        public string userName = "";
        bool isMenuExpanded = true;
        private int Width_min = 60;
        private int Width_max = 290;
        // Dictionnaire pour sauvegarder les textes originaux
        private Dictionary<string, string> buttonTexts = new Dictionary<string, string>();

        private void DashBoard_fm_Load(object sender, EventArgs e)
        {
            lblBienvenue.Text = "Bienvenue, " + userName;
            lblNomEcole.Text = log.ObtenirNomEcole();
        }
        private void addUserControl(Panel pnl, UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnl.Controls.Clear();
            pnl.BackgroundImage=null;
            pnl.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void Clicker_Bouton_Menu(Button btn)
        {
            foreach (Control c in panel_rond1_Menu.Controls)
            {
                if (c is Button)
                {
                    c.ForeColor = Color.FromArgb(224, 224, 224);
                    c.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    c.BackColor = Color.Transparent;
                }
            }
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.BackColor = Color.FromArgb(7, 39, 46);
            btnPaiement.BackColor = Color.FromArgb(39, 66, 90);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (isMenuExpanded)
            {

                foreach (Control c in panel_rond1_Menu.Controls)
                {
                    if (c is Button btn)
                    {
                        if (!buttonTexts.ContainsKey(btn.Name))
                        {
                            buttonTexts[btn.Name] = btn.Text;
                        }
                        btn.Text = "";
                    }
                }
                // btnLogo.BackgroundImage = Properties.Resources.logo2;
                panel_rond1_Menu.Width = Width_min;
                isMenuExpanded = false;
            }
            else
            {

                foreach (Control c in panel_rond1_Menu.Controls)
                {
                    if (c is Button btn && buttonTexts.ContainsKey(btn.Name))
                    {
                        btn.Text = buttonTexts[btn.Name];
                    }
                }
                //   btnLogo.BackgroundImage = Properties.Resources.logo;
                panel_rond1_Menu.Width = Width_max;
                isMenuExpanded = true;
            }
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            UC_Dashboard uC_Dashboard = new UC_Dashboard();
            addUserControl(pnlMain, uC_Dashboard);
            Clicker_Bouton_Menu(btnDashBoard);
        }

        private void btnStructureScolaire_Click(object sender, EventArgs e)
        {
            UC_StructureScolaire ucStructureScolaire = new UC_StructureScolaire();
            addUserControl(pnlMain, ucStructureScolaire);
            Clicker_Bouton_Menu(btnStructureScolaire);
        }

        private void btnFraisColaire_Click(object sender, EventArgs e)
        {
            UC_FraisScolaire ucFraisScolaire = new UC_FraisScolaire();
            addUserControl(pnlMain, ucFraisScolaire);
            Clicker_Bouton_Menu(btnFraisColaire);
        }

        private void btnEleves_Click(object sender, EventArgs e)
        {
            UC_GestionEleves ucGestionEleves = new UC_GestionEleves();
            addUserControl(pnlMain, ucGestionEleves);
            Clicker_Bouton_Menu(btnEleves);
        }

        private void btnParamettre_Click(object sender, EventArgs e)
        {
            UC_Paramettre p = new UC_Paramettre();
            addUserControl(pnlMain, p);
            Clicker_Bouton_Menu(btnParamettre);
        }

        private void btnPaiement_Click(object sender, EventArgs e)
        {
            UC_Paiement ucPaiement = new UC_Paiement();
            addUserControl(pnlMain, ucPaiement);
            Clicker_Bouton_Menu(btnPaiement);
        }

        private void btnRecouvrement_Click(object sender, EventArgs e)
        {
            UC_Recouvrement re = new UC_Recouvrement();
            addUserControl(pnlMain, re);
            Clicker_Bouton_Menu(btnRecouvrement);
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            UC_Rapport ra = new UC_Rapport();
            addUserControl(pnlMain, ra);
            Clicker_Bouton_Menu(btnRapport);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UC_User us = new UC_User();
            addUserControl(pnlMain, us);
            Clicker_Bouton_Menu(btnUser);
        }
    }
}
