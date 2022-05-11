using webAPI.Models;

namespace webAPI.NET.Services
{
	public interface IChatService
	{

		public Task<Chat> Get(string id1, string id2);
		public Task<bool> PostChat(string user1, string user2);

		public Task<bool> addMessage(string user1, string user2, Message message);

		public bool ChatExists(int id);

	}
}
