using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Entity;

namespace WebApplication.Repositories.Interface
{
    public interface ITokenRepository
    {
        Task<bool> IsTokenValid(string email, string token);
        Task InsertValidToken(Token param);
        Task DeleteValidToken(string email, string token);
    }
}
