using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Entity;
using WebApplication.Repositories.Interface;

namespace WebApplication.Repositories.Repository
{
    public class TokenRepository(AppDbContext _db) : ITokenRepository
    {
        public Task<Token> GetValidToken(string email, string token)
        {
            return _db.Tokens
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email == email && x.ValidToken == token);
        }

        public async Task<bool> IsTokenValid(string email, string token)
        {
            return await _db.Tokens
                .AsNoTracking()
                .AnyAsync(x => x.Email == email && x.ValidToken == token);
        }

        public async Task InsertValidToken(Token param)
        {
            _db.Tokens.Add(param);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteValidToken(string email, string token)
        {
            Token validToken = await GetValidToken(email, token);

            if (validToken == null)
                return;

            _db.Tokens.Remove(validToken);

            await _db.SaveChangesAsync();
        }

        public async Task<string> GetEmailByToken(string token)
        {
            Token validToken = await _db.Tokens
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.ValidToken == token);

            if (validToken == null)
                return null;

            return validToken.Email;
        }
    }
}
