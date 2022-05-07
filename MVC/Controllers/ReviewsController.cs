using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<Review> reviews;

        public ReviewsController()
        {
            reviews = new List<Review>();
                reviews.Add(new Review() { Id = 1, Name = "Adi Aviv", Description = "aaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa, aaaaaaaaaaaaaaaaa. aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Grade = 5 });
                reviews.Add(new Review() { Id = 2, Name = "Guy Ben Razon", Description = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb bbbbbbbbbbbbbbbbbbbbbbbbbbb , bbbbbbbbbbbbbbbbbbbbbbbbbbb . bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", Grade = 4 });
        }
        public IActionResult Index()
        {
            return View(reviews);
        }

        public IActionResult Details(int id)
        {
            Review review = reviews.Find(x => x.Id == id);
            if (review != null)
            {
                return View(review);
            }
            return StatusCode(404, "Review Not Found");
            
        }
    }
}
