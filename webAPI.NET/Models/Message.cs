namespace webAPI.Models
{
    public class Message
    {
        public Message(int id, string content, DateTime created, string sent)
        {
            Id = id;
            Content = content;
            Created = created;
            Sent = sent;
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public string Sent { get; set; }


    }
}
