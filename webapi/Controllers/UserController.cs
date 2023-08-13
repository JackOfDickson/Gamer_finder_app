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
    }

}
