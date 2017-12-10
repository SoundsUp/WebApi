using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System.Threading.Tasks;

namespace SoundsUp.Data
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly SoundsUpSQLDatabaseContext _context;

        public MessagesRepository(SoundsUpSQLDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Messages> Create(Messages entity)
        {
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Messages>> GetConversation(ConversationViewModel conversation)
        {
            var messages = await _context.Messages.Where(message 
                => (message.UserTo == conversation.UserConversation
                && message.UserFrom == conversation.UserAuthorized)
                || (message.UserTo == conversation.UserAuthorized
                && message.UserFrom == conversation.UserConversation)
            ).ToListAsync();

            return messages;
        }
    }
   
}
