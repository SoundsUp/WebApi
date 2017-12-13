using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public async Task<IActionResult> Post([FromRoute] int userConversation, [FromBody] MessageContentViewModel body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var parsed = GetIdFromClaims(out var id);

            var entity = new MessageViewModel
            {
                UserTo = userConversation,
                UserFrom = id,
                MsgContent = body.MsgContent
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