using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Message
    {
        public Message( string content, DateTime created, bool sent)
        {
            Content = content;
            Created = created;
            Sent = sent;
        }
        [Key]
        public int Id { get; set; }
        
        public string Content { get; set; }
        
        public DateTime Created { get; set; }
        
        public bool Sent { get; set; }

        public int ChatId { get; set; }

    }
}
