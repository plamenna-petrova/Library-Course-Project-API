using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewerById(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        Reviewer GetReviewerOfAReview(int reviewId);
        ICollection<Reviewer> GetReviewersOfABook(int bookId);
        ICollection<Book> GetBooksOfAReviewer(int reviewerId);
        Country GetCountryOfAReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool DeleteReviewer(Reviewer reviewer);
        bool Save();
    }
}
