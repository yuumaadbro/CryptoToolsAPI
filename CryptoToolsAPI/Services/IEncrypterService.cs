using CryptoToolsAPI.DTOs.Encrypter;
using Microsoft.AspNetCore.Mvc;

namespace CryptoToolsAPI.Services 
{ 
    public interface IEncrypterService 
    { 
        public EncryptAESTextResponseDTO EncryptAESText(EncryptAESTextRequestDTO text);
        public DecryptAESTextResponseDTO DecryptAESText(DecryptAESTextRequestDTO text);
        public EncodeBase64TextResponseDTO EncodeBase64Text(EncodeBase64TextRequestDTO text);
        public DecodeBase64TextResponseDTO DecodeBase64Text(DecodeBase64TextRequestDTO text);
    }
}