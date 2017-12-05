using System.Collections.Generic;
using System.Threading.Tasks;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;

namespace SoundsUp.Domain.Contracts
{
    public interface IMessagesRepository
    {
        Task<Messages> Create(MessageViewModel entity);
        Task<IEnumerable<Messages>> GetConversation(ConversationViewModel entity);
    }
}
