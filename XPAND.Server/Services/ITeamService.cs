using XPAND.Server.Models.DTOs;

namespace XPAND.Server.Services
{
    public interface ITeamService
    {
        Task<List<RobotDto>> GetRobotsByTeamId(string teamId);

        Task<CaptainDto> GetCaptainByTeamId(string teamId);
    }
}
