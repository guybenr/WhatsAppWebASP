using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.NET.Data;
using webAPI.NET.Models;
using webAPI.NET.Services;

namespace webAPI.NET.Controllers
{
    [Route("api/invitations")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly IContactService _service;

        public InvitationsController(IContactService service)
        {
            _service = service;
        }


        // POST: api/invitations
        [HttpPost]
        public async Task<IActionResult> PostInvitation(Invitation invitation)
        {
            var isInvitation = await _service.Post(invitation.To, invitation.From, invitation.From, invitation.Server);
            if(!isInvitation)
            {
                return NotFound();
            }
            return StatusCode(201);
        }
    }
}
