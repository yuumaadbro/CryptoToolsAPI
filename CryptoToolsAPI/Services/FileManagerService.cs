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
                string tmpFile = CreateTmpFilePath("EncryptedFiles", encryptFileRequest.inputFile.FileName);
                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", "EncryptedFiles", $"{encryptFileRequest.inputFile.FileName}");

                if (!CopyFileToTmpFolder(encryptFileRequest.inputFile, tmpFile)) throw new Exception("");
               
                return AESFileEncryption(tmpFile, outputFilePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DecryptFileResponse DecryptFile(DecryptFileRequest decryptFileRequest)
        {
            try
            {
                string tmpFile = CreateTmpFilePath("DecryptedFiles", decryptFileRequest.inputFile.FileName);
                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", "DecryptedFiles", $"{decryptFileRequest.inputFile.FileName}");

                if (!CopyFileToTmpFolder(decryptFileRequest.inputFile, tmpFile)) throw new Exception("");

                return AESFileDecryption(tmpFile, outputFilePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CreateTmpFilePath(string folderDestination, string inputFileName) 
        {
            string extension = Path.GetExtension(inputFileName);
            string fileName = Path.GetFileNameWithoutExtension(inputFileName);
            string wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", folderDestination);
            string tmpFile = Path.Combine(wwwroot, "tmp", inputFileName);

            return tmpFile;
        }

        public bool CopyFileToTmpFolder(IFormFile inputFile, string tmpFile) 
        {
            try 
            {
                using (var stream = new FileStream(tmpFile, FileMode.Create)) inputFile.CopyTo(stream);

                return true;
            }
            catch { return false; }
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

                    File.Delete(inputFile);

                    return new EncryptFileResponse
                    { 
                        encryptedFile = inputFile,
                        outputPath = outputFile,
                    };
                }
            }
        }

        public DecryptFileResponse AESFileDecryption(string inputFile, string outputFile) 
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_settings.AESKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(_settings.AESVector);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (CryptoStream cs = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                {
                    cs.CopyTo(fsOutput);

                    File.Delete(inputFile);

                    return new DecryptFileResponse
                    {
                        FilePath = outputFile
                    };
                }
            }
        }

        public VerifyFileResponse VerifyFile(string filePath) 
        {
            using (SHA256 sha256 = SHA256.Create())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] hashBytes = sha256.ComputeHash(fs);
                return new VerifyFileResponse 
                { 
                    Hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                };
            }
        }
    }
}
