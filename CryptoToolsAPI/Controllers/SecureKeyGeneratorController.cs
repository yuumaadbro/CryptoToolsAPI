using CryptoToolsAPI.DTOs.SecureKeyGenerator;
using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs.HttpResponses;
using Microsoft.AspNetCore.Authorization;

namespace CryptoToolsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SecureKeyGeneratorController:ControllerBase
    {
        private readonly ISecureKeyGeneratorService _secureKeyGeneratorService;

        public SecureKeyGeneratorController(ISecureKeyGeneratorService secureKeyGeneratorService) 
        { 
            _secureKeyGeneratorService = secureKeyGeneratorService;
        }

        [HttpPost("generateSecurePassword")]
        public IActionResult GenerateSecurePassword([FromBody] GenerateSecurePasswordRequestDTO keySettings) 
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _secureKeyGeneratorService.GenerateSecurePassword(keySettings)
                });
            }
            catch (Exception ex) 
            {
                return BadRequest(new Status500DTO
                {
                    Logged = DateTime.Now,
                    Message = ex.Message,
                    Exception = ex.StackTrace
                });
            }
        }

        [HttpPost("generateAESKeys")]
        public IActionResult GenerateAESKeys()
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _secureKeyGeneratorService.GenerateAESKeys()
                });
            }
            catch (Exception ex) 
            {
                return BadRequest(new Status500DTO 
                {
                    Logged = DateTime.Now,
                    Message = ex.Message,
                    Exception = ex.StackTrace
                });
            }
        }
    }
}
