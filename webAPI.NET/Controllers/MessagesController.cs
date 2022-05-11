using System;
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
        private readonly IMessageService _service;



        public MessagesController(IMessageService service)
        {
            _service = service;
        }



		// GET: api/Contacts
		[HttpGet]
		public async Task<IEnumerable<Message>> GetMessage(string id)
		{
			return await _service.GetAll(id);
		}



		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public async Task<Message> GetMessage(string id1, int id)
		{
			var message = await _service.Get(id1,id);
			if (message == null)
			{
				return null;
			}
			return message;
		}



		// PUT: api/Contacts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutContact(string id1, int id, string content)
		{
			var isUpdate = await _service.Put(id1, id, content);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}



		// POST: api/Contacts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<IActionResult> PostContact(string id, string content)
		{
			var isAdd = await _service.Post(id, content);
			if (!isAdd)
			{
				return BadRequest();
			}
			return NoContent();


		}



		// DELETE: api/Contacts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(string id1, int id)
		{
			var isDelete = await _service.Delete(id1, id);
			if (!isDelete)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
