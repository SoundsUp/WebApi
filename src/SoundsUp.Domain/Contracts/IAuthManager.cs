using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface IAuthManager
    {
        Task<Account> Login(LoginViewModel entity);

        Task<Account> Register(RegisterViewModel entity);
    }
}