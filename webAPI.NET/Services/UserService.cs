using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;

namespace webAPI.NET.Services
{
    public class UserService : IUserService
    {
		private readonly Context _context;

		public UserService(Context context)
		{
			_context = context;
		}

		public async Task<User> IsExist(string username, string password)
        {
			var isExist = await _context.User.FindAsync(username);
			if (isExist == null)
            {
				return null;
            }
			if (isExist.Password != password)
            {
				return null;
			}
			return isExist;
        }

		private async Task<bool> IsUsernameTaken(string username)
		{
			var isExist = await _context.User.FindAsync(username);
			if (isExist == null)
			{
				return false;
			}
			return true;
		}

		public async Task<User> GetUser(string username)
		{
			return await _context.User.FindAsync(username);
		}

		public async Task<bool> AddUser(User user)
        {
			await _context.User.AddAsync(user);
			try
            {
				await _context.SaveChangesAsync();
            } 
			catch (DbUpdateException ex)
            {
				if(await IsUsernameTaken(user.Id))
                {
					return false;
                }
				else
                {
					throw ex;
                }
            }
			return true;
        }
	}
}
