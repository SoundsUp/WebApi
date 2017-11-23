using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Business
{
    public class Manager : IManager
    {
        private readonly IRepository _repository;
        private readonly IValidator _validator;

        public Manager(IRepository repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Account> Get(int id)
        {
            if (!_validator.ValidateId(id))
                return null;
            return await _repository.Get(id);
        }

        public async Task<bool> Login(Login entity)
        {
            return await _repository.Login(entity);
        }

        public async Task<int> Register(Register entity)
        {
            //Hash the password here

            var salt = "Salt";

            return await _repository.Register(entity, salt);
        }
    }
}