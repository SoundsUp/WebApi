using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IAuthRepository
    {
        Task<Users> Login(Login entity);

        Task<Users> Register(RegisterViewModel entity, string salt);
    }
}