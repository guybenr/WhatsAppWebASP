using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webAPI.Models
{
    public class User
    {
        public User(string id, string name, string password, string image)
        {
            Id = id;
            Name = name;
            Password = password;
            Image = image;
            Contacts = new List<Contact>();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public ICollection<Contact> Contacts { get; set; }

    }
}
