using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class User
    {
        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
        List<Contact> Contacts { get; set; }
    }
}
