using MVC.Models;

namespace MVC.Services
{
    public interface IReviewService
    {
        public Data GetData();

        public Review GetReview(int id);

        public void Create(string name, string description, int grade);

        public Review Edit(int id);

        public void Edit2(int id, string name, string description, int grade);

        public void Delete(int id);

        public Data Search(string input);
    }
}
