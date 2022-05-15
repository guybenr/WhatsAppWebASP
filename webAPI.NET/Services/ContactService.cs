using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;

namespace webAPI.NET.Services
{
	public class ContactService: IContactService
	{
		private readonly Context _context;
		private readonly IChatService _chatService;

		public ContactService (Context context)
		{
			_context = context;
			_chatService = new ChatService(context);
		}


		public async Task<List<Contact>> GetAll(string userId)
		{
			return await _context.Contact.Where(x => x.UserId == userId).ToListAsync();
		}

		public async Task<Contact> Get(string id1, string id2)
		{
			var contacts = await _context.Contact.Where(x => x.UserId == id1).ToListAsync();
			var contact = contacts.Find(x => x.Id == id2);

			if (contact == null)
			{
				return null;
			}

			return contact;
		}

		public async Task<bool> Post(string userId, string id, string name, string server)
		{
			Contact contact = new Contact(id, name, server, "", DateTime.Now, userId);
			_context.Contact.Add(contact);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (ContactExists(contact.Name))
				{
					return false;
				}
				else
				{
					throw;
				}
			}
			if (!await _chatService.PostChat(userId, id))
			{
				return false;
			}

			return true;
		}

		public async Task<bool> Put(string userId, string id, string name, string server)
		{
			var contact = await Get(userId, id);
			if (contact == null)
			{
				return false;
			}

			contact.Name = name;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ContactExists(id))
				{
					return false;
				}
				else
				{
					throw;
				}
			}

			return true;
		}

		public async Task<bool> Delete(string id)
		{
			var contact = await _context.Contact.FindAsync(id);
			if (contact == null)
			{
				return false;
			}

			_context.Contact.Remove(contact);
			await _context.SaveChangesAsync();

			return true;
		}


		public bool ContactExists(string id)
		{
			return _context.Contact.Any(e => e.Name == id);
		}


	}
}
