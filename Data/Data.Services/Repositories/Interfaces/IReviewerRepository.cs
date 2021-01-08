using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<ReviewerDto> GetReviewers();
        ReviewerDto GetReviewerById(int reviewerId);
        Reviewer GetReviewerByIdNotMapped(int reviewerId);
        ICollection<ReviewDto> GetReviewsByReviewer(int reviewerId);
        ReviewerDto GetReviewerOfAReview(int reviewId);
        ICollection<ReviewerDto> GetReviewersOfABook(int bookId);
        ICollection<BookDto> GetBooksOfAReviewer(int reviewerId);
        CountryDto GetCountryOfAReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
        bool CreateReviewer(ReviewerCreateDto reviewerToCreateDto);
        bool UpdateReviewer(ReviewerUpdateDto reviewerToUpdateDto);
        bool DeleteReviewer(Reviewer reviewer);
        bool Save();
    }
}
