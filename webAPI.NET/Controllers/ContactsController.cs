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
		/* function return the userId based on the JWT token */
		private string GetUserIdFromToken()
        {
			var identity = HttpContext.User.Identity as ClaimsIdentity;
			var userId = identity.FindFirst("UserId").Value;
			return userId;
		}

		// GET: api/Contacts
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetContact()
		{
			return StatusCode(200, await _contactService.GetAll(GetUserIdFromToken()));
		}



		// GET: api/Contacts/alice
		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetContact(string id)
		{
			var contact = await _contactService.Get(GetUserIdFromToken(), id);
			if (contact == null)
			{
				return StatusCode(404);
			}
			HttpContext.Response.StatusCode = 200;
			return StatusCode(200, contact);
		}



		// PUT: api/Contacts/alice
		[Authorize]
		[HttpPut("{id}")]
		public async Task<IActionResult> PutContact(string id, UpdateContact updateContact)
		{
			var isUpdate = await _contactService.Put(GetUserIdFromToken(), id, updateContact.Name, updateContact.Server);
			return StatusCode(204);
		}


		[Authorize]
		[HttpPost]
		public async Task<IActionResult> PostNewContact(NewContact newContact)
		{
			var isInvitation = await _contactService.Post(GetUserIdFromToken(), newContact.Id, newContact.Name, newContact.Server);
			return StatusCode(201);
		}

		// DELETE: api/Contacts/alice
		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(string id)
		{
			var isDelete = await _contactService.Delete(GetUserIdFromToken(), id);
			return StatusCode(204);
		}


		// GET: api/Contacts
		[Authorize]
		[HttpGet("{id}/messages")]
		public async Task<IActionResult> GetMessage(string id)
		{
			var x = await _messageService.GetAll(GetUserIdFromToken(), id);
			return StatusCode(200, x);
		}



		// GET: api/Contacts/alice/messages/5
		[Authorize]
		[HttpGet("{contactId}/messages/{messageId}")]
		public async Task<IActionResult> GetMessage(string contactId, int messageId)
		{
			var message = await _messageService.Get(GetUserIdFromToken(), contactId, messageId);
			return StatusCode(200,message);
		}



		// PUT: api/Contacts/alice/messages/5
		[Authorize]
		[HttpPut("{contactId}/messages/{messageId}")]
		public async void PutMessage(string contactId, int messageId, NewUpdateMessage message)
		{
			var isUpdate = await _messageService.Put(GetUserIdFromToken(), contactId, messageId, message.Content);
		}

		

        //Post api/contacts/{id}/message - new message from current user to {id}
        [Authorize]
		[HttpPost("{id}/messages")]
        public async Task<IActionResult> PostMessage(string id, NewUpdateMessage message)
        {
			Message msg = new Message(message.Content, DateTime.Now, true);
            var isAdd = await _messageService.Post(GetUserIdFromToken(), id, msg);
			return StatusCode(201);
		}



        // DELETE: api/Contacts/alice/messages/5
		[Authorize]
        [HttpDelete("{contactId}/messages/{messageId}")]
		public async Task<IActionResult> DeleteMessage(string contactId, int messageId)
		{
			var isDelete = await _messageService.Delete(GetUserIdFromToken(), contactId, messageId);
			return StatusCode(204);
		}



	}
}
