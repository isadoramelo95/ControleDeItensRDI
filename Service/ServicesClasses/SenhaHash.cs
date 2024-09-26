﻿using System.Security.Cryptography;
using System.Text;

namespace Services.ServicesClasses
{
    public class SenhaHash
    {
        public static string ComputeHash(string senha, string salt, string pepper, int iteration)
        {
            if (iteration <= 0) return senha;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{senha}{salt}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, salt, pepper, iteration - 1);
        }

        public static string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }
    }
}
