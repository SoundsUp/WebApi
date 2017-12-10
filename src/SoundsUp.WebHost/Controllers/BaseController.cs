using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundsUp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController : Controller
    {
        public bool GetIdFromClaims(out int id)
        {
            return int.TryParse(HttpContext.User.Claims.First().Value, out id);
        }
    }
}