namespace CryptoToolsAPI.DTOs.SecureKeyGenerator
{
    public class GenerateAESKeysResponseDTO
    {
        public string AESKey { get; set; }
        public string IV { get; set; }
    }
}
