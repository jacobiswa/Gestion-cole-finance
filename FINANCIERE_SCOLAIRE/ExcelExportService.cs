using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class ExcelExportService
    {
        public static void ExporterDataTableVersExcel(DataTable dt, string cheminFichier, string titreRapport)
        {
            StringBuilder sb = new StringBuilder();

            // Structure HTML lisible nativement par Microsoft Excel (.xlsx / .xls)
            sb.AppendLine("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>");
            sb.AppendLine("<head><meta charset='utf-8'></head><body>");
            sb.AppendLine($"<h2>{titreRapport}</h2>");
            sb.AppendLine("<table border='1' style='border-collapse:collapse;'>");

            // En-têtes
            sb.AppendLine("<tr style='background-color:#2980b9; color:white; font-weight:bold;'>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.AppendLine($"<th>{col.ColumnName}</th>");
            }
            sb.AppendLine("</tr>");

            // Données
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("<tr>");
                foreach (var item in row.ItemArray)
                {
                    sb.AppendLine($"<td>{item}</td>");
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table></body></html>");

            File.WriteAllText(cheminFichier, sb.ToString(), Encoding.UTF8);
        }
    }
}
