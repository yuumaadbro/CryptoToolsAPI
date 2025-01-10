using CryptoToolsAPI.DTOs.BackOffice;
using CryptoToolsAPI.Models;
using CryptoToolsAPI.NewFolder.NewFolder;

namespace CryptoToolsAPI.Services
{
    public interface IBackOfficeService
    {
        public List<UserResponseDTO> CreateUsers(List<UserRequestDTO> users);
        public List<UserStatusResponseDTO> UpdateUserStatus(List<UserStatusRequestDTO> users);
    }
}
