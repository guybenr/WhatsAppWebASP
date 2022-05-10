using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Contact
    {
        public Contact(string name, string userName, string server, string last, DateTime lastDate, string userId)
        {
            Name = name;
            UserName = userName;    
            Server = server;    
            Last = last;    
            LastDate = lastDate; 
            UserId = userId;
        }
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Server { get; set; }
        [Required]
        public string Last { get; set; }
        [Required]
        public DateTime LastDate { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
