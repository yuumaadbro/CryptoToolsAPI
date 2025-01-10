using CryptoToolsAPI.DTOs.Authorization;
using CryptoToolsAPI.Models;
using System.Security.Claims;

namespace CryptoToolsAPI.Services
{
    public interface IAuthorizationService
    {
        public Users IsUserAuthorized(AuthorizationRequestDTO credentials);
        public AuthorizationResponseDTO GetAuthorizationResponse(Users user);
        public List<Claim> GetUserClaims(string userID);
    }
}
