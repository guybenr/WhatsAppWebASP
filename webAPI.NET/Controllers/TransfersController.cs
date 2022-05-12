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
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly IMessageService _service;

        public TransfersController(IMessageService service)
        {
            _service = service;
        }


        // POST: api/Transfers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transfer>> PostTransfer(Transfer transfer)
        {
            var isTransfer = await _service.Post(transfer.To, transfer.Content);
            if (!isTransfer)
            {
                return BadRequest();
            }
            return NoContent();
        }

        
    }
}
