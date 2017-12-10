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
    public class MessageRepository : IMessageRepository
    {
        private readonly SoundsUpSQLDatabaseContext _context;

        public MessageRepository(SoundsUpSQLDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Messages> Create(Messages entity)
        {
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Messages>> Get(ParticipantsViewModel participants)
        {
            var messages = await _context.Messages
                .FromSql("EXECUTE [dbo].[GetConversation] " +
                          "@UserId1 = {0}, " +
                          "@UserId2 = {1}",
                    participants.UserAuthorized, participants.UserParticipant)
                .ToListAsync();

            return messages;
        }
    }
   
}
