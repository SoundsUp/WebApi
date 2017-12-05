using SoundsUp.Domain.Entities.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IAuthRepository
    {
        Task<Users> Register(Users entity);

        Task<T> Get<T>(Expression<Func<T, bool>> where) where T : class;
    }
}