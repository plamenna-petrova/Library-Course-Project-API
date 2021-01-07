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
    public class PublishersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublishersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PublisherDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetPublishers()
        {
            var publishersToGet = _unitOfWork.PublisherRepository.GetPublishers();

            return Ok(publishersToGet);
        }

        [Route("api/publishers/publisherId")]
        [HttpGet("{publisherId}", Name = "GetPublisherById")]
        [ProducesResponseType(200, Type = typeof(PublisherDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetPublisherById(int publisherId)
        {
            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var singlePublisher = _unitOfWork.PublisherRepository.GetPublisherById(publisherId);

            return Ok(singlePublisher);
        }

        [Route("api/publishers/publisherId/books")]
        [HttpGet("{publisherId}/books")]
        [ProducesResponseType(200, Type = typeof (IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksOfAPublisher(int publisherId)
        {
            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var booksOfAPublisher = _unitOfWork.PublisherRepository.GetBooksOfAPublisher(publisherId);

            return Ok(booksOfAPublisher);
        }

        [Route("api/publishers/authorId/authors")]
        [HttpGet("{authorId}/authors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PublisherDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetPublishersByAuthor(int authorId)
        {
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var publishersByAuthor = _unitOfWork.PublisherRepository.GetPublishersByAuthor(authorId);

            return Ok(publishersByAuthor);
        }

        [Route("api/publishers/authors/publisherId")]
        [HttpGet("authors/{publisherId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsByPublisher(int publisherId)
        {
            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var authorsByPublisher = _unitOfWork.PublisherRepository.GetAuthorsByPublisher(publisherId);

            return Ok(authorsByPublisher);
        }

        [Route("api/publishers/countries/publisherId")]
        [HttpGet("countries/{publisherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(PublisherDto))]
        public IActionResult GetCountryOfAPublisher(int publisherId)
        {
            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var country = _unitOfWork.PublisherRepository.GetCountryOfAPublisher(publisherId);

            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PublisherDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreatePublisher([FromBody] PublisherCreateDto newPublisher)
        {
            if (newPublisher == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.PublisherRepository.PublisherExists(newPublisher.Id))
            {
                ModelState.AddModelError("", "Such publisher Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.PublisherRepository.CreatePublisher(newPublisher))
            {
                ModelState.AddModelError("", $"Something went wrong saving the publisher " + $"{newPublisher.PublisherName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetPublisherById", new { publisherId = newPublisher.Id }, newPublisher);
        }

        [Route("api/publishers/publisherId")]
        [HttpPut("{publisherId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdatePublisher(int publisherId, [FromBody] PublisherUpdateDto updatedPublisher)
        {
            if (updatedPublisher == null)
            {
                return BadRequest(ModelState);
            }

            if (publisherId != updatedPublisher.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                ModelState.AddModelError("", "Publisher doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.PublisherRepository.UpdatePublisher(updatedPublisher))
            {
                ModelState.AddModelError("", $"Something went wrong updating the publisher " + $"{updatedPublisher.PublisherName}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/publishers/publisherId")]
        [HttpDelete("{publisherId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeletePublisher(int publisherId)
        {
            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var publisherToDelete = _unitOfWork.PublisherRepository.GetPublisherByIdNotMapped(publisherId);

            if (!_unitOfWork.PublisherRepository.DeletePublisher(publisherToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{publisherToDelete.PublisherName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
