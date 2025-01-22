using CryptoToolsAPI.DTOs.FileManager;

namespace CryptoToolsAPI.Services
{
    public interface IFileManagerService
    {
        EncryptFileResponse EncryptFile(EncryptFileRequest encryptFileRequest);
    }
}
