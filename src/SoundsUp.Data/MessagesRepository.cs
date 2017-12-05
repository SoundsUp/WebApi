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

        public async Task<Messages> Create(MessageViewModel entity)
        {
            var message = new Messages
            {
                MsgContent = entity.MsgContent,
                // TODO transformations TimeStamp = entity.Time
                UserTo = entity.UserTo,
                UserFrom = entity.UserFrom
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }
    }
   
}
