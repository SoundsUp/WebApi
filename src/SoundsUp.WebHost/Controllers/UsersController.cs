using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IManager _manager;

        public UsersController(IManager manager)
        {
            _manager = manager;
        }

        // GET api/users/5
        [HttpGet("test")]
        public async Task<IActionResult> GetTest()
        {
            return Ok(new { Values = "values1" });
        }

        // GET api/users/5
        [Authorize]
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

        // PUT api/users/current
        [Authorize]
        [HttpPut("current")]
        public async Task<IActionResult> Edit([FromBody] EditViewModel view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parsed = GetIdFromClaims(out var id);


            if (parsed == false)
            {
                return NotFound();
            }

            var users = await _manager.Update(id, view);

            return Ok(users);
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