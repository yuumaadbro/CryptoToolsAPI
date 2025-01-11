using CryptoToolsAPI.DTOs.Encrypter;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs.HttpResponses;
using Microsoft.AspNetCore.Authorization;

namespace CryptoToolsAPI.Services
{
    [Authorize]
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
        public IActionResult DecryptAESText([FromBody] DecryptAESTextRequestDTO text) 
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

        [HttpPost("encodeBase64Text")]
        public IActionResult EncodeBase64Text([FromBody] EncodeBase64TextRequestDTO text) 
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _encrypterService.EncodeBase64Text(text)
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

        [HttpPost("decodeBase64Text")]
        public IActionResult DecodeBase64Text([FromBody] DecodeBase64TextRequestDTO text)
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _encrypterService.DecodeBase64Text(text)
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
