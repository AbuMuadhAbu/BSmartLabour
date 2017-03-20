using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//*****************************************
// Copyrights Information
// Created by       : Selvakumar K
// Created on       : 
// Description      :
//****************************************
namespace SmartLabours.Common
{
    /// To encrypt or decrypt the id's being passed
    /// </summary>
    public static class Encryption
    {
        #region Cyptography

        /// <summary>
        /// Encryption for a string
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns>string</returns>
        /// <remarks></remarks>
        public static string EncryptText(string clearText)
        {
            string EncryptionKey = "SmartLabourAdmin";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// Decryption for the cipher
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>string</returns>
        /// <remarks></remarks>
        public static string DecryptText(string cipherText)
        {
            string EncryptionKey = "SmartLabourAdmin";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        /// <summary>
        /// Encrption
        /// </summary>
        /// <param name="str"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string str, string password)
        {
            byte[] buffer;
            buffer = Encoding.Unicode.GetBytes(str);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] { 0x51, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            return Convert.ToBase64String(Encrypt(buffer, pdb.GetBytes(32), pdb.GetBytes(16)));
        }

        /// <summary>
        /// Decrption
        /// </summary>
        /// <param name="str"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Decrypt(string str, string password)
        {
            byte[] buffer;
            buffer = Convert.FromBase64String(str);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] { 0x51, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            return Encoding.Unicode.GetString(Decrypt(buffer, pdb.GetBytes(32), pdb.GetBytes(16)));
        }

        /// <summary>
        /// Encrpt with key
        /// </summary>
        /// <param name="byteArrayToEncrypt"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        private static byte[] Encrypt(byte[] byteArrayToEncrypt, byte[] Key, byte[] IV)
        {
            MemoryStream memoryStream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(byteArrayToEncrypt, 0, byteArrayToEncrypt.Length);
            cryptoStream.Close();
            byte[] returnArray = memoryStream.ToArray();
            memoryStream.Close();
            return returnArray;
        }

        /// <summary>
        /// Decrypt with key
        /// </summary>
        /// <param name="byteArrayToEncrypt"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        private static byte[] Decrypt(byte[] byteArrayToEncrypt, byte[] Key, byte[] IV)
        {
            MemoryStream memoryStream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(byteArrayToEncrypt, 0, byteArrayToEncrypt.Length);
            cryptoStream.Close();
            byte[] returnArray = memoryStream.ToArray();
            memoryStream.Close();
            return returnArray;
        }

        #endregion
    }
}