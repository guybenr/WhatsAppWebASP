using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class User
    {
        public User(string id, string userName, string password, string image)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Image = image;
            Contacts = new List<Contact>();
        }
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Image { get; set; }

        public List<Contact> Contacts { get; set; }

    }
}
