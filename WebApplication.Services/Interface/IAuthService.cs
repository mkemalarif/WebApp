using WebApplication.Services.Models.Auth;

namespace WebApplication.Services.Interface
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel param);
        Task<string> Logout();
        string GetTokenFromRequest();
    }
}
