/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;
using webAPI.NET.Services;

namespace webAPI.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;



        public MessagesController(IMessageService service)
        {
			_messageService = service;
        }



		// GET: api/Contacts
		[HttpGet]
		public async Task<IEnumerable<Message>> GetMessage(string id)
		{
			return await _messageService.GetAll(id);
		}



		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public async Task<Message> GetMessage(string id1, int id)
		{
			var message = await _messageService.Get(id1,id);
			if (message == null)
			{
				return null;
			}
			return message;
		}



		// PUT: api/Contacts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMessage(string id1, int id, string content)
		{
			var isUpdate = await _messageService.Put(id1, id, content);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}



		// POST: api/Contacts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<IActionResult> PostMessage(string id, string content)
		{
			var isAdd = await _messageService.Post(id, content);
			if (!isAdd)
			{
				return BadRequest();
			}
			return NoContent();


		}



		// DELETE: api/Contacts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMessage(string id1, int id)
		{
			var isDelete = await _messageService.Delete(id1, id);
			if (!isDelete)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
*/