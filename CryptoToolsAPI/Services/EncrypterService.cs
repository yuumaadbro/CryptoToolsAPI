using CryptoToolsAPI.DTOs.Encrypter;
using CryptoToolsAPI.Settings;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace CryptoToolsAPI.Services
{
    public class EncrypterService:IEncrypterService
    {
        private readonly CryptographySettings _settings;
        public EncrypterService(IOptions<CryptographySettings> settings) 
        { 
            _settings = settings.Value;
        }

        public EncryptAESTextResponseDTO EncryptAESText(EncryptAESTextRequestDTO text) 
        {
            using (Aes aes = Aes.Create()) 
            {
                aes.Key = Encoding.UTF8.GetBytes(_settings.AESKey);
                aes.IV = Encoding.UTF8.GetBytes(_settings.AESVector);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream stream = new MemoryStream()) 
                {
                    using (CryptoStream cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream)) 
                    { 
                        streamWriter.Write(text.Text);
                    }

                    return new EncryptAESTextResponseDTO
                    {
                        EncryptedText = Convert.ToBase64String(stream.ToArray())
                    };
                }

            }
        }
    }
}
