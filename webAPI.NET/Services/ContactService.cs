using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;

namespace webAPI.NET.Services
{
	public class ContactService: IContactService
	{
		public static readonly string ServerUrl = "localhost:5028";
		private readonly Context _context;
		private readonly IChatService _chatService;
		private readonly IUserService _userService;

		public ContactService (Context context)
		{
			_context = context;
			_chatService = new ChatService(context);
			_userService = new UserService(context);
		}

		//return all contacts of person with userId
		public async Task<List<Contact>> GetAll(string userId)
		{
			return await _context.Contact.Where(x => x.UserId == userId).ToListAsync();
		}

		//return contact with id of person with userId
		public async Task<Contact> Get(string userId, string id)
		{
			var contacts = await _context.Contact.Where(x => x.UserId == userId).ToListAsync();
			var contact = contacts.Find(x => x.Id == id);

			if (contact == null)
			{
				return null;
			}

			return contact;
		}


		//create new contact with id and other details of person with userId
		public async Task<bool> Post(string userId, string id, string name, string server)
		{
			// if the contact's server is this current server then checks that there is a user with the same id
			if(server == ServerUrl && await _userService.GetUser(id) == null)
            {
				return false;
            }
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

		//change name contact with id of person with userId
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

		//delete contact with id of person with userId
		public async Task<bool> Delete(string userId, string id)
		{
			var contact = await _context.Contact.Where<Contact>(c => c.UserId == userId && c.Id == id).FirstOrDefaultAsync();   //FindAsync(id);
			if (contact == null)
			{
				return false;
			}

			_context.Contact.Remove(contact);
			await _context.SaveChangesAsync();

			return true;
		}

		//check if contact with id is exist
		public bool ContactExists(string id)
		{
			return _context.Contact.Any(e => e.Name == id);
		}


	}
}
