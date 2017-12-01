﻿using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System.Linq;
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

        public async Task<Users> Login(Login entity)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == entity.Email && u.Password == entity.Password);

            return result;
        }

        public async Task<Users> Register(RegisterViewModel entity, string salt)
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

            return user;
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