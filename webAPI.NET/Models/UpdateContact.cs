namespace webAPI.NET.Models
{
    public class UpdateContact
    {
        public UpdateContact(string name, string server)
        {
            Name = name;
            Server = server;
        }


        public string Name { get; set; }
        public string Server { get; set; }

    }
}
