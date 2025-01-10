using CryptoToolsAPI.DTOs.Encrypter;
using Microsoft.AspNetCore.Mvc;

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
                return BadRequest(ex);
            }
        }
    }
}
