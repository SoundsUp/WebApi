using System.Collections.Generic;
using System.Threading.Tasks;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;

namespace SoundsUp.Domain.Contracts
{
    public interface IMessagesManager
    {
        Task<Messages> Create(MessageViewModel entity);
        Task<IEnumerable<Messages>> Get(ParticipantsViewModel participantsUser);

    }
}
