using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviews()
        {
            var reviewsToGet = _unitOfWork.ReviewRepository.GetReviews();

            return Ok(reviewsToGet);
        }

        [Route("api/reviews/reviewId")]
        [HttpGet("{reviewId}", Name = "GetReviewById")]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReviewById(int reviewId)
        {
            if (!_unitOfWork.ReviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var singleReview = _unitOfWork.ReviewRepository.GetReviewById(reviewId);

            return Ok(singleReview);
        }


        [Route("api/reviews/reviewers/reviewId")]
        [Route("reviewers/{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        public IActionResult GetReviewerOfAReview(int reviewId)
        {
            if (!_unitOfWork.ReviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var reviewer = _unitOfWork.ReviewRepository.GetReviewerOfAReview(reviewId);

            return Ok(reviewer);
        }

        [Route("api/reviews/books/reviewId")]
        [Route("books/{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBookOfAReview(int reviewId)
        {
            if (!_unitOfWork.ReviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var book = _unitOfWork.ReviewRepository.GetBookOfAReview(reviewId);

            return Ok(book);
        }

        [Route("api/reviews/reviewerId/reviewers")]
        [Route("{reviewerId}/reviewers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var reviews = _unitOfWork.ReviewRepository.GetReviewsByReviewer(reviewerId);

            return Ok(reviews);
        }

        [Route("api/reviews/bookId/books")]
        [Route("{bookId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(404)]
        public IActionResult GetReviewsOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var reviews = _unitOfWork.ReviewRepository.GetReviewsOfABook(bookId);

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReviewDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateReview([FromBody] ReviewCreateDto newReview)
        {
            if (newReview == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.ReviewRepository.ReviewExists(newReview.Id))
            {
                ModelState.AddModelError("", "Such review Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.ReviewRepository.CreateReview(newReview))
            {
                ModelState.AddModelError("", $"Something went wrong saving the review " + $"{newReview.HeadLine}{newReview.Rating}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetReviewById", new { reviewId = newReview.Id }, newReview);
        }

        [Route("api/reviews/reviewId")]
        [HttpPut("{reviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateReview(int reviewId, [FromBody] ReviewUpdateDto updatedReview)
        {
            if (updatedReview == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewId != updatedReview.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.ReviewRepository.UpdateReview(updatedReview))
            {
                ModelState.AddModelError("", $"Something went wrong updating the review " + $"{updatedReview.HeadLine}{updatedReview.Rating}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/reviews/reviewId")]
        [HttpDelete("{reviewId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteReview(int reviewId)
        {
            if (!_unitOfWork.ReviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var reviewToDelete = _unitOfWork.ReviewRepository.GetReviewByIdNotMapped(reviewId);

            if (!_unitOfWork.ReviewRepository.DeleteReview(reviewToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{reviewToDelete.HeadLine}{reviewToDelete.Rating}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
