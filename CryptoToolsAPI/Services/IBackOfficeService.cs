using CryptoToolsAPI.DTOs.BackOffice;
using CryptoToolsAPI.Models;

namespace CryptoToolsAPI.Services
{
    public interface IBackOfficeService
    {
        public List<UserResponseDTO> CreateUsers(List<UserRequestDTO> users);
        public List<UserStatusResponseDTO> UpdateUserStatus(List<UserStatusRequestDTO> users);
    }
}
