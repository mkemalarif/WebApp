using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebApplication.Repositories.Interface;
using WebApplication.Repositories.Repository;
using WebApplication.Services.Interface;
using WebApplication.Services.Models.Auth;

namespace WebApplication.Services.Service
{
    public class UserService(ILogger<UserService> _logger, IUserRepository _userRepo) : IUserService
    {
        public async Task<bool> RegisterUser(RegisterUser param)
        {
            try
            {
                var userExist = await _userRepo.FindByEmailAsync(param.Email);

                if(userExist != null)
                    throw new Exception($"User with email {param.Email} already exists.");

                var newUser = new IdentityUser
                {
                    UserName = param.UserName,
                    Email = param.Email,
                    EmailConfirmed = true
                };

                var result = await _userRepo.CreateAsync(newUser, param.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"User registration failed: {errors}");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }
    }
}
