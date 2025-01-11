using CryptoToolsAPI.DTOs.BackOffice;
using CryptoToolsAPI.Models;
using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CryptoToolsAPI.DTOs.HttpResponses;

namespace CryptoToolsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackOfficeController: ControllerBase
    {
        private readonly IBackOfficeService _backOfficeService;

        public BackOfficeController(IBackOfficeService backOfficeService) 
        { 
            _backOfficeService = backOfficeService;
        }

        [Authorize]
        [HttpPost("createUsers")]
        public IActionResult CreateUsers([FromBody] List<UserRequestDTO> users) 
        {
            try
            {
                return Ok(new Status200DTO 
                { 
                    Response = _backOfficeService.CreateUsers(users)
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

        [Authorize]
        [HttpPut("updateUsersStatus")]
        public IActionResult UpdateUserStatus([FromBody] List<UserStatusRequestDTO> users) 
        {
            try
            {
                return Ok(new Status200DTO 
                { 
                    Response = _backOfficeService.UpdateUserStatus(users)
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
