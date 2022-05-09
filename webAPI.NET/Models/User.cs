using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class User
    {
        public User(string id, string password)
        {
            Id = id;
            Password = password;
        }
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
