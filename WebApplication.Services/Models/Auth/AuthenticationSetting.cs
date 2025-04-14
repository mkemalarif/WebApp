
namespace WebApplication.Services.Models.Auth
{
    public class AuthenticationSetting
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string SecretKey { get; set; }
        public int TokenExpiration { get; set; }
    }
}
