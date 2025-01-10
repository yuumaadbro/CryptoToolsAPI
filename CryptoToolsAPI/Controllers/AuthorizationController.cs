using CryptoToolsAPI.DTOs.Authorization;
using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CryptoToolsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController:ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public AuthorizationController(IAuthorizationService authorizationService) 
        { 
            _authorizationService = authorizationService;
        }

        [HttpPost("auth")]
        public IActionResult Authorization([FromBody] AuthorizationRequestDTO credentials) 
        {
            if (credentials == null) return Unauthorized();

            var user = _authorizationService.IsUserAuthorized(credentials);
            if (user.Email.IsNullOrEmpty()) return Unauthorized();

            var authorizationResponse = _authorizationService.GetAuthorizationResponse(user);
            if(authorizationResponse == null) return Unauthorized();
            return Ok(authorizationResponse);
        }
    }
}
