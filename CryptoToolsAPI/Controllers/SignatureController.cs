using CryptoToolsAPI.DTOs.Signature;
using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs.HttpResponses;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authorization;

namespace CryptoToolsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SignatureController: ControllerBase
    {
        private readonly ISignatureService _signatureService;

        public SignatureController(ISignatureService signatureService) 
        { 
            _signatureService = signatureService;
        }

        [HttpPost("signData")]
        public IActionResult SignData([FromBody] SignDataRequestDTO signature) 
        {
            try
            {
                return Ok(new Status200DTO 
                { 
                    Response = _signatureService.SignData(signature)
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

        [HttpPost("verifySignature")]
        public IActionResult VerifySignature([FromBody] VerifySignatureRequestDTO signature) 
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _signatureService.VerifySignature(signature)
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
