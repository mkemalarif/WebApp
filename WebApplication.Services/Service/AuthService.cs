using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Interface;
using WebApplication.Services.Interface;
using WebApplication.Services.Models.Auth;

namespace WebApplication.Services.Service
{
    public class AuthService(IUserRepository _userRepo, ILogger<AuthService> _logger, AuthenticationSetting _auth, ITokenRepository _tokenRepo, IHttpContextAccessor _httpContext) : IAuthService
    {
        public string GetTokenFromRequest()
        {
            return (_httpContext.HttpContext.Request.Headers["Authorization"]).Single().Split().Last() ?? string.Empty;
        }
        public async Task<string> Login(LoginModel param)
        {
            try
            {
                var user = await _userRepo.FindByEmailAsync(param.Email);

                if (user == null)
                    throw new Exception($"User with email {param.Email} not found");

                await _userRepo.SignInAsync(user ,false, "");

                var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Sub, user.Id),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.Name, user.UserName),
                    new("UserId", user.Id)
                };

                var loginExpiration = DateTime.Now.AddDays(2);

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_auth.SecretKey));

                var token = new JwtSecurityToken(
                    issuer : _auth.ValidIssuer,
                    audience: _auth.ValidAudience,
                    expires: loginExpiration,
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );

                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

                await _tokenRepo.InsertValidToken(
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = param.Email,
                        ValidToken = tokenStr,
                    }
                    );

                return tokenStr;

            } catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }

        public async Task<string> Logout()
        {
            try
            {
                var token = GetTokenFromRequest();

                var readToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var email = readToken.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();
                await _tokenRepo.DeleteValidToken(email ,token);

                return "Logout Success";

            } catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}" +
                    $"StackTrace: {ex.StackTrace}"
                    );

                throw;
            }
        }
    }
}
