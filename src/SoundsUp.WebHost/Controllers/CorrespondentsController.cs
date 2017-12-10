using SoundsUp.Domain.Contracts;
using SoundsUp.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoundsUp.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class CorrespondentsController : BaseController 
    {
        private readonly ICorrespondentManager _manager;

        public CorrespondentsController(ICorrespondentManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parsed = GetIdFromClaims(out var id);

            if (!parsed) return Unauthorized();

            var correspondents = await _manager.Get(id);
            if (correspondents == null)
            {
                return BadRequest();
            }
            return Ok(correspondents);
        }                                  
  
    }
}
