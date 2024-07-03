namespace XPAND.Server.Models.Jwt
{
    public interface IJwtSettings
    {
        string Key { get; set; }

        string Issuer { get; set; }

        int ExpiryMinutes { get; set; }
    }
}
