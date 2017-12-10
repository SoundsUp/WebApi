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
            var message = new Messages
            {
                MsgContent = entity.MsgContent,
                UserTo = entity.UserTo,
                UserFrom = entity.UserFrom
            };

            return await _repository.Create(message);
        }

        public async Task<IEnumerable<Messages>> Get(ParticipantsViewModel participants)
        {
            return await _repository.Get(participants);
        }
    }
}
