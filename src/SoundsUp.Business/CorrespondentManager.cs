using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundsUp.Business
{
    public class CorrespondentManager : ICorrespondentManager
    {

        private readonly ICorrespondentRepository _repository;
        private readonly IValidator _validator;

        public CorrespondentManager(ICorrespondentRepository repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<CorrespondentViewModel>> Get(int userId)
        {
            // Retrieve 5 correspondents by default
            return await _repository.Get(userId, 5);
        }
    }
}
