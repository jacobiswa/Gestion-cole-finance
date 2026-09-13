using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public static class SessionUtilisateur
    {
        public static Utilisateur UtilisateurConnecte { get; private set; }

        public static void OuvrirSession(Utilisateur user)
        {
            UtilisateurConnecte = user;
        }

        public static void FermerSession()
        {
            UtilisateurConnecte = null;
        }

        public static bool EstConnecte => UtilisateurConnecte != null;

        // Contrôle des rôles
        public static bool EstAdmin => UtilisateurConnecte?.Role == "Admin";
        public static bool EstCaissier => UtilisateurConnecte?.Role == "Caissier";
        public static bool EstAgentRecouvrement => UtilisateurConnecte?.Role == "Recouvrement";

        // Méthodes d'autorisation granulaires
        public static bool PeutConfigurerFrais() => EstAdmin;
        public static bool PeutSupprimerPaiement() => EstAdmin;
        public static bool PeutSaisirPaiement() => EstAdmin || EstCaissier;
        public static bool PeutConsulterRapportsGlobaux() => EstAdmin || EstAgentRecouvrement;
    }

    public class Utilisateur
    {
        public int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasseHash { get; set; }
        public string Role { get; set; } // 'Admin', 'Caissier', 'Recouvrement'
        public string NomComplet { get; set; }
    }

    public class LogAudit
    {
        public int Id { get; set; }
        public int? UtilisateurId { get; set; }
        public string NomUtilisateur { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime DateAction { get; set; }
    }

    public class UtilisateurSession
    {
        public int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public string NomComplet { get; set; }
        public string Role { get; set; }
    }
}
