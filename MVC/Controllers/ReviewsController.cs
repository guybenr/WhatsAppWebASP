using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<Review> reviews = new List<Review>();
        private static float average = 0;
        public ReviewsController()
        {

        }
        public IActionResult Index()
        {
            Data data = new Data() { Average=average, Reviews=reviews};
            return View(data);
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

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(string name, string description, int grade)
        {
            float temp = average * reviews.Count;
            int nextId;
            if (reviews.Count == 0)
            {
                nextId = 1;
            }
            else
            {
                nextId = reviews.Max(x => x.Id);
            }
            reviews.Add(new Review() {Id = nextId + 1 , Name = name, Description = description, Grade = grade , dateTime=DateTime.Now});
            average = (temp + grade) / (reviews.Count);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            Review review = reviews.Find(x => x.Id == id);
            return View(review);

        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string description, int grade)
        {
            Review review = reviews.Find(x => x.Id == id);
            review.Name = name;
            review.Description = description;
            review.Grade = grade;
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Review review = reviews.Find(x => x.Id == id);
            return View(review);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteReal(int id)
        {
            Review review = reviews.Find(x => x.Id == id);
            reviews.Remove(review);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Search(string input)
        {
            List<Review> searchReviews = new List<Review>();
            foreach (Review review in reviews)
            {
                if (review.Name.StartsWith(input))
                {
                    searchReviews.Add(review);
                }
            }
            return View("Index", searchReviews);

        }

    }
}
