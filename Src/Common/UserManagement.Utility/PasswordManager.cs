﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Utility
{
    public class PasswordManager
    {
        public static string GetHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                //return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return BitConverter.ToString(hashedBytes).Replace("-", "");
            }
        }
        public static string GetSalt(string text)
        {
            var salt = Guid.NewGuid().ToString().Replace("-", "");
            return salt + text;
        }
    }
}
