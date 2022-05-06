namespace webAPI.Models
{
    public class Contact
    {
        public Contact(string id, string name, string server, string last, DateTime lastDate)
        {
            Id = id;    
            Name = name;    
            Server = server;    
            Last = last;    
            LastDate = lastDate;    
        }
        public string Id { get; set; }
        public string Name { get; set; }

        public string Server { get; set; }

        public string Last { get; set; }

        public DateTime LastDate { get; set; }
    }
}
