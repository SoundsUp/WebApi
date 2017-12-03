using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SoundsUp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly SoundsUpSQLDatabaseContext _context;

        public UserRepository(SoundsUpSQLDatabaseContext context)
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

        public async Task<bool> Update(int id, EditViewModel view)
        {
            var user = _context.Users.FirstOrDefault(entity => entity.Id == id);

            if (user == null) return false;

            user.Id = id;
            user.Avatar = view.Avatar;
            user.Description = view.Description;
            user.DisplayName = view.DisplayName;
            user.Email = view.Email;

            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync();

            return true;
        }
    }
}