using System;
using System.Security.Cryptography;
using System.Text;

namespace Fansoft.Store.Domain.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha) 
        {
            var salt = "D46EB576-F8D4-414C-9747-393913AFB707";
            var password = Encoding.UTF8.GetBytes(senha + salt);

            using (var sha = SHA512.Create()) 
            {
                password = sha.ComputeHash(password);
            }

            return Convert.ToBase64String(password);
        }
    }
}
