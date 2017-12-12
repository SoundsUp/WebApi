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
    public class CorrespondentRepository : ICorrespondentRepository
    {
        private readonly SoundsUpSQLDatabaseContext _context;

        public CorrespondentRepository(SoundsUpSQLDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CorrespondentViewModel>> Get(int id, int correspondentsCount)
        {
            var correspondents = await _context.Correspondents
                .FromSql("EXECUTE  [dbo].[GetLatestCorrespondents]" +
                          "@UserId = {0}, " +
                          "@CorrespondentsCount = {1}",
                   id, correspondentsCount)
                .ToListAsync();

            return correspondents;
        }
    }
   
}
