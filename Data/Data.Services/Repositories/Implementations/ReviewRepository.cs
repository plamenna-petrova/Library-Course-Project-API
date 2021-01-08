using Data.DataConnection;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Helpers;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _reviewContext;

        public ReviewRepository(ApplicationDbContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public ICollection<ReviewDto> GetReviews()
        {
            var reviews = _reviewContext.Reviews.OrderBy(re => re.Rating).ToList();
            var mappedReviews = MapConfig.Mapper.Map<ICollection<ReviewDto>>(reviews);
            return mappedReviews;
        }

        public ReviewDto GetReviewById(int reviewId)
        {
            var singleReview = _reviewContext.Reviews.Where(re => re.Id == reviewId).FirstOrDefault();
            var mappedReview = MapConfig.Mapper.Map<ReviewDto>(singleReview);
            return mappedReview;
        }

        public Review GetReviewByIdNotMapped(int reviewId)
        {
            var review = _reviewContext.Reviews.Where(re => re.Id == reviewId).FirstOrDefault();
            return review;
        }

        public ICollection<ReviewDto> GetReviewsOfABook(int bookId)
        {
            var reviewsOfABook = _reviewContext.Reviews.Where(b => b.Book.Id == bookId).ToList();
            var reviewsOfABookMapped = MapConfig.Mapper.Map<ICollection<ReviewDto>>(reviewsOfABook);
            return reviewsOfABookMapped;
        }

        public BookDto GetBookOfAReview(int reviewId)
        {
            var bookOfAReview = _reviewContext.Reviews.Where(re => re.Id == reviewId).Select(b => b.Book).FirstOrDefault();
            var bookOfAReviewMapped = MapConfig.Mapper.Map<BookDto>(bookOfAReview);
            return bookOfAReviewMapped;
        }

        public ICollection<ReviewDto> GetReviewsByReviewer(int reviewerId)
        {
            var reviewsByReviewer = _reviewContext.Reviews.Where(rev => rev.Reviewer.Id == reviewerId).ToList();
            var reviewsByReviewerMapped = MapConfig.Mapper.Map<ICollection<ReviewDto>>(reviewsByReviewer);
            return reviewsByReviewerMapped;
        }

        public ReviewerDto GetReviewerOfAReview(int reviewId)
        {
            var reviewerOfAReview = _reviewContext.Reviews.Where(re => re.Id == reviewId).Select(rev => rev.Reviewer).FirstOrDefault();
            var reviewerOfAReviewMapped = MapConfig.Mapper.Map<ReviewerDto>(reviewerOfAReview);
            return reviewerOfAReviewMapped;
        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewContext.Reviews.Any(re => re.Id == reviewId);
        }

        public bool CreateReview(ReviewCreateDto reviewToCreateDto)
        {
            var reviewToCreate = MapConfig.Mapper.Map<Review>(reviewToCreateDto);
            _reviewContext.Add(reviewToCreate);
            return Save();
        }

        public bool UpdateReview(ReviewUpdateDto reviewToUpdateDto)
        {
            var reviewToUpdate = MapConfig.Mapper.Map<Review>(reviewToUpdateDto);
            _reviewContext.Update(reviewToUpdate);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _reviewContext.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _reviewContext.RemoveRange(reviews);
            return Save();
        }

        public bool Save()
        {
            var saved = _reviewContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

    }
}
