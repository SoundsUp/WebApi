using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Produces("application/json")]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthManager _manager;

        public AuthController(IAuthManager manager)
        {
            _manager = manager;
        }

        // POST api/users/login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]Login entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var account = await _manager.Login(entity);

            if (account == null) return NotFound(new { errorMessage = "Incorrect password or username" });

            var encodedJwt = CreateToken(account.Id.ToString());

            return Ok(new { Token = encodedJwt, Account = account });
        }

        // POST api/users/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var account = await _manager.Register(entity);

            if (account == null) return BadRequest(new { errorMessage = "Problem with registering" });

            var encodedJwt = CreateToken(account.Id.ToString());

            return Ok(new { Token = encodedJwt, Account = account });
        }

        private static string CreateToken(string id)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the Secret phrase"));
            var signingCreditenals = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id),
            };
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCreditenals);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}