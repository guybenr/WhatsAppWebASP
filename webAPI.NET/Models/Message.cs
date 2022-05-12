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
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public bool Sent { get; set; }

        public int ChatId { get; set; }

    }
}
