namespace webAPI.Models
{
    public class Contact
    {
        public Contact(string id, string name, string server, string last, DateTime lastDate, string password)
        {
            Id = id;    
            Password = password;
            Name = name;    
            Server = server;    
            Last = last;    
            LastDate = lastDate; 
            Contacts = new List<Contact>();
            Messages = new List<Message>();
        }
        public string Id { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }

        public string Server { get; set; }

        public string Last { get; set; }

        public DateTime LastDate { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<Message> Messages { get; set; }
    }
}
