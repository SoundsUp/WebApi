using System.Collections.Generic;
using SoundsUp.Domain.Contracts;
using System.Threading.Tasks;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;

namespace SoundsUp.Business
{
    public class MessagesManager : IMessagesManager
    {

        private readonly IMessagesRepository _repository;
        private readonly IValidator _validator;

        public MessagesManager(IMessagesRepository repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Messages> Create(MessageViewModel entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<IEnumerable<Messages>> Get(ConversationViewModel conversation)
        {
            return await _repository.GetConversation(conversation);
        }
    }
}
