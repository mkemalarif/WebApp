using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Services.Models.Auth;

namespace WebApplication.Services.Interface
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegisterUser param);
    }
}
