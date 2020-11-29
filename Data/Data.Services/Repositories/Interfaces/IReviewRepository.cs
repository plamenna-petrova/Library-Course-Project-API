using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReviewById(int reviewId);
        ICollection<Review> GetReviewsOfABook(int bookId);
        Book GetBookOfAReview(int reviewId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        Reviewer GetReviewerOfAReview(int reviewId);
        bool ReviewExists(int reviewId);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();
    }
}