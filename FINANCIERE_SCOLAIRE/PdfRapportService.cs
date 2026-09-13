using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class PdfRapportService
    {
        public static void GenererRapportPDF(string cheminFichier, DataTable dtDonnees, DataTable dtEcole, string titreRapport)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);
            PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            iTextSharp.text.Font fontEnteteStr = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK);
            iTextSharp.text.Font fontTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, BaseColor.BLACK);
            iTextSharp.text.Font fontHeaderTab = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
            iTextSharp.text.Font fontBody = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);

            // 1. En-tête de l'établissement
            if (dtEcole != null && dtEcole.Rows.Count > 0)
            {
                DataRow r = dtEcole.Rows[0];
                Paragraph pHeader = new Paragraph($"{r["Pays"]}\n{r["Ministere"]}\n{r["NomEcole"]}\n{r["Adresse"]} - {r["Telephone"]}", fontEnteteStr);
                pHeader.Alignment = Element.ALIGN_CENTER;
                doc.Add(pHeader);
            }

            doc.Add(new Paragraph(" "));

            // 2. Titre et Date
            Paragraph pTitre = new Paragraph(titreRapport.ToUpper(), fontTitre);
            pTitre.Alignment = Element.ALIGN_CENTER;
            doc.Add(pTitre);

            Paragraph pDate = new Paragraph($"Édité le : {DateTime.Now:dd/MM/yyyy HH:mm}", fontBody);
            pDate.Alignment = Element.ALIGN_RIGHT;
            doc.Add(pDate);

            doc.Add(new Paragraph(" "));

            // 3. Tableau de données
            if (dtDonnees.Columns.Count > 0)
            {
                PdfPTable table = new PdfPTable(dtDonnees.Columns.Count);
                table.WidthPercentage = 100;

                foreach (DataColumn col in dtDonnees.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName, fontHeaderTab));
                    cell.BackgroundColor = new BaseColor(52, 73, 94);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    table.AddCell(cell);
                }

                foreach (DataRow row in dtDonnees.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item.ToString(), fontBody)) { Padding = 4 });
                    }
                }

                doc.Add(table);
            }

            doc.Add(new Paragraph("\n\n"));
            Paragraph pSign = new Paragraph("Signature & Cachet de la Direction", fontEnteteStr);
            pSign.Alignment = Element.ALIGN_RIGHT;
            doc.Add(pSign);

            doc.Close();
        }
    
}
}
