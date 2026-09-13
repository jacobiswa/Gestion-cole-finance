using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FINANCIERE_SCOLAIRE
{
    public class PdfRecouvrementService
    {
        public static void GenererBordereauRecouvrement(string cheminFichier, List<EleveSolvabilite> listeData, DataTable dtEcole, string titreRapport)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);
            PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            // Fontes
            iTextSharp.text.Font fontEnteteStr = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK);
            iTextSharp.text.Font fontTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);
            iTextSharp.text.Font fontHeaderTab = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
            iTextSharp.text.Font fontBody = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
            iTextSharp.text.Font fontBodyBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.BLACK);

            // 1. Entête Établissement
            if (dtEcole.Rows.Count > 0)
            {
                DataRow r = dtEcole.Rows[0];
                Paragraph pHeader = new Paragraph($"{r["Pays"]}\n{r["Ministere"]}\n{r["NomEcole"]}\n{r["Adresse"]} - {r["Telephone"]}", fontEnteteStr);
                pHeader.Alignment = Element.ALIGN_CENTER;
                doc.Add(pHeader);
            }

            doc.Add(new Paragraph(" ")); // Espace

            // 2. Titre du Bordereau
            Paragraph pTitre = new Paragraph(titreRapport.ToUpper(), fontTitre);
            pTitre.Alignment = Element.ALIGN_CENTER;
            doc.Add(pTitre);

            Paragraph pDate = new Paragraph($"Généré le : {DateTime.Now:dd/MM/yyyy HH:mm}", fontBody);
            pDate.Alignment = Element.ALIGN_RIGHT;
            doc.Add(pDate);

            doc.Add(new Paragraph(" "));

            // 3. Tableau
            PdfPTable table = new PdfPTable(8);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 5f, 15f, 30f, 10f, 12f, 12f, 12f, 14f });

            string[] headers = { "N°", "Matricule", "Nom Complet", "Classe", "Dû", "Payé", "Solde", "Statut" };
            foreach (string h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, fontHeaderTab));
                cell.BackgroundColor = new BaseColor(41, 128, 185); // Bleu moderne
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 5;
                table.AddCell(cell);
            }

            int index = 1;
            decimal totalDu = 0, totalPaye = 0, totalSolde = 0;

            foreach (var item in listeData)
            {
                table.AddCell(new PdfPCell(new Phrase(index.ToString(), fontBody)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(item.Matricule, fontBody)));
                table.AddCell(new PdfPCell(new Phrase(item.NomComplet, fontBodyBold)));
                table.AddCell(new PdfPCell(new Phrase(item.Classe, fontBody)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase($"{item.MontantDu:N2} {item.Devise}", fontBody)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase($"{item.MontantPaye:N2} {item.Devise}", fontBody)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase($"{item.SoldeRestant:N2} {item.Devise}", fontBodyBold)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                // Couleur du Statut
                PdfPCell cellStatut = new PdfPCell(new Phrase(item.Statut, fontBodyBold));
                cellStatut.HorizontalAlignment = Element.ALIGN_CENTER;
                if (item.Statut == "À JOUR")
                    cellStatut.BackgroundColor = new BaseColor(212, 239, 223); // Vert clair
                else
                    cellStatut.BackgroundColor = new BaseColor(249, 215, 215); // Rouge clair

                table.AddCell(cellStatut);

                totalDu += item.MontantDu;
                totalPaye += item.MontantPaye;
                totalSolde += item.SoldeRestant;
                index++;
            }

            doc.Add(table);

            // 4. Totaux & Signatures
            doc.Add(new Paragraph(" "));
            Paragraph pTotaux = new Paragraph($"TOTAL DÛ : {totalDu:N2} | TOTAL PAYÉ : {totalPaye:N2} | RESTE À RECOUVRER : {totalSolde:N2}", fontTitre);
            pTotaux.Alignment = Element.ALIGN_RIGHT;
            doc.Add(pTotaux);

            doc.Add(new Paragraph("\n\n"));
            PdfPTable tableSign = new PdfPTable(2);
            tableSign.WidthPercentage = 100;
            tableSign.AddCell(new PdfPCell(new Phrase("Le Sceau / La Direction", fontBodyBold)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT });
            tableSign.AddCell(new PdfPCell(new Phrase("Le Service de Recouvrement", fontBodyBold)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });

            doc.Add(tableSign);
            doc.Close();
        }
    }
}
