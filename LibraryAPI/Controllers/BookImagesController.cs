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
    public class BookImagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookImagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookImageDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBookImages()
        {
            var bookImagesToGet = _unitOfWork.BookImageRepository.GetBookImages();

            return Ok(bookImagesToGet);
        }

        [Route("api/bookimages/bookImageId")]
        [HttpGet("{bookImageId}", Name = "GetBookImageById")]
        [ProducesResponseType(200, Type = typeof(BookImageDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBookImageById(int bookImageId)
        {
            if (!_unitOfWork.BookImageRepository.BookImageExists(bookImageId))
            {
                return NotFound();
            }

            var singleBookImage = _unitOfWork.BookImageRepository.GetBookImageById(bookImageId);

            return Ok(singleBookImage);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BookImageDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult CreateBookImage([FromBody] BookImageCreateDto newBookImage)
        {
            if (newBookImage == null)
            {
                return BadRequest(ModelState);
            }

            //if (!_unitOfWork.BookImageRepository.BookImageExists(newBookImage.Id))
            //{
            //    ModelState.AddModelError("", "Such book image Exists!");
            //    return StatusCode(404, ModelState);
            //}

            if (!_unitOfWork.BookImageRepository.CreateBookImage(newBookImage))
            {
                ModelState.AddModelError("", $"Something went wrong saving the book image " + $"{newBookImage.BookImageUrl}");
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetBookImageById", new { bookImageId = newBookImage.Id }, newBookImage);
        }

        [Route("api/bookimage/bookImageId")]
        [HttpPut("{bookImageId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult UpdateAuthor(int bookImageId, [FromBody] BookImageUpdateDto updatedBookImage)
        {
            if (updatedBookImage == null)
            {
                return BadRequest(ModelState);
            }

            if (bookImageId != updatedBookImage.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.BookImageRepository.BookImageExists(bookImageId))
            {
                ModelState.AddModelError("", "Book Image doesn't exitst!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.BookImageRepository.UpdateBookImage(updatedBookImage))
            {
                ModelState.AddModelError("", $"Something went wrong updating the book image " + $"{updatedBookImage.BookImageUrl}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/bookimages/bookImageId")]
        [HttpDelete("{bookImageId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]

        public IActionResult DeleteBookImage(int bookImageId)
        {
            if (!_unitOfWork.BookImageRepository.BookImageExists(bookImageId))
            {
                return NotFound();
            }

            var bookImageToDelete = _unitOfWork.BookImageRepository.GetBookImageByIdNotMapped(bookImageId);

            if (!_unitOfWork.BookImageRepository.DeleteBookImage(bookImageToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{bookImageToDelete.BookImageUrl}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
