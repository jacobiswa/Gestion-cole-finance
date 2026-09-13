using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class Logique
    {
        private const string Derniers_User = "derniers_user.txt";
        private const string derniers_Pass = "derniers_Pass.txt";

        Connexion_db bd = new Connexion_db();
        public bool InsererDonneesEtAdminParDefaut()
        {
            // Hachage du mot de passe par défaut ("123456")
            string defaultPasswordHash = CryptoHelper.Encrypt("123456");

            string query = @"
    -- 1. Administrateur par défaut
    INSERT IGNORE INTO Utilisateurs (Id, NomUtilisateur, MotDePasseHash, Role, NomComplet)
    VALUES (1, 'admin', @DefaultHash, 'Admin', 'Administrateur Principal');

    -- 2. Année scolaire par défaut
    INSERT IGNORE INTO AnneesScolaires (Id, Libelle, EstActive) 
    VALUES (1, '2025-2026', 1);

    -- 3. Sections par défaut
    INSERT IGNORE INTO Sections (Id, NomSection) 
    VALUES 
    (1, 'Maternelle'),
    (2, 'Primaire'),
    (3, 'Secondaire');

    -- 4. Options par défaut (pour le Secondaire)
    INSERT IGNORE INTO Options (Id, NomOption, SectionId) 
    VALUES 
    (1, 'Tronc Commun', 3),
    (2, 'Scientifique', 3),
    (3, 'Littéraire', 3),
    (4, 'Pédagogie Générale', 3),
    (5, 'Commerciale & Gestion', 3),
    (6, 'Technique Industrielle', 3);

    -- 5. Classes par défaut
    INSERT IGNORE INTO Classes (Id, NomClasse, SectionId, OptionId) 
    VALUES 
    -- Maternelle
    (1, '1ère Maternelle', 1, NULL),
    (2, '2ème Maternelle', 1, NULL),
    (3, '3ème Maternelle', 1, NULL),

    -- Primaire
    (4, '1ère Primaire', 2, NULL),
    (5, '2ème Primaire', 2, NULL),
    (6, '3ème Primaire', 2, NULL),
    (7, '4ème Primaire', 2, NULL),
    (8, '5ème Primaire', 2, NULL),
    (9, '6ème Primaire', 2, NULL),

    -- Secondaire - Tronc Commun
    (10, '7ème EB', 3, 1),
    (11, '8ème EB', 3, 1),

    -- Scientifique
    (12, '1ère Scientifique', 3, 2),
    (13, '2ème Scientifique', 3, 2),
    (14, '3ème Scientifique', 3, 2),
    (15, '4ème Scientifique', 3, 2),

    -- Littéraire
    (16, '1ère Littéraire', 3, 3),
    (17, '2ème Littéraire', 3, 3),
    (18, '3ème Littéraire', 3, 3),
    (19, '4ème Littéraire', 3, 3),

    -- Pédagogie
    (20, '1ère Pédagogie', 3, 4),
    (21, '2ème Pédagogie', 3, 4),
    (22, '3ème Pédagogie', 3, 4),
    (23, '4ème Pédagogie', 3, 4),

    -- Commerciale & Gestion
    (24, '1ère Commerciale', 3, 5),
    (25, '2ème Commerciale', 3, 5),
    (26, '3ème Commerciale', 3, 5),
    (27, '4ème Commerciale', 3, 5);";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Passage du paramètre pour le mot de passe admin
                        cmd.Parameters.AddWithValue("@DefaultHash", defaultPasswordHash);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de l'initialisation des données : {ex.Message}",
                                "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool GenererDonneesTest100ElevesParClasse()
        {
            // Listes de données de démonstration pour rendre le test réaliste
            string[] noms = { "KABAMBA", "KASENGO", "MUTOMBO", "ILUNGA", "MUKENDI", "TSHILOMBO", "KAPANDA", "NGOY", "MWAMBA", "KABEYA" };
            string[] postnoms = { "KAPUKU", "MUTEBA", "MBUYI", "KALALA", "BANZA", "KAZADI", "T SHIMANGA", "KABANGU", "MBAYA", "MWANA" };
            string[] prenomsGarcons = { "David", "Emmanuel", "Junior", "Grace", "Samuel", "Daniel", "Christian", "Jonathan", "Plamedi", "Cédric" };
            string[] prenomsFilles = { "Sarah", "Deborah", "Rachel", "Esther", "Gracia", "Dorcas", "Ruth", "Naomie", "Jemima", "Bénédicte" };
            string[] typesEleves = { "Régulier", "Régulier", "Régulier", "Enfant Agent", "Boursier" };

            Random rand = new Random();
            string anneeEnCours = DateTime.Now.Year.ToString();

            // 1. Récupérer d'abord la liste de tous les IDs de classes
            List<int> listeClasseIds = new List<int>();
            string selectClassesQuery = "SELECT Id FROM Classes;";

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    using (MySqlCommand cmdClasse = new MySqlCommand(selectClassesQuery, conn))
                    using (MySqlDataReader reader = cmdClasse.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listeClasseIds.Add(reader.GetInt32("Id"));
                        }
                    }

                    if (listeClasseIds.Count == 0)
                    {
                        MessageBox.Show("Aucune classe n'a été trouvée dans la base de données. Exécutez d'abord la méthode 'InsererDonneesEtAdminParDefaut'.",
                                        "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // 2. Début du processus d'insertion massive en Transaction
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        string insertQuery = @"
                    INSERT INTO Eleves 
                    (Matricule, Nom, Postnom, Prenom, Sexe, DateNaissance, LieuNaissance, ClasseId, TypeEleve, NomTuteur, TelephoneTuteur, Adresse) 
                    VALUES 
                    (@Matricule, @Nom, @Postnom, @Prenom, @Sexe, @DateNaissance, @LieuNaissance, @ClasseId, @TypeEleve, @NomTuteur, @TelephoneTuteur, @Adresse);";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                        {
                            // Préparation des paramètres réutilisables dans la boucle
                            cmd.Parameters.Add("@Matricule", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@Nom", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@Postnom", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@Prenom", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@Sexe", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@DateNaissance", MySqlDbType.Date);
                            cmd.Parameters.Add("@LieuNaissance", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@ClasseId", MySqlDbType.Int32);
                            cmd.Parameters.Add("@TypeEleve", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@NomTuteur", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@TelephoneTuteur", MySqlDbType.VarChar);
                            cmd.Parameters.Add("@Adresse", MySqlDbType.VarChar);

                            int compteurGlobal = 1;

                            foreach (int classeId in listeClasseIds)
                            {
                                for (int i = 1; i <= 100; i++)
                                {
                                    bool estGarcon = rand.Next(0, 2) == 0;
                                    string sexe = estGarcon ? "M" : "F";
                                    string nom = noms[rand.Next(noms.Length)];
                                    string postnom = postnoms[rand.Next(postnoms.Length)];
                                    string prenom = estGarcon ? prenomsGarcons[rand.Next(prenomsGarcons.Length)]
                                                              : prenomsFilles[rand.Next(prenomsFilles.Length)];

                                    // Génération d'un matricule unique basé sur l'incrément global : ELV-2026-TEST-XXXX
                                    string matricule = $"ELV-{anneeEnCours}-TEST-{compteurGlobal.ToString("D5")}";

                                    // Date de naissance aléatoire entre 2008 et 2020
                                    DateTime dateNaissance = new DateTime(rand.Next(2008, 2021), rand.Next(1, 13), rand.Next(1, 28));

                                    cmd.Parameters["@Matricule"].Value = matricule;
                                    cmd.Parameters["@Nom"].Value = nom;
                                    cmd.Parameters["@Postnom"].Value = postnom;
                                    cmd.Parameters["@Prenom"].Value = prenom;
                                    cmd.Parameters["@Sexe"].Value = sexe;
                                    cmd.Parameters["@DateNaissance"].Value = dateNaissance;
                                    cmd.Parameters["@LieuNaissance"].Value = "Lubumbashi";
                                    cmd.Parameters["@ClasseId"].Value = classeId;
                                    cmd.Parameters["@TypeEleve"].Value = typesEleves[rand.Next(typesEleves.Length)];
                                    cmd.Parameters["@NomTuteur"].Value = $"Tuteur {nom}";
                                    cmd.Parameters["@TelephoneTuteur"].Value = $"+243 8{rand.Next(1, 9)}{rand.Next(1000000, 9999999)}";
                                    cmd.Parameters["@Adresse"].Value = $"Avenue {rand.Next(1, 50)}, Quartier Bel-Air, Lubumbashi";

                                    cmd.ExecuteNonQuery();
                                    compteurGlobal++;
                                }
                            }
                        }

                        // Valider l'ensemble des opérations
                        transaction.Commit();
                        MessageBox.Show($"Opération réussie ! {listeClasseIds.Count * 100} élèves générés avec succès.",
                                        "Données de Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération des données de test : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string ObtenirNomEcole()
        {
            string nomEcole = string.Empty;
            string query = "SELECT NomEcole FROM Paramettres LIMIT 1;";

            // Erreur de parenthèse corrigée
            using (MySqlConnection conn = bd.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        nomEcole = result.ToString();
                    }
                }
            }

            return nomEcole;
        }


        public void SupprimerTousLesTxt()
        {
            try
            {
                string dossierCourant = AppDomain.CurrentDomain.BaseDirectory;

                if (Directory.Exists(dossierCourant))
                {
                    var fichiers = Directory.GetFiles(dossierCourant, "*.txt");
                    foreach (var fichier in fichiers)
                    {
                        File.Delete(fichier);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression des fichiers : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Méthode pour enregistrer le dernier utilisateur
        public void EnregistrerDerniers_Pass(string nom)
        {
            File.WriteAllText(derniers_Pass, nom);
        }

        // Méthode pour restaurer le dernier utilisateur
        public string RestaurerDerniers_Pass()
        {
            if (File.Exists(derniers_Pass))
            {
                return File.ReadAllText(derniers_Pass);
            }
            return string.Empty; // Aucun utilisateur enregistré
        }


        public void EnregistrerDernierUser(string nom)
        {
            File.WriteAllText(Derniers_User, nom);
        }

        // Méthode pour restaurer le dernier utilisateur
        public string RestaurerDernierUser()
        {
            if (File.Exists(Derniers_User))
            {
                return File.ReadAllText(Derniers_User);
            }
            return string.Empty; // Aucun utilisateur enregistré
        }

 


}
}
