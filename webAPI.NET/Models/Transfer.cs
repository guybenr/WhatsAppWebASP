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
       
        public int Id { get; set; }
        
        public string From { get; set; }
        
        public string To { get; set; }
        
        public string Content { get; set; }
    }
}
