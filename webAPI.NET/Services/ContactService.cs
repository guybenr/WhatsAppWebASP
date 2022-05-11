using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;

namespace webAPI.NET.Services
{
	public class ContactService: IContactService
	{
		private readonly Context _context;
		private static User _user = new User("Adi Aviv", "Adi1", "123456789", "image");

		public ContactService (Context context)
		{
			_context = context;
		}


		public async Task<List<Contact>> GetAll()
		{
			return await _context.Contact.Where(x => x.UserId == _user.Id).ToListAsync();
		}

		public async Task<Contact> Get(string id)
		{
			var contacts = await _context.Contact.Where(x => x.UserId == _user.Id).ToListAsync();
			var contact = contacts.Find(x => x.Name == id);

			if (contact == null)
			{
				return null;
			}

			return contact;
		}

		public async Task<bool> Post(string id, string name, string server)
		{
			Contact contact = new Contact(id, name, server, "", DateTime.Now, _user.Id);
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

			return true;
		}

		public async Task<bool> Put(string id, string name, string server)
		{
			var contact = await Get(id);
			if (contact == null)
			{
				return false;
			}

			contact.UserName = name;

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
