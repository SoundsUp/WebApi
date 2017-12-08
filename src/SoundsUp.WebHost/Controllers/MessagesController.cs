using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System;
using System.Linq;
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var messages = await _manager.Create(entity);
            if (messages == null)
            {
                return BadRequest();
            }
            return Ok(messages);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessages([FromQuery]string userConversation)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userAuthorized = HttpContext.User.Claims.First().Value;
            var conversation = new ConversationViewModel
            {
                UserAuthorized = Convert.ToInt32(userAuthorized),
                UserConversation = Convert.ToInt32(userConversation)
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