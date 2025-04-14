using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Services.Models.Auth;

namespace WebApplication.Services.Interface
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel param);
    }
}
