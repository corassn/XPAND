using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;

namespace XPAND.Server.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(RegisterDto registerDto);

        Task<UserDto> LoginUserAsync(string userName, string password);
    }
}
