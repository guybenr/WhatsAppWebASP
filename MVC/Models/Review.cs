using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(1,5 , ErrorMessage = "Please Enter grade between 1-5")]
        public int Grade { get; set; }

        public DateTime dateTime { get; set; }
    }
}
