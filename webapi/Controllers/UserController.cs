using Microsoft.AspNetCore.Mvc;
using System;
using webapi.Services;
using webapi.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using webapi.Models.AppSettings;
using System.IdentityModel.Tokens.Jwt;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserCredentialsService _userCredentialsService;
        private readonly IConfiguration _configuration;

        public UserController(UserService userService, UserCredentialsService userCredentialsService, IConfiguration configuration)
        {
            _userService = userService;
            _userCredentialsService = userCredentialsService;
            _configuration = configuration;
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


        [HttpPost("login")]
        public async Task<ActionResult<string>>? LoginUser([FromBody] LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByUsername(loginRequest.Username);
            var userCreds = await _userCredentialsService.GetUserCredentialsByUserId(user.Id);

            if (userCreds is null)
            {
                return BadRequest("password or username incorrect");
            }

            if (EncryptionService.Decrypt(userCreds.Password) == loginRequest.Password)
            {
                string jwt = createJwtToken(user);
                return Ok(jwt);
            }

            return BadRequest("password or username incorrect");

        }

        private string createJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            JwtSettings jwtSettings = new JwtSettings();
            _configuration.GetSection("JwtSettings").Bind(jwtSettings);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }

}
