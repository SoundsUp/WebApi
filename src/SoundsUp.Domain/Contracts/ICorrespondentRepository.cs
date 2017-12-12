using System.Collections.Generic;
using SoundsUp.Domain.Entities;
using System.Threading.Tasks;

namespace SoundsUp.Domain.Contracts
{
    public interface ICorrespondentRepository
    {
        Task<IEnumerable<CorrespondentViewModel>> Get(int id, int correspondentsCount);
    }
}