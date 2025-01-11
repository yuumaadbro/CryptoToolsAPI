using CryptoToolsAPI.DTOs.Encrypter;

namespace CryptoToolsAPI.Services 
{ 
    public interface IEncrypterService 
    { 
        public EncryptAESTextResponseDTO EncryptAESText(EncryptAESTextRequestDTO text);
        public DecryptAESTextResponseDTO DecryptAESText(DecryptAESTextRequestDTO text);
    }
}