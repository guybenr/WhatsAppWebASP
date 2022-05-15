using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;

namespace webAPI.NET.Services
{
	public class MessageService : IMessageService
	{
		private readonly Context _context;
		private static User _user = new User("adi", "Adi1", "123456789", "image");
		private readonly IChatService _chatService;

		public MessageService(Context context)
		{
			_context = context;
			_chatService = new ChatService(context);
		}


		public async Task<List<Message>> GetAll(string userId, string id)
		{
			var chat = await _chatService.Get(userId, id);
			var messages = _context.Message.Where(m=> m.ChatId == chat.Id);
			if (chat == null || messages == null)
			{
				return new List<Message>();
			}
			return messages.ToList();
		}


		public async Task<Message> Get(string id, string id1, int id2)
		{
			var messages = await GetAll( id, id1);
			var message = messages.Find(x => x.Id == id2);
			if (message == null)
			{
				return null;
			}

			return message;
		}



		public async Task<bool> Post(string senderId, string reciverId, Message message)
		{
			if (!await _chatService.addMessage(senderId,reciverId,message))
			{
				return false;
			}
			return true;
		}


		public async Task<bool> Put(string userId, string id1, int id, string content)
		{
			var message = await Get(userId, id1, id);
			if (message == null)
			{
				return false;
			}

			message.Content = content;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MessageExists(id))
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

		public async Task<bool> Delete(string userId, string id1, int id)
		{
			Message message = await Get(userId,id1,id);
			if (message == null)
			{
				return false;
			}

			_context.Message.Remove(message);
			await _context.SaveChangesAsync();

			return true;
		}


		public bool MessageExists(int id)
		{
			return _context.Message.Any(e => e.Id == id);
		}



	}
}
