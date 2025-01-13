using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs.HttpResponses;
using CryptoToolsAPI.DTOs.Hashing;

namespace CryptoToolsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HashingController:ControllerBase
    {
        private readonly IHashingService _hashingService;
        
        public HashingController(IHashingService hashingService) 
        { 
            _hashingService = hashingService;
        }

        [HttpPost("hashSHA256")]
        public IActionResult HashSHA256([FromBody] HashSHA256RequestDTO text) 
        {
            try
            {
                return Ok(_hashingService.HashSHA256(text.Text));
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

        [HttpPost("hashBCrypt")]
        public IActionResult HashBCrypt([FromBody] HashBCryptRequestDTO text) 
        {
            try
            {
                return Ok(_hashingService.HashBCrypt(text.Text));
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

        [HttpPost("hashPBKDF2")]
        public IActionResult HashPBKDF2([FromBody] HashPBKDF2RequestDTO text) 
        {
            try
            {
                return Ok(_hashingService.HashPBKDF2(text.Text, text.Salt));
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
