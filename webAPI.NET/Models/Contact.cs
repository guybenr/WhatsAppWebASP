using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Contact
    {
        public Contact(string id, string name, string server, string last, DateTime lastDate)
        {
            Id = id;    
            Name = name;    
            Server = server;    
            Last = last;    
            LastDate = lastDate; 
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


    }
}
