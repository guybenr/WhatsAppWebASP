using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _service;
        public ReviewsController()
        {
            _service = new ReviewService();
        }
        public IActionResult Index()
        {
            Data data = _service.GetData();
            return View(data);
        }

        public IActionResult Index2()
        {
            Data data = _service.GetData();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            Review review = _service.GetReview(id);
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
            _service.Create(name, description, grade);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            Review review = _service.Edit(id);
            return View(review);

        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string description, int grade)
        {
            _service.Edit2(id, name, description, grade);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Review review = _service.GetReview(id);
            return View(review);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteReal(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search(string input)
        {
            Data data = _service.Search(input);
            return PartialView(data);
        }

    }
}
