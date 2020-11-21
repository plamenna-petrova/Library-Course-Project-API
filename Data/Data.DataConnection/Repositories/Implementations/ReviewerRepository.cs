using Data.DataConnection.Repositories.Interfaces;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataConnection.Repositories.Implementations
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ApplicationDbContext _reviewerContext;

        public ReviewerRepository(ApplicationDbContext reviewerContext)
        {
            _reviewerContext = reviewerContext;
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerContext.Reviewers.OrderBy(rev => rev.ReviewerLastName).ToList();
        }

        public Reviewer GetReviewerById(int reviewerId)
        {
            return _reviewerContext.Reviewers.Where(rev => rev.Id == reviewerId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerContext.Reviews.Where(rev => rev.Reviewer.Id == reviewerId).ToList();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            var reviewerId = _reviewerContext.Reviews.Where(re => re.Id == reviewId).Select(rev => rev.Reviewer.Id).FirstOrDefault();
            return _reviewerContext.Reviewers.Where(rev => rev.Id == reviewerId).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewersOfABook(int bookId)
        {
            return _reviewerContext.BooksReviewers.Where(b => b.BookId == bookId).Select(rev => rev.Reviewer).ToList();
        }

        public ICollection<Book> GetBooksOfAReviewer(int reviewerId)
        {
            return _reviewerContext.BooksReviewers.Where(rev => rev.ReviewerId == reviewerId).Select(b => b.Book).ToList();
        }

        public Country GetCountryOfAReviewer(int reviewerId)
        {
            return _reviewerContext.Reviewers.Where(rev => rev.Id == reviewerId).Select(c => c.Country).FirstOrDefault();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerContext.Reviewers.Any(rev => rev.Id == reviewerId);
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _reviewerContext.Add(reviewer);
            return Save();
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _reviewerContext.Update(reviewer);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            _reviewerContext.Remove(reviewer);
            return Save();
        }

        public bool Save()
        {
            var saved = _reviewerContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}