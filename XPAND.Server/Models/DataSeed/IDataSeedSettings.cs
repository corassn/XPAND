namespace XPAND.Server.Models.DataSeed
{
    public interface IDataSeedSettings
    {
        string PlanetsSeedPath { get; set; }

        string CaptainsSeedPath { get; set; }

        string RobotsSeedPath { get; set; }

        string UsersSeedPath { get; set; }
    }
}
