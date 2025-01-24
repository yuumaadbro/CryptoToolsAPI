using CryptoToolsAPI.DTOs.FileManager;
using CryptoToolsAPI.DTOs.HttpResponses;
using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CryptoToolsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FileManagerController: ControllerBase
    {
        private readonly IFileManagerService _FileManagerService;

        public FileManagerController(IFileManagerService fileManagerService) 
        { 
            _FileManagerService = fileManagerService;
        }

        [HttpPost("encryptFile")]
        public IActionResult EncryptFile([FromForm] EncryptFileRequest encryptFileRequest) 
        {
            try
            {
                return Ok(new Status200DTO 
                { 
                    Response = _FileManagerService.EncryptFile(encryptFileRequest)
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

        [HttpPost("decryptFile")]
        public IActionResult DecryptFile([FromForm] DecryptFileRequest decryptFileRequest)
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _FileManagerService.DecryptFile(decryptFileRequest)
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

        [HttpPost("fileIntegrity")]
        public IActionResult FileIntegrity([FromForm] VerifyFileRequest fileRequest)
        {
            try
            {
                return Ok(new Status200DTO
                {
                    Response = _FileManagerService.VerifyFile(fileRequest.File.FileName)
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
