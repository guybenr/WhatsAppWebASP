using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;
using webAPI.NET.Models;
using webAPI.NET.Services;

namespace webAPI.NET.Controllers
{
    [Route("api/transfer")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly IMessageService _service;

        public TransfersController(IMessageService service)
        {
            _service = service;
        }


        // POST: api/transfer
        [HttpPost]
        public async Task<ActionResult<Transfer>> PostTransfer([FromBody] Transfer transfer)
        {
            Message message = new Message(transfer.Content, DateTime.Now, false);
            var isTransfer = await _service.Post(transfer.To, transfer.From, message);
            if (!isTransfer)
            {
                return BadRequest();
            }
            return NoContent();
        }

        
    }
}
