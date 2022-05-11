using webAPI.Models;

namespace webAPI.NET.Services
{
	public interface IContactService
	{
		public Task<List<Contact>> GetAll();

		public Task<Contact> Get(string id);

		public Task<bool> Post(string id, string name, string server);

		public  Task<bool> Put(string id, string name, string server);

		public Task<bool> Delete(string id);


		public bool ContactExists(string id);
	}
}
