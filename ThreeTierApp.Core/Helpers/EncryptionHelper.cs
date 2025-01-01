using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ThreeTierApp.Core.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly string Key = "0123456789ABCDEF0123456789ABCDEF";
        private static readonly string IV = "0123456789ABCDEF"; 

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return null;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(IV);
                aes.Padding = PaddingMode.PKCS7;  // Ensure PKCS7 padding is applied

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(plainText);
                    }

                    // Convert encrypted bytes to Base64 string
                    byte[] encrypted = ms.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return null;

            try
            {
                // Ensure the input is a valid Base64 string
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(Key);
                    aes.IV = Encoding.UTF8.GetBytes(IV);
                    aes.Padding = PaddingMode.PKCS7;  // Ensure PKCS7 padding is applied

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream(cipherBytes))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (FormatException ex)
            {
                // Log exception details here if necessary
                Console.WriteLine("Error: " + ex.Message);
                return null;  // If Base64 is invalid, return null
            }
        }
    }
}
