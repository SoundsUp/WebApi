using Microsoft.AspNetCore.Mvc;
using SoundsUp.Business;
using SoundsUp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IManager _manager;

        public UsersController(IManager manager)
        {
            _manager = manager;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _manager.Get(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // POST api/users/login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]Login entity)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _manager.Login(entity));
            }

            return BadRequest(ModelState);
        }

        // POST api/users/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]Register entity)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _manager.Register(entity));
            }

            return BadRequest(ModelState);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}