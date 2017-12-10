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
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET api/users/5
        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok(new { Values = "values1" });
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _userManager.Get(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT api/users/current
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

            var users = await _userManager.Update(id, view);

            return Ok(users);
        }
    }
}