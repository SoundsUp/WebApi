using System.Collections.Generic;
using System.Threading.Tasks;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;

namespace SoundsUp.Domain.Contracts
{
    public interface IMessageRepository
    {
        Task<Messages> Create(Messages entity);
        Task<IEnumerable<Messages>> Get(ParticipantsViewModel entity);
    }
}
