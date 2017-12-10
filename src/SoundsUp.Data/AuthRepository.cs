using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SoundsUp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SoundsUpSQLDatabaseContext _context;

        public AuthRepository(SoundsUpSQLDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Users> Register(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public virtual async Task<T> Get<T>(Expression<Func<T, bool>> where) where T : class
        {
            var result = await _context.Set<T>()
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefaultAsync(where);

            return result;
        }

        public virtual async Task<Users> GetByEmail(string email)
        {
            var result = await _context.Users
                .FromSql("EXECUTE dbo.GetUserByEmail  {0}", email)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}