using CryptoToolsAPI.DTOs.Encrypter;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs;
using CryptoToolsAPI.DTOs.NewFolder;

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
                return Ok(_encrypterService.EncryptAESText(text));
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestDTO
                {
                    Loged = DateTime.Now,
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
                return Ok(_encrypterService.DecryptAESText(text));
            }
            catch (Exception ex) 
            {
                return BadRequest(new BadRequestDTO 
                { 
                    Loged = DateTime.Now,
                    Message = ex.Message,
                    Exception = ex.StackTrace
                });
            }
        }
    }
}
