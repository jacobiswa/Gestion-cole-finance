using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class EleveSolvabilite
    {
        public int EleveId { get; set; }
        public string Matricule { get; set; }
        public string NomComplet { get; set; }
        public string Sexe { get; set; }
        public string Section { get; set; }
        public string Classe { get; set; }
        public string FraisLibelle { get; set; }
        public decimal MontantDu { get; set; }
        public decimal MontantPaye { get; set; }
        public decimal SoldeRestant => MontantDu - MontantPaye;
        public string Devise { get; set; }
        public string Statut => SoldeRestant <= 0 ? "À JOUR" : (MontantPaye > 0 ? "INCOMPLET" : "INSOLVABLE");
        public string TelephoneTuteur { get; set; }
    }



}
