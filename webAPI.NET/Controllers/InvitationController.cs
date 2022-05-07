using Microsoft.AspNetCore.Mvc;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private static readonly IInvitationService invitationService = new InvitationService();

        // POST api/<InvitationController>
        [HttpPost]
        public IActionResult Post([FromBody] Invitation invitation)
        {
            if (!invitationService.Add(invitation))
            {
                return StatusCode(404, "Can't Add this Invitation");
            }
            return Ok();
        }
    }
}
