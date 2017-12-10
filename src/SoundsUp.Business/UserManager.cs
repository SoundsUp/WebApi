using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Business
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator _validator;

        public UserManager(IUserRepository userRepository, IValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<Account> Get(int id)
        {
            if (!_validator.ValidateId(id))
                return null;
            return await _userRepository.Get(id);
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

        public async Task<bool> Update(int id, EditViewModel view)
        {
            return await _userRepository.Update(id, view);
        }
    }
}