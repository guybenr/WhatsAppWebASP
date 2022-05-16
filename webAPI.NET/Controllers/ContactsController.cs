using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

		private string GetUserIdFromToken()
        {
			var identity = HttpContext.User.Identity as ClaimsIdentity;
			var userId = identity.FindFirst("UserId").Value;
			return userId;
		}

		// GET: api/Contacts
		[Authorize]
		[HttpGet]
		public async Task<IEnumerable<Contact>> GetContact()
		{
			return await _contactService.GetAll(GetUserIdFromToken());
		}



		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public async Task<Contact> GetContact(string id)
		{
			var contact = await _contactService.Get(GetUserIdFromToken(), id);
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
			var isUpdate = await _contactService.Put(GetUserIdFromToken(), id, updateContact.Name, updateContact.Server);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}


		[Authorize]
		[HttpPost]
		public async Task<IActionResult> PostNewContact(NewContact newContact)
		{
			var isInvitation = await _contactService.Post(GetUserIdFromToken(), newContact.Id, newContact.Name, newContact.Server);
			if (!isInvitation)
			{
				return NotFound();
			}
			return NoContent();
		}

		// DELETE: api/Contacts/5
		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(string id)
		{
			var isDelete = await _contactService.Delete(GetUserIdFromToken(), id);
			if (!isDelete)
			{
				return NotFound();
			}
			return NoContent();
		}


		// GET: api/Contacts
		[Authorize]
		[HttpGet("{id}/messages")]
		public async Task<IEnumerable<Message>> GetMessage(string id)
		{
			var x = await _messageService.GetAll(GetUserIdFromToken(), id);
			return x;
		}



		// GET: api/Contacts/5
		[Authorize]
		[HttpGet("{id1}/messages/{id}")]
		public async Task<Message> GetMessage(string id1, int id)
		{
			var message = await _messageService.Get(GetUserIdFromToken(), id1, id);
			if (message == null)
			{
				return null;
			}
			return message;
		}



		// PUT: api/Contacts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[Authorize]
		[HttpPut("{id1}/messages/{id}")]
		public async Task<IActionResult> PutMessage(string id1, int id, NewUpdateMessage message)
		{
			var isUpdate = await _messageService.Put(GetUserIdFromToken(), id1, id, message.Content);
			if (!isUpdate)
			{
				return BadRequest();
			}
			return NoContent();
		}

		

        //Post api/contacts/{id}/message - new message from current user to {id}
        [Authorize]
		[HttpPost("{id}/messages")]
        public async Task<IActionResult> PostMessage(string id, NewUpdateMessage message)
        {
			Message msg = new Message(message.Content, DateTime.Now, true);
            var isAdd = await _messageService.Post(GetUserIdFromToken(), id, msg);
            if (!isAdd)
            {
                return BadRequest();
            }
            return NoContent();
        }



        // DELETE: api/Contacts/5
		[Authorize]
        [HttpDelete("{id1}/messages/{id}")]
		public async Task<IActionResult> DeleteMessage(string id1, int id)
		{
			var isDelete = await _messageService.Delete(GetUserIdFromToken(), id1, id);
			if (!isDelete)
			{
				return NotFound();
			}
			return NoContent();
		}



	}
}
