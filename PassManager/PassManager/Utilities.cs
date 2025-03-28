using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassManager
{
    class LoginPairEntry
    {
        public string title { get; set; }
        public string username { get; set; }
        public string maskedPassword { get; set; }
    }
    class Utilities
    {
        //function to hash the password using SHA-256 with salt
        //returns the hashed password and the salt used
        public string HashPassword(string password, out string salt)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16]; //128-bit salt
                rng.GetBytes(saltBytes);
                salt = Convert.ToBase64String(saltBytes);

                using (var sha256 = SHA256.Create())
                {
                    var saltedPassword = password + salt; //concat password and salt
                    byte[] hashedPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    return Convert.ToBase64String(hashedPasswordBytes); //return the hashed password
                }
            }
        }

        //compares the input password hash with the stored hashed password and salt
        public bool VerifyPassword(string inputPassword, string storedHashedPassword, string storedSalt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = inputPassword + storedSalt; //concat entered password and stored salt
                byte[] hashedPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                string hashedInputPassword = Convert.ToBase64String(hashedPasswordBytes);
                return storedHashedPassword == hashedInputPassword; //compare hashes
            }
        }

        //generate key, iv, and salt from password - returns a tuple (key, iv, salt)
        public (byte[] key, byte[] iv, byte[] salt) GenerateKeyAndIV(string pass)
        {
            //generate a 16-byte random salt
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            //derive key and iv using PBKDF2 with 100,000 iterations and SHA256
            using (var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] key = pbkdf2.GetBytes(32); //AES-256 key
                byte[] iv = pbkdf2.GetBytes(16);  //AES IV (seed)
                return (key, iv, salt);
            }
        }

        //Encrypts plainText using userPassword - returns string in format: base64(salt):base64(cipherText)
        public string EncryptPassword(string plainText, string userPassword)
        {
            // get key, iv, and salt (randomly generated) derived from userPassword
            var (key, iv, salt) = GenerateKeyAndIV(userPassword);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream memoryStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] cipherBytes = memoryStream.ToArray();
                    // prefix cipher text with salt (both as Base64), separated by a colon
                    return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(cipherBytes);
                }
            }
        }

        //Decrypts the encryptedText using userPassword; expects format: base64(salt):base64(cipherText)
        public string DecryptPassword(string encryptedText, string userPassword)
        {
            try
            {
                var parts = encryptedText.Split(':');
                if (parts.Length != 2)
                    return "Decryption failed!";

                byte[] salt = Convert.FromBase64String(parts[0]);
                byte[] cipherBytes = Convert.FromBase64String(parts[1]);

                // re-derive key and iv using the provided salt and userPassword
                using (var pbkdf2 = new Rfc2898DeriveBytes(userPassword, salt, 100000, HashAlgorithmName.SHA256))
                {
                    byte[] key = pbkdf2.GetBytes(32);
                    byte[] iv = pbkdf2.GetBytes(16);

                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;
                        aes.Mode = CipherMode.CBC;
                        aes.Padding = PaddingMode.PKCS7;

                        using (MemoryStream memoryStream = new MemoryStream(cipherBytes))
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return "Decryption failed!";
            }
        }
    }
}
