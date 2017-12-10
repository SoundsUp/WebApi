using System.Collections.Generic;
using SoundsUp.Domain.Contracts;
using System.Threading.Tasks;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;

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

        public Task<IEnumerable<CorrespondentViewModel>> Get(int userId)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICorrespondentRepository
    {
    }
}
