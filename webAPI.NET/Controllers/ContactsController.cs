using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;
using webAPI.NET.Models;
using webAPI.NET.Services;

namespace webAPI.NET.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
		private readonly IMessageService _messageService;

		public ContactsController(IContactService cService, IMessageService mService)
        {
			_contactService = cService;
			_messageService = mService;

		}



		// GET: api/Contacts
		[Authorize]
		[HttpGet]
		public async Task<IEnumerable<Contact>> GetContact()
		{
			return await _contactService.GetAll();
		}



		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public async Task<Contact> GetContact(string id)
		{
			var contact = await _contactService.Get(id);
			if (contact == null)
			{
				return null;
			}
			return contact;
		}



		// PUT: api/Contacts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutContact(string id, UpdateContact updateContact)
		{
			var isUpdate = await _contactService.Put(id, updateContact.Name, updateContact.Server);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}



		// POST: api/Contacts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<IActionResult> PostContact(NewContact newContant)
		{
			var isAdd = await _contactService.Post(newContant.Id, newContant.Name, newContant.Server);
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
			var isDelete = await _contactService.Delete(id);
			if (!isDelete)
			{
				return NotFound();
			}
			return NoContent();
		}














		// GET: api/Contacts
		[HttpGet("{id}/messages")]
		public async Task<IEnumerable<Message>> GetMessage(string id)
		{
			return await _messageService.GetAll(id);
		}



		// GET: api/Contacts/5
		[HttpGet("{id1}/messages/{id}")]
		public async Task<Message> GetMessage(string id1, int id)
		{
			var message = await _messageService.Get(id1, id);
			if (message == null)
			{
				return null;
			}
			return message;
		}



		// PUT: api/Contacts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id1}/messages/{id}")]
		public async Task<IActionResult> PutMessage(string id1, int id, NewUpdateMessage message)
		{
			var isUpdate = await _messageService.Put(id1, id, message.Content);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}



		// POST: api/Contacts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("{id}/messages")]
		public async Task<IActionResult> PostMessage(string id, NewUpdateMessage message)
		{
			var isAdd = await _messageService.Post(id, message.Content);
			if (!isAdd)
			{
				return BadRequest();
			}
			return NoContent();


		}



		// DELETE: api/Contacts/5
		[HttpDelete("{id1}/messages/{id}")]
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
