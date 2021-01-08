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

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            return _reviewContext.Reviews.Where(b => b.Book.Id == bookId).ToList();
        }

        public Book GetBookOfAReview(int reviewId)
        {
            var bookId = _reviewContext.Reviews.Where(re => re.Id == reviewId).Select(b => b.Book.Id).FirstOrDefault();
            return _reviewContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewContext.Reviews.Where(rev => rev.Reviewer.Id == reviewerId).ToList();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            var reviewerId = _reviewContext.Reviews.Where(re => re.Id == reviewId).Select(rev => rev.Reviewer.Id).FirstOrDefault();
            return _reviewContext.Reviewers.Where(rev => rev.Id == reviewerId).FirstOrDefault();
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
