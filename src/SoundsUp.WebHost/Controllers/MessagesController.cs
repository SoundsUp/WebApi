using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using SoundsUp.Domain.Entities.Models;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IMessagesManager _manager;

        public MessagesController(IMessagesManager manager)
        {
            _manager = manager;
        }

        // POST api/messages
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]MessageViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var messages = await _manager.Create(entity);
                if (messages == null)
                {
                    return BadRequest();
                }
                return Ok(messages);
            }

            return BadRequest(ModelState);
        }
    }
}