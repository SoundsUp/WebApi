using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Business
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthRepository _repository;
        private readonly IValidator _validator;

        public AuthManager(IAuthRepository repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Account> Login(Login entity)
        {
            //TODO: Hash the password here

            var result = await _repository.Login(entity);

            if (result == null) return null;

            var account = ModelUserToAccount(result);

            return account;
        }

        public async Task<Account> Register(RegisterViewModel entity)
        {
            //TODO: Hash the password here

            var salt = "Salt";

            var result = await _repository.Register(entity, salt);

            if (result == null) return null;

            var account = ModelUserToAccount(result);

            return account;
        }

        private static Account ModelUserToAccount(Domain.Entities.Models.Users result)
        {
            return new Account
            {
                Id = result.Id,
                Email = result.Email,
                Avatar = result.Avatar,
                Description = result.Description,
                DisplayName = result.DisplayName
            };
        }
    }
}