using System.ComponentModel.DataAnnotations;

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
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Server { get; set; }
        [Required]
        public string Last { get; set; }
        [Required]
        public DateTime LastDate { get; set; }

        public string UserId { get; set; }


    }
}
