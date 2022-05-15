using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webAPI.Models
{
    public class Contact
    {
        public Contact(string id, string name, string server, string last, DateTime lastDate, string userId)
        {
            Id = id;
            Name = name;    
            Server = server;    
            Last = last;    
            LastDate = lastDate; 
            UserId = userId;
        }
        [Key, Column(Order = 0)]
        [Required]
        public string? Id { get; set; }

        [Key, Column(Order = 1)]
        [JsonIgnore]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string Last { get; set; }
        public DateTime LastDate { get; set; }
        

    }
}
