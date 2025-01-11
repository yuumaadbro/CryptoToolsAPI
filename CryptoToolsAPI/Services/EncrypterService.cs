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

        public DecryptAESTextResponseDTO DecryptAESText(DecryptAESTextRequestDTO text) 
        {
            using (Aes aes = Aes.Create()) 
            {
                aes.Key = Encoding.UTF8.GetBytes(_settings.AESKey);
                aes.IV = Encoding.UTF8.GetBytes(_settings.AESVector);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(text.EncryptedText))) 
                {
                    using (CryptoStream cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        return new DecryptAESTextResponseDTO 
                        { 
                            Text = streamReader.ReadToEnd()
                        };
                    }
                }
            }
        }

        public EncodeBase64TextResponseDTO EncodeBase64Text(EncodeBase64TextRequestDTO text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text.Text);
            return new EncodeBase64TextResponseDTO
            {
                EncodedText = Convert.ToBase64String(textBytes)
            };
        }

        public DecodeBase64TextResponseDTO DecodeBase64Text(DecodeBase64TextRequestDTO text)
        {
            byte[] decodedBytes = Convert.FromBase64String(text.EncodedText);
            return new DecodeBase64TextResponseDTO 
            { 
                DecodedText = Encoding.UTF8.GetString(decodedBytes)
            };
        }
    }
}
