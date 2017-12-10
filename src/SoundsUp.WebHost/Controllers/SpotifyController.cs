using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;

namespace SoundsUp.WebHost.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class SpotifyController : Controller
    {
        // GET spotify/token
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var credentials = new ClientCredentialsAuth()
            {
                // ClientId of our Spotify application. Get this from Spotify Developer Dashboard.
                ClientId = "4bc6ac23937346d0b6f0324e2e1e4af4",

                // ClientSecred of our Spotify application.
                // TODO RESET ClientSecret
                // TODO Find way to store this securely, fx use environment variables and maybe encryption with NaCl?
                ClientSecret = "f9f05ad8f2744a68973a12e8d4580111",

                // We don't need user permissions since we only want to search tracks
                Scope = Scope.None
            };

            var token = credentials.DoAuth();

            return Ok(new { Token = token });
        }
    }
}