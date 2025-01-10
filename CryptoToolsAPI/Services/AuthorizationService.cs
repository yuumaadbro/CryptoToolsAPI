using CryptoToolsAPI.DataMappers;
using CryptoToolsAPI.DTOs.Authorization;
using CryptoToolsAPI.Models;
using System.Security.Claims;

namespace CryptoToolsAPI.Services
{
    public class AuthorizationService:IAuthorizationService
    {
        private readonly AuthorizationDataMapper _dataMapper;
        public AuthorizationService(AuthorizationDataMapper dataMapper) 
        { 
            _dataMapper = dataMapper;
        }

        public Users IsUserAuthorized(AuthorizationRequestDTO credentials) 
        { 
            return _dataMapper.IsUserAuthorized(credentials);
        }

        public AuthorizationResponseDTO GetAuthorizationResponse(Users user) 
        { 
            return _dataMapper.GetAuthorizationResponse(user);
        }

        public List<Claim> GetUserClaims(string userID) 
        { 
            return _dataMapper.GetUserClaims(userID);
        }
    }
}
