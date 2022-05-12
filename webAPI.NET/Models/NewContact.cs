namespace webAPI.NET.Models
{
    public class NewContact
    {
        public NewContact(string id, string name, string server)
        {
            Id = id;
            Name = name;
            Server = server;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Server { get; set; }

    }
}
