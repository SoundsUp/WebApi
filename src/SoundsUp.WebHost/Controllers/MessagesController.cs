using Microsoft.AspNetCore.Mvc;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities.Models;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IManager _manager;
        private readonly SoundsUpSQLDatabaseContext _context;

        public MessagesController(IManager manager, SoundsUpSQLDatabaseContext context)
        {
            _manager = manager;
            _context = context;
        }

        // POST api/messages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Messages entity)
        {
            if (ModelState.IsValid)
            {
                var messages = await _context.Messages.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Ok(messages);
            }

            return BadRequest(ModelState);
        }
    }
}