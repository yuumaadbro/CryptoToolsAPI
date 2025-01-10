using CryptoToolsAPI.DTOs.BackOffice;
using CryptoToolsAPI.Models;
using CryptoToolsAPI.NewFolder.NewFolder;
using CryptoToolsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("createUser")]
        public IActionResult CreateUsers([FromBody] List<UserRequestDTO> users) 
        { 
            return Ok(_backOfficeService.CreateUsers(users));
        }

        [Authorize]
        [HttpPut("updateUserStatus")]
        public IActionResult UpdateUserStatus([FromBody] List<UserStatusRequestDTO> users) 
        { 
            return Ok(_backOfficeService.UpdateUserStatus(users));
        }
    }
}
