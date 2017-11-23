using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IRepository
    {
        Task<bool> Login(Login entity);

        Task<Account> Get(int id);

        Task<int> Register(Register entity, string salt);
    }
}