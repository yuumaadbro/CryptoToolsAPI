using CryptoToolsAPI.DataMappers;
using CryptoToolsAPI.DTOs.BackOffice;
using CryptoToolsAPI.Models;
using CryptoToolsAPI.NewFolder.NewFolder;

namespace CryptoToolsAPI.Services
{
    public class BackOfficeService: IBackOfficeService
    {
        private readonly BackOfficeDataMapper _dataMapper;
        public BackOfficeService(BackOfficeDataMapper backOfficeDataMapper) 
        { 
            _dataMapper = backOfficeDataMapper;
        }

        public List<UserResponseDTO> CreateUsers(List<UserRequestDTO> users) 
        { 
            return _dataMapper.CreateUsers(users);
        }

        public List<UserStatusResponseDTO> UpdateUserStatus(List<UserStatusRequestDTO> users) 
        { 
            return _dataMapper.UpdateUserStatus(users);
        }
    }
}
