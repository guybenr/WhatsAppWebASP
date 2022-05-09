using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Message
    {
        public Message(int id, string content, DateTime created, bool sent)
        {
            Id = id;
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


    }
}
