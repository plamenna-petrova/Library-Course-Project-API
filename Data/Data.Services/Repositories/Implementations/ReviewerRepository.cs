﻿using Data.DataConnection;
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
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ApplicationDbContext _reviewerContext;

        public ReviewerRepository(ApplicationDbContext reviewerContext)
        {
            _reviewerContext = reviewerContext;
        }

        public ICollection<ReviewerDto> GetReviewers()
        {
            var reviewers = _reviewerContext.Reviewers.OrderBy(rev => rev.ReviewerLastName).ToList();
            var mappedReviewers = MapConfig.Mapper.Map<ICollection<ReviewerDto>>(reviewers);
            return mappedReviewers;
        }

        public ReviewerDto GetReviewerById(int reviewerId)
        {
            var singleReviewer = _reviewerContext.Reviewers.Where(rev => rev.Id == reviewerId).FirstOrDefault();
            var mappedReviewer = MapConfig.Mapper.Map<ReviewerDto>(singleReviewer);
            return mappedReviewer;
        }

        public Reviewer GetReviewerByIdNotMapped(int reviewerId)
        {
            var reviewer = _reviewerContext.Reviewers.Where(rev => rev.Id == reviewerId).FirstOrDefault();
            return reviewer;
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

        public bool CreateReviewer(ReviewerCreateDto reviewerToCreateDto)
        {
            var reviewerToCreate = MapConfig.Mapper.Map<Reviewer>(reviewerToCreateDto);
            _reviewerContext.Add(reviewerToCreate);
            return Save();
        }

        public bool UpdateReviewer(ReviewerUpdateDto reviewerToUpdateDto)
        {
            var reviewerToUpdate = MapConfig.Mapper.Map<Reviewer>(reviewerToUpdateDto);
            _reviewerContext.Update(reviewerToUpdate);
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
