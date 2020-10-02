using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebShop.Infrastructure
{
    public static class EncryptingExtensions
    {
        private static readonly string toSaltValue = "QwzWSdfAWdc12ZSSAWy";

        public static string GetHashedString(this string str)
        {
            return Convert.ToBase64String(Hash(Encoding.UTF8.GetBytes(str), Encoding.UTF8.GetBytes(toSaltValue)));
        }

        private static byte[] Hash(byte[] password, byte[] salt)
        {
            byte[] saltedValue = password.Concat(salt).ToArray();

            return new SHA256Managed().ComputeHash(saltedValue);
        }
    }
}
