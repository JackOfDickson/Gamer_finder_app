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
        private readonly UserCredentialsService _userCredentialsService;

        public UserController(UserService userService, UserCredentialsService userCredentialsService)
        {
            _userService = userService;
            _userCredentialsService = userCredentialsService;
        }

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

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationData userRegistrationData)
        {
            User newUser = userRegistrationData.CreateUserObject();

            await _userService.CreateUser(newUser);

            userRegistrationData.Password = EncryptionService.Encrypt(userRegistrationData.Password);

            UserCredentials userCredentials = userRegistrationData.CreateUserCredentialsObject(newUser.Id);

            await _userCredentialsService.CreateUserCredentials(userCredentials);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }


        //[HttpPost("login")]
        //public async Task<IActionResult> LoginUser(string userId, [FromBody] LoginRequest loginRequest )
        //{

        //}
    }

}
