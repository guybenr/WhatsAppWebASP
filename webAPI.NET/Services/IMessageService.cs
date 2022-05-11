using webAPI.Models;

namespace webAPI.NET.Services
{
	public interface IMessageService
	{
		public Task<List<Message>> GetAll(string id);

		public Task<Message> Get(string id1, int id2);

		public Task<bool> Post(string id, string content);

		public Task<bool> Put(string id1, int id, string content);

		public Task<bool> Delete(string id1, int id);


		public bool MessageExists(int id);
	}
}
