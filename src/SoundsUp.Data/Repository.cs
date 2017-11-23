using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Data
{
    public class Repository : IRepository
    {
        private readonly SoundsUpSQLDatabaseContext _context;

        public Repository(SoundsUpSQLDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Account> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return null;

            return new Account { Id = user.Id, Email = user.Email, Description = user.Description, Avatar = user.Avatar, DisplayName = user.DisplayName };
        }

        public async Task<bool> Login(Login entity)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == entity.Email && u.Password == entity.Password) != null;
        }

        public async Task<int> Register(Register entity, string salt)
        {
            var user = new Users
            {
                Avatar = entity.Avatar,
                Description = entity.Description,
                DisplayName = entity.DisplayName,
                Email = entity.Email,
                Password = entity.Password,
                Salt = salt
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id == 0 ? -1 : user.Id;
        }
    }
}