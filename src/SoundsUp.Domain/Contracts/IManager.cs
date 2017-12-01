using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IManager
    {
        Task<Account> Get(int id);

        Task<bool> Update(int id, EditViewModel view);
    }
}