using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Business
{
    public interface IManager
    {
        Task<bool> Login(Login entity);

        Task<Account> Get(int id);

        Task<int> Register(Register entity);
    }
}