using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Popup_Paiement_fm : Form
    {
        private PaiementService paiementService = new PaiementService();
        private Connexion_db bd = new Connexion_db();

        private int selectedEleveId = 0;
        private int selectedClasseId = 0;
        private int selectedFraisId = 0;
        private decimal montantTotalFrais = 0;
        private decimal resteAPayerFrais = 0;

        // ID de l'utilisateur actuellement connecté (Exemple: 1)
        public int CurrentUserId { get; set; } = 1;
        public string CurrentNomCaissier { get; set; } = "Caissier Principal";
        public Popup_Paiement_fm()
        {
            InitializeComponent();
        }

        private void Popup_Paiement_fm_Load(object sender, EventArgs e)
        {
            ChargerModesPaiement();
            ReinitialiserFormulaire();
            txtRechercheEleve.Focus();
        }
        private void ChargerModesPaiement()
        {
            cmbModePaiement.Items.Clear();
            cmbModePaiement.Items.Add("Espèces");
            cmbModePaiement.Items.Add("Virement bancaire");
            cmbModePaiement.Items.Add("Mobile Money");
            cmbModePaiement.Items.Add("Retenue à la source");
            cmbModePaiement.SelectedIndex = 0;
        }
        private void ChargerFraisEleve()
        {
            DataTable dtFrais = paiementService.ObtenirFraisEtSoldesParEleve(selectedEleveId, selectedClasseId);
            cmbFraisMotif.DataSource = dtFrais;
            cmbFraisMotif.DisplayMember = "LibelleFrais";
            cmbFraisMotif.ValueMember = "FraisId";

            if (dtFrais.Rows.Count == 0)
            {
                MessageBox.Show("Cet élève est en règle pour tous ses frais scolaires.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ---------------------------------------------------------
        // 3. GÉNÉRATION DE FACTURE / REÇU PDF (FORMAT 80MM / A5)
        // ---------------------------------------------------------
        private void GenererRecuPDF(PaiementModel p, string numRecu, decimal reste, bool formatTicket)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Fichier PDF (*.pdf)|*.pdf";
                sfd.FileName = $"{numRecu}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Choix de la taille de page : Ticket 80mm (226pt) ou A5
                        iTextSharp.text.Rectangle pageSize = formatTicket ? new iTextSharp.text.Rectangle(226f, 600f) : PageSize.A5.Rotate();
                        Document doc = new Document(pageSize, 10f, 10f, 10f, 10f);

                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        BaseFont bfBold = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        BaseFont bfNorm = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        iTextSharp.text.Font fontTitre = new iTextSharp.text.Font(bfBold, formatTicket ? 10f : 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font fontTexte = new iTextSharp.text.Font(bfNorm, formatTicket ? 8f : 9f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bfBold, formatTicket ? 8f : 9f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        // En-tête
                        Paragraph pHeader = new Paragraph("COMPLEXE SCOLAIRE BEL ELAN\nLubumbashi / RDC\nREÇU DE PAIEMENT\n", fontTitre) { Alignment = Element.ALIGN_CENTER };
                        doc.Add(pHeader);

                        Paragraph pInfo = new Paragraph($"N° Reçu : {numRecu}\nDate : {DateTime.Now:dd/MM/yyyy HH:mm}\n-----------------------------------\n", fontTexte) { Alignment = Element.ALIGN_CENTER };
                        doc.Add(pInfo);

                        // Contenu du reçu
                        Paragraph pCorps = new Paragraph();
                        pCorps.Add(new Chunk($"Élève : {lblNomEleve.Text}\n", fontBold));
                        pCorps.Add(new Chunk($"Matricule : {lblMatricule.Text}\n", fontTexte));
                        pCorps.Add(new Chunk($"Classe : {lblCategorie.Text}\n", fontTexte));
                        pCorps.Add(new Chunk($"Motif : {cmbFraisMotif.Text} ({p.MoisConcerne})\n", fontTexte));
                        pCorps.Add(new Chunk($"Mode de Paiement : {p.ModePaiement}\n", fontTexte));
                        pCorps.Add(new Chunk("-----------------------------------\n", fontTexte));
                        pCorps.Add(new Chunk($"Montant Payé : {p.MontantPaye:N2} {p.Devise}\n", fontTitre));
                        pCorps.Add(new Chunk($"Reste à Payer (Solde) : {reste:N2} {p.Devise}\n", fontBold));
                        pCorps.Add(new Chunk("-----------------------------------\n", fontTexte));
                        pCorps.Add(new Chunk($"Caissier(e) : {CurrentNomCaissier}\n\n", fontTexte));
                        pCorps.Add(new Chunk("Merci pour votre confiance !", fontTexte));

                        doc.Add(pCorps);
                        doc.Close();

                        MessageBox.Show("Reçu PDF généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur génération reçu : {ex.Message}");
                    }
                }
            }
        }

        private void ReinitialiserFormulaire()
        {
            selectedEleveId = 0;
            selectedClasseId = 0;
            selectedFraisId = 0;

            lblMatricule.Text = "---";
            lblNomEleve.Text = "---";
            lblCategorie.Text = "---";
            lblCategorie.Text = "---";

            lblTotalDu.Text = "0.00";
            lblResteAPayer.Text = "0.00";
            lblMoisConcerne.Text = "---";

            txtMontantVerses.Clear();
            txtObservations.Clear();
            cmbFraisMotif.DataSource = null;
            dgvResultatEleves.Visible = false;
        }

        private void txtRechercheEleve_TextChanged(object sender, EventArgs e)
        {
            string recherche = txtRechercheEleve.Text.Trim();
            if (recherche.Length >= 2)
            {
                dgvResultatEleves.DataSource = paiementService.RechercherEleves(recherche);
                dgvResultatEleves.Visible = true;
            }
            else
            {
                dgvResultatEleves.Visible = false;
            }
        }

        private void dgvResultatEleves_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbFraisMotif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFraisMotif.SelectedItem != null && cmbFraisMotif.SelectedValue is int)
            {
                DataRowView drv = (DataRowView)cmbFraisMotif.SelectedItem;
                selectedFraisId = Convert.ToInt32(drv["FraisId"]);
                montantTotalFrais = Convert.ToDecimal(drv["MontantTotal"]);
                resteAPayerFrais = Convert.ToDecimal(drv["ResteAPayer"]);

                lblDevise.Text = drv["Devise"].ToString();
                lblMoisConcerne.Text = drv["EcheanceMois"].ToString();
                lblTotalDu.Text = montantTotalFrais.ToString("N2") + " " + lblDevise.Text;
                lblResteAPayer.Text = resteAPayerFrais.ToString("N2") + " " + lblDevise.Text;

                // Par défaut, proposer de payer le reste
                txtMontantVerses.Text = resteAPayerFrais.ToString("G");
            }
        }

        private void btnValiderPaiement_Click(object sender, EventArgs e)
        {
            if (selectedEleveId == 0)
            {
                MessageBox.Show("Veuillez d'abord rechercher et sélectionner un élève.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedFraisId == 0 || cmbFraisMotif.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner le motif/type de frais à payer.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMontantVerses.Text, out decimal montantVerses) || montantVerses <= 0)
            {
                MessageBox.Show("Veuillez saisir un montant versé valide.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (montantVerses > resteAPayerFrais)
            {
                MessageBox.Show($"Le montant versé ({montantVerses}) dépasse le reste à payer ({resteAPayerFrais}).", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string numRecu = paiementService.GenererNumeroRecu();
            decimal nouveauSolde = resteAPayerFrais - montantVerses;

            PaiementModel p = new PaiementModel
            {
                NumeroRecu = numRecu,
                EleveId = selectedEleveId,
                FraisId = selectedFraisId,
                MontantPaye = montantVerses,
                Devise = lblDevise.Text,
                ModePaiement = cmbModePaiement.SelectedItem.ToString(),
                MoisConcerne = lblMoisConcerne.Text,
                UtilisateurId = CurrentUserId,
                Observations = txtObservations.Text.Trim()
            };

            if (paiementService.EnregistrerPaiement(p))
            {
                MessageBox.Show($"Paiement enregistré avec succès !\nReçu N° : {numRecu}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Option d'impression du reçu
                DialogResult dr = MessageBox.Show("Voulez-vous imprimer le reçu au format Ticket (80mm) ?", "Impression Reçu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    GenererRecuPDF(p, numRecu, nouveauSolde, true); // Format Ticket 80mm
                }
                else if (dr == DialogResult.No)
                {
                    GenererRecuPDF(p, numRecu, nouveauSolde, false); // Format A5/A4
                }

                ReinitialiserFormulaire();
            }
        }

        private void txtMontantVerses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            char decimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if ((e.KeyChar == ',' || e.KeyChar == '.') && !txtMontantVerses.Text.Contains(",") && !txtMontantVerses.Text.Contains("."))
            {
                e.KeyChar = decimalSeparator;
                return;
            }
            e.Handled = true;
        }

        private void dgvResultatEleves_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvResultatEleves.Rows[e.RowIndex];
                selectedEleveId = Convert.ToInt32(row.Cells["Id"].Value);
                selectedClasseId = Convert.ToInt32(row.Cells["ClasseId"].Value);

                lblMatricule.Text = row.Cells["Matricule"].Value.ToString();
                lblNomEleve.Text = row.Cells["NomComplet"].Value.ToString();
                lblCategorie.Text = row.Cells["Classe"].Value.ToString();
                lblCategorie.Text = row.Cells["TypeEleve"].Value.ToString();

                dgvResultatEleves.Visible = false;
                txtRechercheEleve.Clear();

                ChargerFraisEleve();
            }
        }
    }
}
