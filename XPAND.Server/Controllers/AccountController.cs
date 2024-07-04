using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Services;

namespace XPAND.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Logger<AccountController> _logger;

        public AccountController(IUserService userService, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.LoginUserAsync(loginDto.UserName, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
    }
}
