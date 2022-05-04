namespace webAPI.Models
{
    public class MessageService : IMessageService
    {
        private static Dictionary<string, List<Message>> _messages = new Dictionary<string, List<Message>>()
        {
            {"adi", new List<Message>() {
                                        new Message(1, "hey", DateTime.Now, "true")
                                        }
            },
            {"guy", new List<Message>() {
                                        new Message(2, "hey adi", DateTime.Now, "true")
                                        }
            }
        };
        public MessageService()
        {

        }

        public List<Message> GetAll(string id)
        {
            if (_messages.ContainsKey(id))
            {
                return _messages[id];
            }
            return null;
        }

        public void Edit(int id, string contact, Message newMessage)
        {
            Message message = Get(id, contact);
            if (message != null)
            {
                message.Sent = newMessage.Sent;
                message.Created = newMessage.Created;
                message.Contact = newMessage.Contact;
            }
        }

        public void Delete(int id, string contact)
        {
            if (Get(id, contact) != null)
            {
                _messages[contact].Remove(Get(id, contact));
            }
        }

        public void Add(string contact, Message newMessage)
        {
            if (_messages.ContainsKey(contact))
            {
                _messages[contact].Add(newMessage);
            }
        }

        public Message Get(int id, string contact)
        {
            if (_messages.ContainsKey(contact))
            {
                for (int i = 0; i < _messages[contact].Count; i++)
                {
                    if (_messages[contact][i].Id == id)
                    {
                        return _messages[contact].Find(x => x.Id == id);
                    }
                }
            }
            return null;
        }
    }
}
