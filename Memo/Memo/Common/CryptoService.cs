using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Memo.Common
{
    public class CryptoService
    {
        private const char Delimiter = '|';

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("Password can not be null.");
            }

            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt) + Delimiter;

            string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return saltString + hashedPass;
        }

        public static bool IsValidPassword(string password, string savedPassword)
        {
            string[] splitted = savedPassword.Split(Delimiter);

            byte[] salt = Convert.FromBase64String(splitted[0]);

            string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            
            return hashedPass.Equals(splitted[1]);
        }
    }
}
