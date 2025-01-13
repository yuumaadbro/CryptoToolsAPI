using BCrypt.Net;
using CryptoToolsAPI.DTOs.Hashing;
using System.Security.Cryptography;
using System.Text;

namespace CryptoToolsAPI.Services
{
    public class HashingService:IHashingService
    {
        public HashingService() { }

        public HashSHA256ResponseDTO HashSHA256(string text) 
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha256.ComputeHash(textBytes);
                return new HashSHA256ResponseDTO
                {
                    Hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                };
            }
        }

        public HashBCryptResponseDTO HashBCrypt(string text) 
        {
            return new HashBCryptResponseDTO 
            { 
                Hash = BCrypt.Net.BCrypt.HashPassword(text, BCrypt.Net.BCrypt.GenerateSalt(12))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            };
        }

        public HashPBKDF2ResponseDTO HashPBKDF2(string text, string salt) 
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(text, Encoding.UTF8.GetBytes(salt), 10000))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32);
                return new HashPBKDF2ResponseDTO 
                { 
                    Hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                };
            }
        }
    }
}
