using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundsUp.Data.Models;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Collections.Generic;
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

        // GET api/messages
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messages = await _context.Messages.ToListAsync();

            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        // POST api/messages/login
        [HttpPost("Login")]
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

        // POST api/messages/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]Register entity)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _manager.Register(entity));
            }

            return BadRequest(ModelState);
        }

        // PUT api/messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/messages/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}