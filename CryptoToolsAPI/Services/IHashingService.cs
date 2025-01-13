using CryptoToolsAPI.DTOs.Hashing;

namespace CryptoToolsAPI.Services
{
    public interface IHashingService
    {
        public HashSHA256ResponseDTO HashSHA256(string text);
        public HashBCryptResponseDTO HashBCrypt(string text);
        public HashPBKDF2ResponseDTO HashPBKDF2(string text, string salt);
    }
}
