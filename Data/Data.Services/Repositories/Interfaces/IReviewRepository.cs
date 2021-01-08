using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<ReviewDto> GetReviews();
        ReviewDto GetReviewById(int reviewId);
        Review GetReviewByIdNotMapped(int reviewId);
        ICollection<Review> GetReviewsOfABook(int bookId);
        Book GetBookOfAReview(int reviewId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        Reviewer GetReviewerOfAReview(int reviewId);
        bool ReviewExists(int reviewId);
        bool CreateReview(ReviewCreateDto reviewToCreateDto);
        bool UpdateReview(ReviewUpdateDto reviewToUpdateDto);
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();
    }
}
