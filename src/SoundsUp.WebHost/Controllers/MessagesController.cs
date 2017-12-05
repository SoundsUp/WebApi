using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        [HttpGet]
        [Authorize]
        public IActionResult GetMessages([FromQuery]string userConversation)
        {

           
           if (ModelState.IsValid)
            {
                
                var userAuthorized = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub).Value;
                var conversation = new ConversationViewModel
                {
                    UserAuthorized = Convert.ToInt32(userAuthorized),
                    UserConversation = Convert.ToInt32(userConversation)
                };

                /* var messages = await _manager.Get(conversation);
                 // if(messages == null)
                  //{
                      return BadRequest();
                  }
                  return Ok(messages); */

                return Ok(conversation);
            }

            return BadRequest(ModelState);

        }
    }
}