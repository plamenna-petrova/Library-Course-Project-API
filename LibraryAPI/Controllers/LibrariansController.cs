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
    public class LibrariansController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibrariansController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LibrarianDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetLibrarians()
        {
            var librariansToGet = _unitOfWork.LibrarianRepository.GetLibrarians();

            return Ok(librariansToGet);
        }

        [Route("api/librarians/librarianId")]
        [HttpGet("{librarianId}", Name = "GetLibrarianById")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLibrarianById(int librarianId)
        {
            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                return NotFound();
            }

            var singleLibrarian = _unitOfWork.LibrarianRepository.GetLibrarianById(librarianId);

            return Ok(singleLibrarian);
        }

        [Route("api/librarians/books/bookId")]
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LibrarianDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLibrariansOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var librariansOfABook = _unitOfWork.LibrarianRepository.GetLibrariansOfABook(bookId);

            return Ok(librariansOfABook);
        }

        [Route("api/librarians/librarianId/books")]
        [HttpGet("{librarianId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksOfALibrarian(int librarianId)
        {
            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                return NotFound();
            }

            var booksOfALibrarian = _unitOfWork.LibrarianRepository.GetBooksOfALibrarian(librarianId);

            return Ok(booksOfALibrarian);
        }

        [Route("api/librarians/librarianId/fines")]
        [HttpGet("{librarianId}/fines")]
        [ProducesResponseType(200, Type = typeof (IEnumerable<FineDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetFinesOfALibrarian(int librarianId)
        {
            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                return NotFound();
            }

            var fines = _unitOfWork.LibrarianRepository.GetFinesOfALibrarian(librarianId);

            return Ok(fines);
        }

        [Route("api/librarians/librarymanagingdirectors/librarianId")]
        [HttpGet("librarymanagingdirectors/{librarianId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(LibraryManagingDirectorDto))]
        public IActionResult GetLibraryManagingDirectorOfLibrarian(int librarianId)
        {
            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                return NotFound();
            }

            var libraryManagingDirector = _unitOfWork.LibrarianRepository.GetLibraryManagingDirectorOfLibrarian(librarianId);

            return Ok(libraryManagingDirector);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LibrarianDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateLibrarian([FromBody] LibrarianCreateDto newLibrarian)
        {
            if (newLibrarian == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.LibrarianRepository.LibrarianExists(newLibrarian.Id))
            {
                ModelState.AddModelError("", "Such librarian Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.LibrarianRepository.CreateLibrarian(newLibrarian)){
                ModelState.AddModelError("", $"Something went wrong saving the librarian " + $"{newLibrarian.LibrarianFirstName}{newLibrarian.LibrarianLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetLibrarianById", new { librarianId = newLibrarian.Id }, newLibrarian);
        }

        [Route("api/librarians/librarianId")]
        [HttpPut("{librarianId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateLibrarian(int librarianId, [FromBody] LibrarianUpdateDto updatedLibrarian)
        {
            if (updatedLibrarian == null)
            {
                return BadRequest(ModelState);
            }

            if (librarianId != updatedLibrarian.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                ModelState.AddModelError("", "Librarian doesn't exist!");
            }

            if (!_unitOfWork.LibrarianRepository.UpdateLibrarian(updatedLibrarian))
            {
                ModelState.AddModelError("", $"Something went wrong updating the librarian " + $"{updatedLibrarian.LibrarianFirstName}{updatedLibrarian.LibrarianLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/librarians/librarianId")]
        [HttpDelete("{librarianId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteLibrarian(int librarianId)
        {
            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                return NotFound();
            }

            var librarianToDelete = _unitOfWork.LibrarianRepository.GetLibrarianByIdNotMapped(librarianId);

            if (!_unitOfWork.LibrarianRepository.DeleteLibrarian(librarianToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{librarianToDelete.LibrarianFirstName}{librarianToDelete.LibrarianLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
