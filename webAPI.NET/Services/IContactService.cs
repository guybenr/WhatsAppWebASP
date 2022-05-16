using webAPI.Models;

namespace webAPI.NET.Services
{
	public interface IContactService
	{
		public Task<List<Contact>> GetAll(string userId);

		public Task<Contact> Get(string id1, string id2);

		public Task<bool> Post(string userId, string id, string name, string server);

		public  Task<bool> Put(string userId, string id, string name, string server);

		public Task<bool> Delete(string userId, string id);


		public bool ContactExists(string id);
	}
}
