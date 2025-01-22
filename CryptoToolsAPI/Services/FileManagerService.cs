using CryptoToolsAPI.DTOs.FileManager;
using CryptoToolsAPI.Settings;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace CryptoToolsAPI.Services
{
    public class FileManagerService:IFileManagerService
    {
        private readonly CryptographySettings _settings;
        public FileManagerService(IOptions<CryptographySettings> settings) 
        { 
            _settings = settings.Value;
        }

        public EncryptFileResponse EncryptFile(EncryptFileRequest encryptFileRequest) 
        {
            try
            {
                string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", "EncryptedFiles");
                string outputFile = Path.Combine(rootPath, $"{Guid.NewGuid()}.enc");
                using (var stream = new FileStream(outputFile, FileMode.Create))
                {
                    encryptFileRequest.inputFile.CopyTo(stream);
                }

                return AESFileEncryption(encryptFileRequest.inputFile.FileName, outputFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EncryptFileResponse AESFileEncryption(string inputFile, string outputFile) 
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_settings.AESKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(_settings.AESVector);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    fsInput.CopyTo(cs);

                    return new EncryptFileResponse
                    { 
                        encryptedFile = cs.ToString(),
                        outputPath = outputFile,
                    };
                }
            }
        }
    }
}
