namespace webAPI.Models
{
    public interface IMessageService
    {
        public List<Message> GetAll(string id);
        Message Get(int id, string contact);

        public void Edit(int id, string contact , Message newMessage);

        public void Delete(int id, string contact);

        public void Add(string contact, Message newMessage);
    }
}
