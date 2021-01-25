using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GenreDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetGenres()
        {
            var genresToGet = _unitOfWork.GenreRepository.GetGenres();

            return Ok(genresToGet);
        }

        [Route("api/genres/genreId")]
        [HttpGet("{genreId}", Name = "GetGenreById")]
        [ProducesResponseType(200, Type = typeof(GenreDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetGenreById(int genreId)
        {
            if (!_unitOfWork.GenreRepository.GenreExists(genreId))
            {
                return NotFound();
            }

            var singleGenre = _unitOfWork.GenreRepository.GetGenreById(genreId);

            return Ok(singleGenre);
        }

        [Route("api/genres/books/bookId")]
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GenreDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAllGenresForABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var genresForABook = _unitOfWork.GenreRepository.GetAllGenresForABook(bookId);

            return Ok(genresForABook);
        }

        [Route("api/genres/genreId/books")]
        [Route("{genreId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAllBooksForGenre(int genreId)
        {
            if (!_unitOfWork.GenreRepository.GenreExists(genreId))
            {
                return NotFound();
            }

            var booksForGenre = _unitOfWork.GenreRepository.GetAllBooksForGenre(genreId);

            return Ok(booksForGenre);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(GenreDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateGenre([FromBody] GenreCreateDto newGenre)
        {
            if (newGenre == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.GenreRepository.GenreExists(newGenre.Id))
            {
                ModelState.AddModelError("", "Such genre Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.GenreRepository.CreateGenre(newGenre))
            {
                ModelState.AddModelError("", $"Something went wrong saving the genre " + $"{newGenre.GenreName}");
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetGenreById", new { genreId = newGenre.Id }, newGenre);
        }

        [Route("api/genres/genreId")]
        [HttpPut("{genreId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateGenre(int genreId, [FromBody] GenreUpdateDto updatedGenre)
        {
            if (updatedGenre == null)
            {
                return BadRequest(ModelState);
            }

            if (genreId != updatedGenre.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.GenreRepository.GenreExists(genreId))
            {
                ModelState.AddModelError("", "Genre doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.GenreRepository.UpdateGenre(updatedGenre))
            {
                ModelState.AddModelError("", $"Something went wrong updating the genre " + $"{updatedGenre.GenreName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/genres/genreId")]
        [HttpDelete("{genreId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteGenre(int genreId)
        {
            if (!_unitOfWork.GenreRepository.GenreExists(genreId))
            {
                return NotFound();
            }

            var genreToDelete = _unitOfWork.GenreRepository.GetGenreByIdNotMapped(genreId);

            if (!_unitOfWork.GenreRepository.DeleteGenre(genreToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{genreToDelete.GenreName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
