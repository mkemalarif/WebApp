using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Interface;

namespace WebApplication.Repositories.Repository
{
    public class UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AppDbContext _db) : IUserRepository
    {
        public Task<IdentityResult> CreateAsync(IdentityUser user, string password) => userManager.CreateAsync(user, password);
        public Task<IdentityUser> FindByEmailAsync(string email) => userManager.FindByEmailAsync(email);
        public Task SignInAsync(IdentityUser user, bool IsPersistent, string authenticationMethod) => signInManager.SignInAsync(user, IsPersistent, authenticationMethod);
    }
}
