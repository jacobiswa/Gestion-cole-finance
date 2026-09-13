using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FINANCIERE_SCOLAIRE
{
    public class CryptoHelper
    {
        // Clé de chiffrement de 32 caractères (256 bits) à adapter
        private static readonly string SecretKey = "VotreCleSecreteTresSecurisee32B!";

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;

            byte[] keyBytes = Encoding.UTF8.GetBytes(SecretKey);
            byte[] ivBytes = new byte[16]; // IV de 16 octets (128 bits)
            Array.Copy(keyBytes, ivBytes, 16);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;

            byte[] keyBytes = Encoding.UTF8.GetBytes(SecretKey);
            byte[] ivBytes = new byte[16];
            Array.Copy(keyBytes, ivBytes, 16);

            try
            {
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream ms = new MemoryStream(buffer))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                // Retourne le texte original si ce n'était pas du Base64 valide ou une clé différente
                return cipherText;
            }
        }
    }
}
