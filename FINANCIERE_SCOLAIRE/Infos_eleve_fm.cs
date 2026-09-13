using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace FINANCIERE_SCOLAIRE
{
    public partial class Infos_eleve_fm : Form
    {
        public int IdEleve { get; set; }

        Connexion_db bd = new Connexion_db();
        Eleves ev = new Eleves();

        public Infos_eleve_fm()
        {
            InitializeComponent();
        }

        private void Infos_eleve_fm_Load(object sender, EventArgs e)
        {
            if (IdEleve > 0)
            {
                AfficherFicheEleve(IdEleve);
            }
            else
            {
                MessageBox.Show("Aucun élève sélectionné.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AfficherFicheEleve(int id)
        {
            string query = @"
        SELECT 
            e.Matricule, e.Nom, e.Postnom, e.Prenom, e.Sexe, 
            e.DateNaissance, e.LieuNaissance, e.TypeEleve, 
            e.NomTuteur, e.TelephoneTuteur, e.Adresse, e.DateInscription,
            c.NomClasse
        FROM Eleves e
        LEFT JOIN Classes c ON e.ClasseId = c.Id
        WHERE e.Id = @Id;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    // 1. Charger d'abord les paramètres de l'école (avec Email, Ville et LogoPath)
                    var param = ObtenirParametresEcole(conn);

                    // 2. Récupérer et afficher les données de l'élève
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rtbFiche.Clear();

                                // ---------------------------------------------------------
                                // 1. EN-TÊTE DYNAMIQUE
                                // ---------------------------------------------------------
                                AjouterTexteCentre($"{param.Pays}\n", new Font("Arial", 9, FontStyle.Bold), Color.DarkBlue);
                                AjouterTexteCentre($"{param.Ministere}\n", new Font("Arial", 8, FontStyle.Regular), Color.Black);
                                AjouterTexteCentre($"{param.NomEcole}\n", new Font("Arial", 12, FontStyle.Bold), Color.DarkRed);

                                string contactInfo = $"{param.BoitePostale} - {param.Adresse} - Tél: {param.Telephone} - Email: {param.Email}\n";
                                AjouterTexteCentre(contactInfo, new Font("Arial", 8, FontStyle.Italic), Color.DimGray);
                                AjouterLigneSeparatrice();

                                // ---------------------------------------------------------
                                // 2. TITRE DU DOCUMENT
                                // ---------------------------------------------------------
                                string anneeScolaire = DateTime.Now.Year + " - " + (DateTime.Now.Year + 1);
                                AjouterTexteCentre("FICHE DE RENSEIGNEMENTS DE L'ÉLÈVE\n", new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline), Color.Black);
                                AjouterTexteCentre($"ANNÉE SCOLAIRE {anneeScolaire}\n\n", new Font("Arial", 10, FontStyle.Bold), Color.Black);

                                // ---------------------------------------------------------
                                // 3. INFORMATIONS GÉNÉRALES DE L'ÉLÈVE
                                // ---------------------------------------------------------
                                AjouterEnteteSection("I. IDENTIFICATION DE L'ÉLÈVE");

                                string nomComplet = $"{reader["Nom"]} {reader["Postnom"]} {reader["Prenom"]}".ToUpper();
                                AjouterChampAlignes("Matricule : ", reader["Matricule"].ToString(), "Classe : ", reader["NomClasse"] != DBNull.Value ? reader["NomClasse"].ToString() : "Non assignée");
                                AjouterChamp("Nom complet : ", nomComplet);
                                AjouterChamp("Sexe : ", reader["Sexe"].ToString() == "M" ? "Masculin (M)" : "Féminin (F)");

                                string dateNaiss = reader["DateNaissance"] != DBNull.Value ? Convert.ToDateTime(reader["DateNaissance"]).ToString("dd/MM/yyyy") : "Non spécifié";
                                string lieuNaiss = reader["LieuNaissance"] != DBNull.Value ? reader["LieuNaissance"].ToString() : "Non spécifié";
                                AjouterChamp("Date de naissance : ", dateNaiss);
                                AjouterChamp("Lieu de naissance : ", lieuNaiss);

                                string typeEleve = reader["TypeEleve"] != DBNull.Value ? reader["TypeEleve"].ToString() : "Régulier";
                                AjouterChamp("Statut de l'élève : ", typeEleve);

                                string adresse = reader["Adresse"] != DBNull.Value ? reader["Adresse"].ToString() : "Non renseignée";
                                AjouterChamp("Adresse résidentielle : ", adresse);

                                rtbFiche.AppendText("\n");

                                // ---------------------------------------------------------
                                // 4. REPRESENTANTS LÉGAUX / TUTEUR
                                // ---------------------------------------------------------
                                AjouterEnteteSection("II. REPRÉSENTANTS LÉGAUX / TUTEUR");

                                string nomTuteur = reader["NomTuteur"] != DBNull.Value ? reader["NomTuteur"].ToString() : "Non renseigné";
                                string telTuteur = reader["TelephoneTuteur"] != DBNull.Value ? reader["TelephoneTuteur"].ToString() : "Non renseigné";

                                AjouterChamp("Nom du responsable : ", nomTuteur);
                                AjouterChamp("Téléphone de contact : ", telTuteur);

                                rtbFiche.AppendText("\n");

                                // ---------------------------------------------------------
                                // 5. SUIVI ADMINISTRATIF ET SIGNATURES
                                // ---------------------------------------------------------
                                AjouterEnteteSection("III. INSCRIPTION & VALIDATION");

                                string dateInscr = reader["DateInscription"] != DBNull.Value ? Convert.ToDateTime(reader["DateInscription"]).ToString("dd/MM/yyyy HH:mm") : "N/A";
                                AjouterChamp("Date d'enregistrement : ", dateInscr);

                                rtbFiche.AppendText("\n\n");
                                AjouterTexteCentre($"Fait à {param.Ville}, le " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n", new Font("Arial", 9, FontStyle.Italic), Color.Black);

                                // Bloc Signatures
                                rtbFiche.SelectionFont = new Font("Arial", 9, FontStyle.Bold | FontStyle.Underline);
                                rtbFiche.AppendText("Signature du Parent/Tuteur :                             Signature du Chef d'Établissement :\n\n\n\n");
                            }
                            else
                            {
                                MessageBox.Show("Élève non trouvé dans la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la fiche : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // MÉTHODE POUR RÉCUPÉRER LES PARAMÈTRES DE L'ÉCOLE (DYNAMIQUE)
        // ---------------------------------------------------------
        private (string Pays, string Ministere, string NomEcole, string BoitePostale, string Adresse, string Telephone, string Email, string Ville, string LogoPath) ObtenirParametresEcole(MySqlConnection connExistante)
        {
            string query = "SELECT Pays, Ministere, NomEcole, BoitePostale, Adresse, Telephone, Email, Ville, LogoPath FROM Paramettres LIMIT 1;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (
                                    reader["Pays"]?.ToString() ?? "RÉPUBLIQUE DÉMOCRATIQUE DU CONGO",
                                    reader["Ministere"]?.ToString() ?? "MINISTÈRE DE L'ÉDUCATION NATIONALE ET ALPHABÉTISATION",
                                    reader["NomEcole"]?.ToString() ?? "COMPLEXE SCOLAIRE \"BEL ELAN\"",
                                    reader["BoitePostale"]?.ToString() ?? "BP 1234",
                                    reader["Adresse"]?.ToString() ?? "Lubumbashi / Ville",
                                    reader["Telephone"]?.ToString() ?? "+243 81 00 00 000",
                                    reader["Email"]?.ToString() ?? "contact@ecole.com",
                                    reader["Ville"]?.ToString() ?? "Lubumbashi",
                                    reader["LogoPath"]?.ToString() ?? ""
                                );
                            }
                        }
                    }
                }
            }
            catch
            {
                // En cas d'erreur de lecture de la table
            }

            // Valeurs de secours par défaut
            return (
                "RÉPUBLIQUE DÉMOCRATIQUE DU CONGO",
                "MINISTÈRE DE L'ÉDUCATION NATIONALE ET ALPHABÉTISATION",
                "COMPLEXE SCOLAIRE \"BEL ELAN\"",
                "BP 1234",
                "Lubumbashi / Ville",
                "+243 81 00 00 000",
                "contact@ecole.com",
                "Lubumbashi",
                ""
            );
        }

        // ---------------------------------------------------------
        // MÉTHODES UTILITAIRES DE MISE EN FORME DU RICHTEXTBOX
        // ---------------------------------------------------------

        private void AjouterTexteCentre(string texte, Font police, Color couleur)
        {
            rtbFiche.SelectionAlignment = HorizontalAlignment.Center;
            rtbFiche.SelectionFont = police;
            rtbFiche.SelectionColor = couleur;
            rtbFiche.AppendText(texte);
        }

        private void AjouterEnteteSection(string titreSection)
        {
            rtbFiche.SelectionAlignment = HorizontalAlignment.Left;
            rtbFiche.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
            rtbFiche.SelectionColor = Color.White;
            rtbFiche.SelectionBackColor = Color.Navy;
            rtbFiche.AppendText(" " + titreSection + " \n");
            rtbFiche.SelectionBackColor = rtbFiche.BackColor;
            rtbFiche.AppendText("\n");
        }

        private void AjouterChamp(string libelle, string valeur)
        {
            rtbFiche.SelectionAlignment = HorizontalAlignment.Left;
            rtbFiche.SelectionFont = new Font("Arial", 9.5f, FontStyle.Bold);
            rtbFiche.SelectionColor = Color.DarkSlateGray;
            rtbFiche.AppendText("  " + libelle.PadRight(25));

            rtbFiche.SelectionFont = new Font("Arial", 9.5f, FontStyle.Regular);
            rtbFiche.SelectionColor = Color.Black;
            rtbFiche.AppendText(valeur + "\n");
        }

        private void AjouterChampAlignes(string libelle1, string valeur1, string libelle2, string valeur2)
        {
            rtbFiche.SelectionAlignment = HorizontalAlignment.Left;

            rtbFiche.SelectionFont = new Font("Arial", 9.5f, FontStyle.Bold);
            rtbFiche.SelectionColor = Color.DarkSlateGray;
            rtbFiche.AppendText("  " + libelle1);

            rtbFiche.SelectionFont = new Font("Arial", 9.5f, FontStyle.Regular);
            rtbFiche.SelectionColor = Color.Black;
            rtbFiche.AppendText(valeur1.PadRight(25));

            rtbFiche.SelectionFont = new Font("Arial", 9.5f, FontStyle.Bold);
            rtbFiche.SelectionColor = Color.DarkSlateGray;
            rtbFiche.AppendText(libelle2);

            rtbFiche.SelectionFont = new Font("Arial", 9.5f, FontStyle.Regular);
            rtbFiche.SelectionColor = Color.Black;
            rtbFiche.AppendText(valeur2 + "\n");
        }

        private void AjouterLigneSeparatrice()
        {
            rtbFiche.SelectionAlignment = HorizontalAlignment.Center;
            rtbFiche.SelectionFont = new Font("Arial", 8, FontStyle.Regular);
            rtbFiche.SelectionColor = Color.Gray;
            rtbFiche.AppendText("----------------------------------------------------------------------------------------------------\n\n");
        }

        private void btnExporterFichePDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbFiche.Text))
            {
                MessageBox.Show("Aucune fiche à exporter. Veuillez d'abord charger un élève.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Fichier PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Fiche_Eleve_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                sfd.Title = "Enregistrer la fiche de l'élève en PDF";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(PageSize.A4, 36f, 36f, 36f, 36f);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                        doc.Open();

                        var param = ObtenirParametresEcole(null);

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        BaseFont bfBold = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        iTextSharp.text.Font fontPays = new iTextSharp.text.Font(bfBold, 9f, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
                        iTextSharp.text.Font fontMinistere = new iTextSharp.text.Font(bf, 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font fontEcole = new iTextSharp.text.Font(bfBold, 12f, iTextSharp.text.Font.NORMAL, BaseColor.RED);
                        iTextSharp.text.Font fontContact = new iTextSharp.text.Font(bf, 8f, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);
                        iTextSharp.text.Font fontTitre = new iTextSharp.text.Font(bfBold, 13f, iTextSharp.text.Font.UNDERLINE, BaseColor.BLACK);
                        iTextSharp.text.Font fontSousTitre = new iTextSharp.text.Font(bfBold, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font fontCorps = new iTextSharp.text.Font(bf, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        // ---------------------------------------------------------
                        // EN-TÊTE DU PDF (STRUCTURE EN TABLEAU AVEC LOGO ET VILLE)
                        // ---------------------------------------------------------
                        PdfPTable headerTable = new PdfPTable(3);
                        headerTable.WidthPercentage = 100;
                        headerTable.SetWidths(new float[] { 1.5f, 5f, 1.5f });

                        // Cellule 1 : Logo (si existant)
                        PdfPCell logoCell = new PdfPCell() { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT };
                        if (!string.IsNullOrEmpty(param.LogoPath) && File.Exists(param.LogoPath))
                        {
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(param.LogoPath);
                            logo.ScaleToFit(60f, 60f);
                            logoCell.AddElement(logo);
                        }
                        headerTable.AddCell(logoCell);

                        // Cellule 2 : Textes d'en-tête
                        Paragraph pEnTete = new Paragraph();
                        pEnTete.Alignment = Element.ALIGN_CENTER;
                        pEnTete.Add(new Chunk(param.Pays + "\n", fontPays));
                        pEnTete.Add(new Chunk(param.Ministere + "\n", fontMinistere));
                        pEnTete.Add(new Chunk(param.NomEcole + "\n", fontEcole));
                        pEnTete.Add(new Chunk($"{param.BoitePostale} - {param.Adresse}\n", fontContact));
                        pEnTete.Add(new Chunk($"Tél: {param.Telephone} - Email: {param.Email}\n", fontContact));

                        PdfPCell centerCell = new PdfPCell(pEnTete)
                        {
                            Border = iTextSharp.text.Rectangle.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        headerTable.AddCell(centerCell);

                        // Cellule 3 : Espace vide / Symétrie
                        PdfPCell rightCell = new PdfPCell(new Phrase("")) { Border = iTextSharp.text.Rectangle.NO_BORDER };
                        headerTable.AddCell(rightCell);

                        doc.Add(headerTable);

                        // Ligne de séparation sous l'en-tête
                        Paragraph ligneLieu = new Paragraph(new string('_', 85), fontContact) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 15f };
                        doc.Add(ligneLieu);

                        // ---------------------------------------------------------
                        // TITRE DU DOCUMENT
                        // ---------------------------------------------------------
                        string anneeScolaire = $"{DateTime.Now.Year} - {DateTime.Now.Year + 1}";
                        Paragraph pTitre = new Paragraph("FICHE DE RENSEIGNEMENTS DE L'ÉLÈVE", fontTitre) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 4f };
                        Paragraph pAnnee = new Paragraph($"ANNÉE SCOLAIRE {anneeScolaire}", fontSousTitre) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 15f };

                        doc.Add(pTitre);
                        doc.Add(pAnnee);

                        // ---------------------------------------------------------
                        // CORPS DE LA FICHE
                        // ---------------------------------------------------------
                        string[] lignes = rtbFiche.Lines;
                        bool sauterEnTeteSysteme = true;

                        foreach (string ligne in lignes)
                        {
                            string ligneNettoyee = ligne.Trim();

                            if (sauterEnTeteSysteme)
                            {
                                if (ligneNettoyee.StartsWith("I. IDENTIFICATION"))
                                {
                                    sauterEnTeteSysteme = false;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (string.IsNullOrWhiteSpace(ligneNettoyee))
                            {
                                doc.Add(new Paragraph("\n"));
                                continue;
                            }

                            if (ligneNettoyee.StartsWith("I.") || ligneNettoyee.StartsWith("II.") || ligneNettoyee.StartsWith("III."))
                            {
                                PdfPTable tableSection = new PdfPTable(1) { WidthPercentage = 100, SpacingBefore = 8f, SpacingAfter = 6f };
                                iTextSharp.text.Font fontEnteteSection = new iTextSharp.text.Font(bfBold, 10f, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);

                                PdfPCell cell = new PdfPCell(new Phrase(ligneNettoyee, fontEnteteSection))
                                {
                                    BackgroundColor = new BaseColor(41, 128, 185),
                                    Padding = 5f,
                                    Border = iTextSharp.text.Rectangle.NO_BORDER
                                };

                                tableSection.AddCell(cell);
                                doc.Add(tableSection);
                            }
                            else if (ligneNettoyee.StartsWith("Fait à") || ligneNettoyee.Contains("Signature"))
                            {
                                Paragraph pSignature = new Paragraph(ligneNettoyee, fontSousTitre)
                                {
                                    SpacingBefore = 10f,
                                    Alignment = ligneNettoyee.StartsWith("Fait à") ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT
                                };
                                doc.Add(pSignature);
                            }
                            else
                            {
                                Paragraph pLigne = new Paragraph(ligneNettoyee, fontCorps)
                                {
                                    SpacingAfter = 3f,
                                    IndentationLeft = 10f
                                };
                                doc.Add(pLigne);
                            }
                        }

                        doc.Close();
                        writer.Close();

                        MessageBox.Show("Fiche exportée avec succès en PDF !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'exportation PDF : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}