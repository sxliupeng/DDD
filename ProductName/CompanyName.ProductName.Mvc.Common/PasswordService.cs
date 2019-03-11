using System;
using System.Security.Cryptography;
using System.Text;

namespace CompanyName.ProductName.Mvc.Common
{
    public class PasswordService
    {
        public static string HashEncodePassword(string password, string passwordSalt)
        {
            byte[] bIn = Encoding.Unicode.GetBytes(password);
            byte[] bSalt = Convert.FromBase64String(passwordSalt);
            byte[] bAll = new byte[bSalt.Length + bIn.Length];

            Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
            Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);

            return Convert.ToBase64String(HashAlgorithm.Create().ComputeHash(bAll));
        }

        public static string GenerateRadomString(int length)
        {
            byte[] bytSalt = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(bytSalt);
            return Convert.ToBase64String(bytSalt);
        }
    }
}
