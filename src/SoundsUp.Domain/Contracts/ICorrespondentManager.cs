using System.Collections.Generic;
using System.Threading.Tasks;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;

namespace SoundsUp.Domain.Contracts
{
    public interface ICorrespondentManager
    {
        Task<IEnumerable<CorrespondentViewModel>> Get(int userId);

    }
}
