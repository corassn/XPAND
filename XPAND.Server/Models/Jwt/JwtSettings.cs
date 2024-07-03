namespace XPAND.Server.Models.Jwt
{
    public class JwtSettings : IJwtSettings
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public int ExpiryMinutes { get; set; }
    }
}
