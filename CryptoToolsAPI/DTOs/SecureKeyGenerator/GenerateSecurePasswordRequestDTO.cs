namespace CryptoToolsAPI.DTOs.SecureKeyGenerator
{
    public class GenerateSecurePasswordRequestDTO
    {
        public int Length { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeLowercase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
    }
}
