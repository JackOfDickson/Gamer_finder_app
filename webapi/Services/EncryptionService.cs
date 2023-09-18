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
