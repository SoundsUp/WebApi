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
        private readonly IPasswordHash _passwordHash;

        public AuthManager(IAuthRepository repository, IValidator validator, IPasswordHash passwordHash)
        {
            _repository = repository;
            _validator = validator;
            _passwordHash = passwordHash;
        }

        public async Task<Account> Login(LoginViewModel entity)
        {
            var user = await _repository.Get<Users>(u => u.Email == entity.Email);

            if (user == null || !_passwordHash.Verify(entity.Password, user.Password)) return null;

            var account = ModelUserToAccount(user);

            return account;
        }

        public async Task<Account> Register(RegisterViewModel entity)
        {
            //TODO: Add validation
            if (entity == null) return null;

            var existingUser = await _repository.Get<Users>(u => u.Email == entity.Email);

            if (existingUser != null) return null;

            entity.Password = _passwordHash.HashPassword(entity.Password);

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

        private static Account ModelUserToAccount(Users result)
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