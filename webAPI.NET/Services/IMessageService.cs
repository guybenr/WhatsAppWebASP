using webAPI.Models;

namespace webAPI.NET.Services
{
	public interface IMessageService
	{
		public Task<List<Message>> GetAll(string userId, string id);

		public Task<Message> Get(string UserId, string id1, int id2);

		public Task<bool> Post(string senderId, string reciverId, Message message);

		public Task<bool> Put(string UserId, string id1, int id, string content);

		public Task<bool> Delete(string UserId, string id1, int id);


		public bool MessageExists(int id);
	}
}
