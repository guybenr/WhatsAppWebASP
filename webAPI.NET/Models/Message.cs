namespace webAPI.Models
{
    public class Message
    {
        public Message(int id, string contact, string content, DateTime created, string sent)
        {
            Id = id;
            Contact = contact;
            Content = content;
            Created = created;
            Sent = sent;
        }
        public int Id { get; set; }
        public string Contact { get; set; }

        public string Content { get; set; }
        public DateTime Created { get; set; }

        public string Sent { get; set; }


    }
}
