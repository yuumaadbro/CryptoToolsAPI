using CryptoToolsAPI.DTOs.Encrypter;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs.HttpResponses;

namespace CryptoToolsAPI.Services
{
    [ApiController]
    [Route("[controller]")]
    public class EncrypterController : ControllerBase
    {
        private readonly IEncrypterService _encrypterService;

        public EncrypterController(IEncrypterService encrypterService)
        {
            _encrypterService = encrypterService;
        }

        [HttpPost("encryptAESText")]
        public IActionResult EncryptAESText([FromBody] EncryptAESTextRequestDTO text)
        {
            try
            {
                return Ok(new Status200DTO 
                { 
                    Response = _encrypterService.EncryptAESText(text)
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

        [HttpPost("decryptAESText")]
        public IActionResult DecryptAESText([FromBody]DecryptAESTextRequestDTO text) 
        {
            try
            {
                return Ok(new Status200DTO
                { 
                    Response = _encrypterService.DecryptAESText(text)
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
