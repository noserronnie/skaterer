using System;
using System.Security.Cryptography;
using System.Text;

namespace Skaterer.Services
{
    public static class Cipher
    {

        private const string SECURITY_KEY = "ashfdoiuw_320987";

        public static string Encrypt(string text)
        {
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(text);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SECURITY_KEY));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider
            {
                Key = securityKeyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

    }
}
