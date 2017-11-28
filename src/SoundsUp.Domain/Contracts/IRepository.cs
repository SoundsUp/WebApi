using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IRepository
    {
        Task<int?> Login(Login entity);

        Task<Account> Get(int id);

        Task<int?> Register(RegisterViewModel entity, string salt);

        Task<bool> Update(int id, EditViewModel view);
    }
}