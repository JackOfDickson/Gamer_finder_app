using Microsoft.AspNetCore.Mvc;
using System;
using webapi.Services;
using webapi.Models;
namespace webapi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) => _userService = userService;

        [HttpGet]
        public async Task<List<User>> Get() => await _userService.GetUsers();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> get(string id)
        {
            var user = await _userService.GetUser(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("{id:length(24)}/login")]
        public async Task<IActionResult> LoginUser(string userId, [FromBody] LoginRequest loginRequest )
        {

        }
    }

}
