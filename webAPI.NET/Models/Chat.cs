using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Chat
    {
        public Chat(int id, string user1, string user2)
        {
            Id = id;
            User1 = user1;
            User2 = user2;
        }


        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string User1 { get; set; }
        [Required]
        public string User2 { get; set; }
    }
}