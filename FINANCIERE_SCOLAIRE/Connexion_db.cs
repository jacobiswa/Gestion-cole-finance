using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class Connexion_db
    {
        public string Server { get; set; } = "localhost";
        public string Database { get; set; } = "financeBelElan_db";
        public string User { get; set; } = "root";
        public string Password { get; set; } = "";

        public Connexion_db() { }

        public string ConnectionString
        {
            get
            {
                return $"Server={Server};Database={Database};User ID={User};Password={Password};Allow User Variables=True;Allow Batch=True;";
            }
        }
        public Connexion_db(string server, string database, string user, string password)
        {
            Server = server;
            Database = database;
            User = user;
            Password = password;
        }

        // Active "Allow User Variables=True" et "Allow Batch=True" pour exécuter les scripts complexes
        public MySqlConnection GetConnection()
        {
            // Remplacer localhost par 127.0.0.1 débloque souvent le pare-feu local Windows
            // string connString = $"Server={Server};Port=3306;Database={Database};User ID={User};Password={Password};Allow User Variables=True;Allow Batch=True;";

            string connString = $"Server={Server};Database={Database};User ID={User};Password={Password};Allow User Variables=True;Allow Batch=True;";
            return new MySqlConnection(connString);
        }

        private MySqlConnection GetServerConnection()
        {
            // string connString = $"Server={Server};Port=3306;User ID={User};Password={Password};Allow Batch=True;";
            string connString = $"Server={Server};User ID={User};Password={Password};Allow Batch=True;";
            return new MySqlConnection(connString);
        }

        public void Initialize_db()
        {
            try
            {
                // Étape 1 : Créer la base de données
                using (var serverConn = GetServerConnection())

                {
                    serverConn.Open();
                    using var cmd = serverConn.CreateCommand();
                    cmd.CommandText = $"CREATE DATABASE IF NOT EXISTS `{Database}`;";
                    cmd.ExecuteNonQuery();
                }

                // Étape 2 : Créer les tables et insérer les données par défaut
                using (var connection = GetConnection())
                {
                    connection.Open();

                    string sql = @"
                        -- Table des Paramètres généraux de l'école
                        CREATE TABLE IF NOT EXISTS Paramettres (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Pays VARCHAR(100) NOT NULL DEFAULT 'RÉPUBLIQUE DÉMOCRATIQUE DU CONGO',
                            Ministere VARCHAR(150) NOT NULL DEFAULT 'MINISTÈRE DE L\'ÉDUCATION NATIONALE ET ALPHABÉTISATION',
                            NomEcole VARCHAR(150) NOT NULL,
                            BoitePostale VARCHAR(50) NULL,
                            Adresse VARCHAR(255) NULL,
                            Telephone VARCHAR(50) NULL,
                            Email VARCHAR(100) NULL,
                            Logo LONGBLOB NULL
                        );
                    -- Insertion des paramètres par défaut de l'établissement
                        INSERT INTO Paramettres (Id, Pays, Ministere, NomEcole, BoitePostale, Adresse, Telephone)
                        VALUES (
                            1, 
                            'RÉPUBLIQUE DÉMOCRATIQUE DU CONGO', 
                            'MINISTÈRE DE L\'ÉDUCATION NATIONALE ET ALPHABÉTISATION', 
                            'COMPLEXE SCOLAIRE ""BEL ELAN""', 
                            'BP 1234', 
                            'Lubumbashi / Ville', 
                            '+243 81 00 00 000'
                        )
                        ON DUPLICATE KEY UPDATE Id=Id;

                        -- Table des Années Scolaires
                        CREATE TABLE IF NOT EXISTS AnneesScolaires (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Libelle VARCHAR(20) NOT NULL UNIQUE, -- ex: '2025-2026',
                            EstCloturee TINYINT(1) DEFAULT 0,
                            EstActive TINYINT(1) DEFAULT 0
                        );
                        -- Table des Sections
                        CREATE TABLE IF NOT EXISTS Sections (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            NomSection VARCHAR(50) NOT NULL UNIQUE -- Maternelle, Primaire, Secondaire
                        );

                        -- Table des Options (Humanités / Filières)
                        CREATE TABLE IF NOT EXISTS Options (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            NomOption VARCHAR(100) NOT NULL, -- Scientifique, Littéraire, Pedagogie, etc.
                            SectionId INT NOT NULL,
                            FOREIGN KEY (SectionId) REFERENCES Sections(Id) ON DELETE CASCADE
                        );

                        -- Table des Classes
                        CREATE TABLE IF NOT EXISTS Classes (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            NomClasse VARCHAR(50) NOT NULL, -- 1ère Maternelle, 6ème Primaire, 7ème EB, 1ère Humanités, etc.
                            SectionId INT NOT NULL,
                            OptionId INT NULL, -- NULL pour Maternelle/Primaire ou tronc commun
                            FOREIGN KEY (SectionId) REFERENCES Sections(Id) ON DELETE CASCADE,
                            FOREIGN KEY (OptionId) REFERENCES Options(Id) ON DELETE SET NULL
                        );

                        -- Table des Élèves
                     CREATE TABLE IF NOT EXISTS Eleves (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Matricule VARCHAR(30) NOT NULL UNIQUE,
                            Nom VARCHAR(50) NOT NULL,
                            Postnom VARCHAR(50) NOT NULL,
                            Prenom VARCHAR(50) NOT NULL,
                            Sexe CHAR(1) CHECK (Sexe IN ('M', 'F')),
                            DateNaissance DATE NULL,
                            LieuNaissance VARCHAR(100) NULL,
                            ClasseId INT NOT NULL,
                            TypeEleve VARCHAR(30) DEFAULT 'Régulier', -- 'Régulier', 'Enfant Agent', 'Boursier', 'Cas Social'
                            NomTuteur VARCHAR(100) NULL,
                            TelephoneTuteur VARCHAR(30) NULL,
                            Adresse TEXT NULL,
                            Actif TINYINT(1) DEFAULT 1,
                            DateInscription DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (ClasseId) REFERENCES Classes(Id)
                        );

                        -- Table des Types/Configuration des Frais Scolaires
                        CREATE TABLE IF NOT EXISTS ConfigurationFrais (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            LibelleFrais VARCHAR(100) NOT NULL, -- Minerval, Frais d'État, Uniforme, etc.
                            Montant DECIMAL(10, 2) NOT NULL,
                            Devise VARCHAR(5) DEFAULT 'USD', -- USD, CDF, etc.
                            EchanceMois VARCHAR(20) NULL, -- 'Janvier', 'Février', 'Acompte 1', etc.
                            AnneeScolaireId INT NOT NULL,
                            ClasseId INT NULL, -- NULL signifie que le frais s'applique à toute l'école
                            FOREIGN KEY (AnneeScolaireId) REFERENCES AnneesScolaires(Id) ON DELETE CASCADE,
                            FOREIGN KEY (ClasseId) REFERENCES Classes(Id) ON DELETE CASCADE
                        );

                        -- Table des Utilisateurs du système
                        CREATE TABLE IF NOT EXISTS Utilisateurs (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            NomUtilisateur VARCHAR(50) NOT NULL UNIQUE,
                            MotDePasseHash VARCHAR(255) NOT NULL,
                            Role VARCHAR(20) NOT NULL, -- 'Admin', 'Caissier', 'Recouvrement'
                            NomComplet VARCHAR(100) NOT NULL
                        );

                        -- Table des Paiements / Caisse
                        CREATE TABLE IF NOT EXISTS Paiements (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            NumeroRecu VARCHAR(50) NOT NULL UNIQUE,
                            EleveId INT NOT NULL,
                            FraisId INT NOT NULL,
                            MontantPaye DECIMAL(10, 2) NOT NULL,
                            Devise VARCHAR(5) DEFAULT 'USD',
                            ModePaiement VARCHAR(30) DEFAULT 'Espèces', -- 'Espèces', 'Banque', 'Mobile Money', 'Retenue à la source'
                            MoisConcerne VARCHAR(20) NULL,
                            DatePaiement DATETIME DEFAULT CURRENT_TIMESTAMP,
                            UtilisateurId INT NOT NULL,
                            Observations TEXT NULL,
                            FOREIGN KEY (EleveId) REFERENCES Eleves(Id),
                            FOREIGN KEY (FraisId) REFERENCES ConfigurationFrais(Id),
                            FOREIGN KEY (UtilisateurId) REFERENCES Utilisateurs(Id)
                        );

                        -- Table des Logs d'Audit (Sécurité)
                        CREATE TABLE IF NOT EXISTS LogsAudit (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            UtilisateurId INT NULL,
                            Action VARCHAR(100) NOT NULL,
                            Details TEXT NULL,
                            DateAction DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (UtilisateurId) REFERENCES Utilisateurs(Id) ON DELETE SET NULL
                        );
                        ";

                    using var command = connection.CreateCommand();
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                InsererAdminParDefaut();
                MessageBox.Show("Bd initialisés avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InsererAdminParDefaut()
        {
            // Hachage du mot de passe par défaut ("123456")
            string defaultPasswordHash = CryptoHelper.Encrypt("123456");

            string query = @"
        INSERT IGNORE INTO Utilisateurs (Id, NomUtilisateur, MotDePasseHash, Role, NomComplet)
        VALUES (1, 'admin', @DefaultHash, 'Admin', 'Administrateur Principal');";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DefaultHash", defaultPasswordHash);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur SQL lors de l'insertion de l'administrateur : {ex.Message}",
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
        public void Supprimer_db()
        {
            try
            {
                using var connection = GetServerConnection();
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = $"DROP DATABASE IF EXISTS `{Database}`;";
                command.ExecuteNonQuery();

                MessageBox.Show("Base MySQL supprimée avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ObtenirNomBdExiste(string nomSpecifique = null)
        {
            try
            {
                using var connection = GetServerConnection();
                connection.Open();

                // Si aucun nom n'est fourni, on cherche la base par défaut 'tulivia_db'
                string targetDb = string.IsNullOrWhiteSpace(nomSpecifique) ? this.Database : nomSpecifique;

                string sql = "SELECT SCHEMA_NAME FROM information_schema.SCHEMATA WHERE SCHEMA_NAME = @dbName;";

                using var command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@dbName", targetDb);

                object result = command.ExecuteScalar();

                return result != null ? result.ToString() : null;
            }
            catch
            {
                // Serveur MySQL éteint ou inaccessible
                return null;
            }
        }

        public UtilisateurSession Authentifier(string identifier, string password)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string hashedPassword = CryptoHelper.Encrypt(password);

                    string query = @"SELECT Id, NomUtilisateur, Role, NomComplet 
                             FROM Utilisateurs 
                             WHERE NomUtilisateur = @username AND MotDePasseHash = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", identifier);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UtilisateurSession
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    NomUtilisateur = reader["NomUtilisateur"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    NomComplet = reader["NomComplet"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // 1049 = Code d'erreur MySQL pour "Unknown database"
                if (ex.Number == 1049)
                {
                    MessageBox.Show("La base de données 'financebelelan_db' n'existe pas encore. Initialisation en cours...",
                                    "Base de données introuvable", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Tentative d'initialisation automatique
                    Initialize_db();
                }
                else
                {
                    MessageBox.Show($"Demmarer le Serveur, Erreur de connexion ({ex.Number}) : {ex.Message}",
                                    "Erreur Base de Données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Erreur imprévue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; // Identifiants incorrects ou erreur de connexion
        }

    }
}
