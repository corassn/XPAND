using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XPAND.Server.Models;
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
    }
}
