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

		public async Task<User> GetUser(string username)
		{
			return await _context.User.FindAsync(username);
		}
	}
}
