using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XPAND.Server.Exceptions;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Models.Jwt;

namespace XPAND.Server.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtSettings _jwtSettings;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IJwtSettings jwtSettings,
            ILogger<UserService> logger,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UserDto> LoginUserAsync(string userName, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(userName);

                    if (user == null)
                    {
                        _logger.LogWarning($"User was not found.");
                        throw new ServiceException($"User was not found.");
                    }

                    var token = CreateToken(user);

                    return new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        UserName = user.UserName ?? "",
                        Email = user.Email ?? "",
                        TeamId = user.TeamId,
                        Token = token
                    };
                }
                else
                {
                    _logger.LogWarning($"Could not log in.");
                    throw new ServiceException($"Could not log in.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to login.");
                throw new ServiceException("An error occured while trying to login", ex);
            }
        }

        public async Task<UserDto> RegisterUserAsync(RegisterDto registerDto)
        {
            try
            {
                var user = _mapper.Map<AppUser>(registerDto);

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                //WIP

                return new UserDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to register.");
                throw new ServiceException("An error occured while trying to register", ex);
            }
        }

        private string CreateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
