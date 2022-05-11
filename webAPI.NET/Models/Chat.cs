using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Chat
    {
        public Chat(string user1, string user2)
        {
            User1 = user1;
            User2 = user2;
            Messages = new List<Message>();
        }


        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string User1 { get; set; }
        [Required]
        public string User2 { get; set; }

        public List<Message> Messages { get; set; }

        
    }
}