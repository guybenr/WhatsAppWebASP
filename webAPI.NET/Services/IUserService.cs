namespace webAPI.NET.Services
{
    public interface IUserService
    {
        public Task<User> IsExist(string username, string password);
    }
}
