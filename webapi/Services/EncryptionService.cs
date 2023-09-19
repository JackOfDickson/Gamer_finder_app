using System;
using System.Security.Cryptography;
using System.Text;

namespace webapi.Services
{
    public class EncryptionService
    {
        private static readonly string secretKey = "yourSecretKeyButShouldNotBeHere!";

        private static byte[] GenerateRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomBytes);

            return randomBytes;
        }


        public static string Encrypt(string data)
        {
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = Encoding.UTF8.GetBytes(secretKey);
                myAes.IV = GenerateRandomBytes(16 );

                ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                        byte[] encryptedBytes = msEncrypt.ToArray();
                        byte[] resultBytes = new byte[myAes.IV.Length + encryptedBytes.Length];
                        Array.Copy(myAes.IV, 0, resultBytes, 0, myAes.IV.Length);
                        Array.Copy(encryptedBytes, 0, resultBytes, myAes.IV.Length, encryptedBytes.Length);

                        return Convert.ToBase64String(resultBytes);
                    }
                }
            }
        }

        public static string Decrypt(string encryptedData)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            byte[] iv = new byte[16];
            Array.Copy(encryptedBytes, 0, iv, 0, 16);

            byte[] ciphertext = new byte[encryptedBytes.Length - 16];
            Array.Copy(encryptedBytes, 16, ciphertext, 0, ciphertext.Length);

            using (Aes myAes = Aes.Create())
            {
                myAes.IV = iv;
                myAes.Key = Encoding.UTF8.GetBytes(secretKey);

                ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
