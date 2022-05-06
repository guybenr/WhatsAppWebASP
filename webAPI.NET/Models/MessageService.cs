namespace webAPI.Models
{
    public class MessageService : IMessageService
    {
        private static Dictionary<string, List<Message>> _messages2 = new Dictionary<string, List<Message>>()
        {
            {"adi", new List<Message>() {
                                        new Message(1, "guy" ,"hey", DateTime.Now, "true"),
                                        new Message(2, "guy" ,"hey adi, what's app?", DateTime.Now, "false"),
                                        new Message(3, "guy" ,"good", DateTime.Now, "true")
                                        }
            },
            {"guy", new List<Message>() {
                                         new Message(2, "adi" ,"hey adi, what's app?", DateTime.Now, "true"),
                                         new Message(4, "or" ,"hey or", DateTime.Now, "true")
                                        }
            }
        };

        private static Dictionary<string, List<KeyValuePair<string, List<Message>>>> _messages = new Dictionary<string, List<KeyValuePair<string, List<Message>>>>();


        public MessageService()
        {
            _messages["adi"] = new List<KeyValuePair<string, List<Message>>>();
            List<Message> messages1 = new List<Message>() {
                                        new Message(1, "guy" ,"hey", DateTime.Now, "true"),
                                        new Message(2, "guy" ,"hey adi, what's app?", DateTime.Now, "false"),
                                        new Message(3, "guy" ,"good", DateTime.Now, "true")
                                        };
            List<Message> messages2 = new List<Message>() {
                                        new Message(1, "or" ,"hey or", DateTime.Now, "true"),
                                        new Message(2, "or" ,"hey adi, what's app?", DateTime.Now, "false"),
                                        new Message(3, "or" ,"good", DateTime.Now, "true")
                                        };
            // adding elements
            _messages["adi"].Add(new KeyValuePair<string, List<Message>>("guy", messages1));
            _messages["adi"].Add(new KeyValuePair<string, List<Message>>("or", messages2));
        }

        public List<Message> GetAll(string id)
        {
            IContactService contactService = new ContactService();
            String curContact = contactService.getCurContact().Id;
            if (_messages.ContainsKey(curContact))
            {
                return _messages[curContact].Find(x=>x.Key == id).Value;
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
                IContactService contactService = new ContactService();
                Contact curContact = contactService.getCurContact();
                _messages[curContact.Id].Find(x=>x.Key == contact).Value.Remove(Get(id, contact));
            }
        }

        public void Add(string contact, Message newMessage)
        {
            IContactService contactService = new ContactService();
            Contact curContact = contactService.getCurContact();
            if (_messages[curContact.Id].Find(x=>x.Key == contact).Key == null)
            {
                contactService.addNewContact(contact);
                _messages[curContact.Id] = new List<KeyValuePair<string, List<Message>>>();
                List<Message> list = new List<Message>() { newMessage };
                _messages[curContact.Id].Add(new KeyValuePair<string, List<Message>>(contact, list));
            }
            else
            {
                List<Message> list = GetAll(contact);
                list.Add(newMessage);
            }
        }

        public Message Get(int id, string contact)
        {
            List <Message> messagesCur = GetAll(contact);
            if (messagesCur.Find(x=>x.Contact == contact) != null)
            {
                return (messagesCur.Find(x => x.Id == id));
            }
            return null;
        }
    }
}
