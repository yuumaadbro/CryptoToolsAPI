using CryptoToolsAPI.DTOs.FileManager;

namespace CryptoToolsAPI.Services
{
    public interface IFileManagerService
    {
        EncryptFileResponse EncryptFile(EncryptFileRequest encryptFileRequest);
        VerifyFileResponse VerifyFile(string filePath);
        DecryptFileResponse DecryptFile(DecryptFileRequest decryptFileRequest);
    }
}
