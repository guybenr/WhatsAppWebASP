namespace webAPI.Models
{
    public interface IMessageService
    {
        public List<Message> GetAll(string id);
        Message Get(int id, string contact);

        public bool Edit(int id, string contact , string newMessage);

        public bool Delete(int id, string contact);

        public bool Add(string contact, Message newMessage);

    }
}
