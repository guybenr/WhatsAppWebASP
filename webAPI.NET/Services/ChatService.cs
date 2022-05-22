using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;

namespace webAPI.NET.Services
{
	public class ChatService : IChatService
	{
		private readonly Context _context;

		public ChatService(Context context)
		{
			_context = context;
		}
		
		//return the chat between person with id1 to person with id2
		public async Task<Chat> Get(string id1, string id2)
		{
			return await _context.Chat.Where(x => x.User1 == id1 && x.User2 == id2).FirstOrDefaultAsync();
		}

		//add chat between person with id1 to person with id2
		public async Task<bool> PostChat(string user1, string user2)
		{
			Chat chat = new Chat(user1, user2);
			_context.Chat.Add(chat);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (ChatExists(chat.Id))
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

		//add new message to chat between person with id1 to person with id2
		public async Task<bool> addMessage(string user1, string user2, Message message)
		{
			Chat chat = await Get(user1, user2);
			if (chat == null)
			{
				return false;
			}
			message.ChatId = chat.Id;
			chat.Messages.Add(message);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (ChatExists(chat.Id))
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

		//cheack if chat between person with id is exist
		public bool ChatExists(int id)
		{
			return _context.Chat.Any(e => e.Id == id);
		}
	}
}
