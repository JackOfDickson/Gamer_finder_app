using System;
using System.Security.Cryptography;
using System.Text;

namespace webapi.Services
{
	public class EncryptionService
	{
		private static readonly string secretKey = "your-secret-key";

		public static string Encrypt(string data)
		{
			using (Aes myAes = Aes.Create())
			{

			}
			string encryptedData = "";
			return encryptedData;
		}

		public static string Decrypt(string encryptedData)
		{
			byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

			byte[] iv = new byte[16];
			Array.Copy(encryptedBytes, 0, iv, 0, 16);

			byte[] ciphertext = new byte[encryptedBytes.Length - 16];
            Array.Copy(encryptedBytes, 16, ciphertext, 0, ciphertext.Length);

            //byte[] key = Encoding.UTF8.GetBytes(secretKey);

			using (Aes myAes = Aes.Create())
				{
					myAes.IV = iv;
					myAes.Key = Encoding.UTF8.GetBytes(secretKey);
				}


            string decryptedData = "";
			return decryptedData;
		}
	}
}

