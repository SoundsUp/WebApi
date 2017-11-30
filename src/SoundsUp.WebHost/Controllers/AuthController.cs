﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IManager _manager;

        public AuthController(IManager manager)
        {
            _manager = manager;
        }

        // POST auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _manager.Login(entity);

            if (id == null) return NotFound(new { errorMessage = "Incorrect password or username" });

            var encodedJwt = CreateToken(id.ToString());

            return Ok(new { Token = encodedJwt });
        }

        // POST auth/Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _manager.Register(entity);

            if (id == null) return BadRequest(new { errorMessage = "Problem with registering" });

            var encodedJwt = CreateToken(id.ToString());

            return Ok(new { Token = encodedJwt, registedUserId = id });
        }

        private static string CreateToken(string id)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the Secret phrase"));

            var signingCreditenals = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256); // TODO Security here, find the best algorithm, expire token etc

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