using webAPI.Models;

namespace webAPI.NET.Services
{
    public interface IUserService
    {
        public Task<User> IsExist(string username, string password);
        public Task<User> GetUser(string username);

        public Task<bool> AddUser(User user);
    }
}
