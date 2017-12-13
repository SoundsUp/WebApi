using Microsoft.AspNetCore.Mvc;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : BaseController
    {
        private readonly IMessageManager _manager;

        public MessagesController(IMessageManager manager)
        {
            _manager = manager;
        }

        // POST api/messages/id
        [HttpPost("{userConversation}")]
        public async Task<IActionResult> Post([FromRoute] int userConversation, [FromBody][Required] string body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parsed = GetIdFromClaims(out var id);

            if (!parsed) return Unauthorized();

            var entity = new MessageViewModel
            {
                UserTo = userConversation,
                UserFrom = id,
                MsgContent = body
            };

            var messages = await _manager.Create(entity);
            if (messages == null)
            {
                return BadRequest();
            }
            return Ok(messages);
        }

        [HttpGet("{userConversation}")]
        public async Task<IActionResult> Get([FromRoute] int userConversation)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parsed = GetIdFromClaims(out var id);

            if (!parsed) return Unauthorized();

            var conversation = new ParticipantsViewModel
            {
                UserAuthorized = id,
                UserParticipant = userConversation
            };

            var messages = await _manager.Get(conversation);
            if (messages == null)
            {
                return BadRequest();
            }
            return Ok(messages);
        }
    }
}