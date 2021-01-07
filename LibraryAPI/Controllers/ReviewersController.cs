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
