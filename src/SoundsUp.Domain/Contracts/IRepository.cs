﻿using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IRepository
    {
        Task<Users> Login(Login entity);

        Task<Account> Get(int id);

        Task<Users> Register(RegisterViewModel entity, string salt);

        Task<bool> Update(int id, EditViewModel view);
    }
}