using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
