using Microsoft.AspNetCore.Identity;

namespace WebApplication.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityUser> FindByIdAsync(string id);
        Task<IdentityUser> FindByEmailAsync(string email);
        Task<IList<string>> GetRolesAsync(IdentityUser user);
        Task SignInAsync(IdentityUser user, bool IsPersistent, string authenticationMethod);
    }
}
