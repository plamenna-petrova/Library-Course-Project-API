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
    public class ReviewersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewers()
        {
            var reviewersToGet = _unitOfWork.ReviewerRepository.GetReviewers();

            return Ok(reviewersToGet);
        }

        [Route("api/reviewers/reviewerId")]
        [HttpGet("{reviewerId}", Name = "GetReviewerById")]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReviewerById(int reviewerId)
        {
            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var singleReviewer = _unitOfWork.ReviewerRepository.GetReviewerById(reviewerId);

            return Ok(singleReviewer);
        }

        [Route("api/reviewers/books/bookId")]
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReviewersOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var reviewersOfABook = _unitOfWork.ReviewerRepository.GetReviewersOfABook(bookId);

            return Ok(reviewersOfABook);
        }

        [Route("api/reviewers/reviewerId/books")]
        [HttpGet("{reviewerId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksOfAReviewer(int reviewerId)
        {
            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var booksOfAReviewer = _unitOfWork.ReviewerRepository.GetBooksOfAReviewer(reviewerId);

            return Ok(booksOfAReviewer);
        }


        [Route("api/reviewers/countries/reviewerId")]
        [HttpGet("countries/{reviewerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryOfAnAuthor(int reviewerId)
        {
            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var country = _unitOfWork.ReviewerRepository.GetCountryOfAReviewer(reviewerId);

            return Ok(country);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReviewerDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateReviewer([FromBody] ReviewerCreateDto newReviewer)
        {
            if (newReviewer == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.ReviewerRepository.ReviewerExists(newReviewer.Id))
            {
                ModelState.AddModelError("", "Such reviewer Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.ReviewerRepository.CreateReviewer(newReviewer))
            {
                ModelState.AddModelError("", $"Something went wrong saving the reviewer " + $"{newReviewer.ReviewerFirstName}{newReviewer.ReviewerLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetReviewerById", new { reviewerId = newReviewer.Id }, newReviewer);
        }

        [Route("api/reviewers/reviewerId")]
        [HttpPut("{reviewerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerUpdateDto updatedReviewer)
        {
            if (updatedReviewer == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewerId != updatedReviewer.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                ModelState.AddModelError("", "Reviewer doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.ReviewerRepository.UpdateReviewer(updatedReviewer))
            {
                ModelState.AddModelError("", $"Something went wrong updating the reviewer " + $"{updatedReviewer.ReviewerFirstName}{updatedReviewer.ReviewerLastName}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/reviewers/reviewerId")]
        [HttpDelete("{reviewerId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteReviewer(int reviewerId)
        {
            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var reviewerToDelete = _unitOfWork.ReviewerRepository.GetReviewerByIdNotMapped(reviewerId);

            if (!_unitOfWork.ReviewerRepository.DeleteReviewer(reviewerToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{reviewerToDelete.ReviewerFirstName}{reviewerToDelete.ReviewerLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
