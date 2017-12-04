using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System.Threading.Tasks;

namespace SoundsUp.Business
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthRepository _repository;
        private readonly IValidator _validator;
        private readonly IAuthenticator _authenticator;

        public AuthManager(IAuthRepository repository, IValidator validator, IAuthenticator authenticator)
        {
            _repository = repository;
            _validator = validator;
            _authenticator = authenticator;
        }

        public async Task<Account> Login(Login entity)
        {
            var user = await _repository.Get<Users>(u => u.Email == entity.Email);

            if (user == null || !_authenticator.Verify(entity.Password, user.Password)) return null;

            var account = ModelUserToAccount(user);

            return account;
        }

        public async Task<Account> Register(RegisterViewModel entity)
        {
            //TODO: Add validation
            if (entity == null) return null;

            entity.Password = _authenticator.HashPassword(entity.Password);

            var user = ModelRegisterViewToUser(entity);

            var result = await _repository.Register(user);

            if (result == null) return null;

            var account = ModelUserToAccount(result);

            return account;
        }

        private static Users ModelRegisterViewToUser(RegisterViewModel entity)
        {
            return new Users
            {
                Avatar = entity.Avatar,
                Description = entity.Description,
                DisplayName = entity.DisplayName,
                Email = entity.Email,
                Password = entity.Password
            };
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