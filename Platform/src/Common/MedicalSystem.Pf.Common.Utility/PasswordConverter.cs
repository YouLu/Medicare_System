using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MedicalSystem.Pf.Common.Utility
{
    public class PasswordConverter
    {
        public static string convertToMD5Passwd(string plainMessage)
        {
     

            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] encodedMessage = System.Text.Encoding.UTF8.GetBytes(plainMessage);
            byte[] encodedEncryptedMessage = md5CryptoServiceProvider.ComputeHash(encodedMessage);

            return Convert.ToBase64String(encodedEncryptedMessage);
        }

    }
}
