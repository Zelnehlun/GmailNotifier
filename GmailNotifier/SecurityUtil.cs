﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace GmailNotifier
{
    public static class SecurityUtil
    {
        private const string SALT = "jlaw";

        public static string Encrypt(string clearText)
        {
            return Encrypt(clearText, SALT);
        }

        public static string Decrypt(string cipherText)
        {
            return Decrypt(cipherText, SALT);
        }

        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static string Encrypt(string clearText, string Password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);

        }

        public static byte[] Encrypt(byte[] clearData, string Password)
        { 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));

        }

        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        public static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }
    }
}
