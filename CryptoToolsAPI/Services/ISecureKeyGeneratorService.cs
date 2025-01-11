using CryptoToolsAPI.DTOs.SecureKeyGenerator;

namespace CryptoToolsAPI.Services
{
    public interface ISecureKeyGeneratorService
    {
        public GenerateSecurePasswordResponseDTO GenerateSecurePassword(GenerateSecurePasswordRequestDTO keySettings);

        public GenerateAESKeysResponseDTO GenerateAESKeys();
    }
}
