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

        public async Task<int?> Login(Login entity)
        {
            //TODO: Hash the password here

            return await _repository.Login(entity);
        }

        public async Task<int?> Register(Register entity)
        {
            //TODO: Hash the password here

            var salt = "Salt";

            return await _repository.Register(entity, salt);
        }

        public async Task<bool> Update(int id, EditViewModel view)
        {
            return await _repository.Update(id, view);
        }
    }
}