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
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        
        public ContactsController(IContactService service)
        {
            _service = service;
        }



		// GET: api/Contacts
		[HttpGet]
		public async Task<IEnumerable<Contact>> GetContact()
		{
			return await _service.GetAll();
		}



		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public async Task<Contact> GetContact(string id)
		{
			var contact = await _service.Get(id);
			if (contact == null)
			{
				return null;
			}
			return contact;
		}



		// PUT: api/Contacts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutContact(string id, string name, string server)
		{
			var isUpdate = await _service.Put(id, name, server);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}



		// POST: api/Contacts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<IActionResult> PostContact(string id, string name, string server)
		{
			var isAdd = await _service.Post(id, name, server);
			if (!isAdd)
			{
				return Conflict();
			}
			return NoContent();


		}



		// DELETE: api/Contacts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(string id)
		{
			var isDelete = await _service.Delete(id);
			if (!isDelete)
			{
				return NotFound();
			}
			return NoContent();
		}




	}
}
