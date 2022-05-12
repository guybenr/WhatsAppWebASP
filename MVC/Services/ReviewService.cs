using MVC.Models;

namespace MVC.Services
{
    public class ReviewService : IReviewService
    {
        private static List<Review> reviews = new List<Review>();
        private static float average = 0;
        private static int temp = 0;


        public Data GetData()
        {
            return new Data() { Average = average, Reviews = reviews };
        }

        public Review GetReview(int id)
        {
            return reviews.Find(x => x.Id == id);
        }

        public void Create(string name, string description, int grade)
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
            reviews.Add(new Review() { Id = nextId + 1, Name = name, Description = description, Grade = grade, dateTime = DateTime.Now });
            average = (temp + grade) / (reviews.Count);
        }

        public Review Edit(int id)
        {
            Review review = reviews.Find(x => x.Id == id);
            if (review != null)
            {
                temp = review.Grade;
            }
            return review;
        }

        public void Edit2(int id, string name, string description, int grade)
        {
            Review review = reviews.Find(x => x.Id == id);
            review.Name = name;
            review.Description = description;
            review.Grade = grade;
            average = average * reviews.Count;
            average -= temp;
            average += review.Grade;
            average = average / (reviews.Count);
        }

        public void Delete(int id)
        {
            average = average * reviews.Count;
            Review review = reviews.Find(x => x.Id == id);
            average -= review.Grade;
            reviews.Remove(review);
            average = average / (reviews.Count);
        }

        public Data Search(string input)
        {
            List<Review> searchReviews = new List<Review>();
            if (input == null)
            {
                searchReviews = reviews;
            }
            else
            {
                foreach (Review review in reviews)
                {
                    if (review.Name.StartsWith(input))
                    {
                        searchReviews.Add(review);
                    }
                }
            }
            Data data = new Data() { Average = average, Reviews = searchReviews };
            return data;
        }

    }
}
