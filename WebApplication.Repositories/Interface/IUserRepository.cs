using Microsoft.AspNetCore.Identity;

namespace WebApplication.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityUser> FindByEmailAsync(string email);
        Task SignInAsync(IdentityUser user, bool IsPersistent, string authenticationMethod);
    }
}
