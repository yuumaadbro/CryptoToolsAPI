using CryptoToolsAPI.Models;
using CryptoToolsAPI.Services;
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

        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] Users[] users) 
        { 
            return Ok(users);
        }
    }
}
