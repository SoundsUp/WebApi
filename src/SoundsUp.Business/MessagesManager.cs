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

        public Task<Messages> Create(MessageViewModel entity)
        {
            return _repository.Create(entity);
        }

        public Task<IEnumerable<Messages>> Get(ConversationViewModel conversation)
        {
            return _repository.GetConversation(conversation);
        }
    }
}
