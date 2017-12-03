using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
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

        public async Task<Users> Login(Login entity)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == entity.Email && u.Password == entity.Password);

            return result;
        }

        public async Task<Users> Register(RegisterViewModel entity)
        {
            var user = new Users
            {
                Avatar = entity.Avatar,
                Description = entity.Description,
                DisplayName = entity.DisplayName,
                Email = entity.Email,
                Password = entity.Password
            };

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
    }
}