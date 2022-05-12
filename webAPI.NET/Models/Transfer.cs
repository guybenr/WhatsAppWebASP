using System.ComponentModel.DataAnnotations;

namespace webAPI.NET.Models
{
    public class Transfer
    {
        public Transfer(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
