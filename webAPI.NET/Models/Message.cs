namespace webAPI.Models
{
    public class Message
    {
        public Message(int id, string contact, DateTime created, string sent)
        {
            Id = id;
            Contact = contact;
            Created = created;
            Sent = sent;
        }
        public int Id { get; set; }
        public string Contact { get; set; }
        public DateTime Created { get; set; }

        public string Sent { get; set; }


    }
}
