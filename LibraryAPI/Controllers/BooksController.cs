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
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooks()
        {
            var booksToGet = _unitOfWork.BookRepository.GetBooks();

            return Ok(booksToGet);
        }

        [Route("api/books/bookId")]
        [HttpGet("{bookId}", Name = "GetBookById")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBookById(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                 NotFound();
            }

            var singleBook = _unitOfWork.BookRepository.GetBookById(bookId);

            return Ok(singleBook);
        }

        [Route("api/books/isbn/bookISBN")]
        [HttpGet("isbn/{bookISBN}")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBookByISBN(string bookISBN)
        {
            if (!_unitOfWork.BookRepository.BookExistsByISBN(bookISBN))
            {
                NotFound();
            }

            var bookByISBN = _unitOfWork.BookRepository.GetBookByISBN(bookISBN);

            return Ok(bookByISBN);
        }

        [Route("api/books/authors/bookId")]
        [HttpGet("authors/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var authorsOfABook = _unitOfWork.BookRepository.GetAuthorsOfABook(bookId);

            return Ok(authorsOfABook);
        }

        [Route("api/books/genres/bookId")]
        [HttpGet("genres/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GenreDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAllGenresForABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var genresForABook = _unitOfWork.BookRepository.GetAllGenresForABook(bookId);

            return Ok(genresForABook);
        }

        [Route("api/books/librarians/bookId")]
        [HttpGet("librarians/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LibrarianDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLibrariansOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var librariansOfABook = _unitOfWork.BookRepository.GetLibrariansOfABook(bookId);

            return Ok(librariansOfABook);
        }

        [Route("api/books/readers/bookId")]
        [HttpGet("readers/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReaderDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReadersOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var readersOfABook = _unitOfWork.BookRepository.GetReadersOfABook(bookId);

            return Ok(readersOfABook);
        }

        [Route("api/books/reviewers/bookId")]
        [HttpGet("reviewers/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReviewersOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var reviewersOfABook = _unitOfWork.BookRepository.GetReviewersOfABook(bookId);

            return Ok(reviewersOfABook);
        }

        [Route("api/books/authorId/authors")]
        [HttpGet("{authorId}/authors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksByAuthor(int authorId)
        {
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var booksByAuthor = _unitOfWork.BookRepository.GetBooksByAuthor(authorId);

            return Ok(booksByAuthor);
        }

        [Route("api/books/genreId/genres")]
        [HttpGet("{genreId}/genres")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAllBooksForGenre(int genreId)
        {
            if (!_unitOfWork.GenreRepository.GenreExists(genreId))
            {
                return NotFound();
            }

            var booksForGenre = _unitOfWork.BookRepository.GetAllBooksForGenre(genreId);

            return Ok(booksForGenre);
        }

        [Route("api/books/librarianId/librarians")]
        [HttpGet("{librarianId}/librarians")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksOfALibrarian(int librarianId)
        {
            if (!_unitOfWork.LibrarianRepository.LibrarianExists(librarianId))
            {
                return NotFound();
            }

            var booksOfALibrarian = _unitOfWork.BookRepository.GetBooksOfALibrarian(librarianId);

            return Ok(booksOfALibrarian);
        }

        [Route("api/books/readerId/readers")]
        [HttpGet("{readerId}/readers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksOfAReader(int readerId)
        {
            if (!_unitOfWork.ReaderRepository.ReaderExists(readerId))
            {
                return NotFound();
            }

            var booksOfAReader = _unitOfWork.BookRepository.GetBooksOfAReader(readerId);

            return Ok(booksOfAReader);
        }

        [Route("api/books/reviewerId/reviewers")]
        [HttpGet("{reviewerId}/reviewers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBooksOfAReviewer(int reviewerId)
        {
            if (!_unitOfWork.ReviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var booksOfAReviewer = _unitOfWork.BookRepository.GetBooksOfAReviewer(reviewerId);

            return Ok(booksOfAReviewer);
        }

        [Route("api/books/publishers/bookId")]
        [HttpGet("publishers/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(PublisherDto))]
        public IActionResult GetPublisherOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var publisher = _unitOfWork.BookRepository.GetPublisherOfABook(bookId);

            return Ok(publisher);
        }

        [Route("api/books/bookId/loans")]
        [HttpGet("{bookId}/loans")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LoanDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLoansOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var loans = _unitOfWork.BookRepository.GetLoansOfABook(bookId);

            return Ok(loans);
        }

        [Route("api/books/bookimages/bookId")]
        [HttpGet("bookimages/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookImageDto))]
        public IActionResult GetImageOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var bookImage = _unitOfWork.BookRepository.GetImageOfABook(bookId);

            return Ok(bookImage);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult CreateBook([FromBody] BookCreateDto newBook)
        {
            if (newBook == null)
            {
                 BadRequest(ModelState);
            }

            if (_unitOfWork.BookRepository.BookExistsById(newBook.Id))
            {
                ModelState.AddModelError("", "Such book Exists!");
                 StatusCode(404, ModelState);
            }

            if (!_unitOfWork.BookRepository.CreateBook(newBook))
            {
                ModelState.AddModelError("", $"Something went wrong saving the book " + $"{newBook.BookTitle}");
                 StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

             return CreatedAtRoute("GetBookById", new { bookId = newBook.Id }, newBook);
        }


        [Route("api/books/bookId")]
        [HttpPut("{bookId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult UpdateBook(int bookId, [FromBody] BookUpdateDto updatedBook)
        {
            if (updatedBook == null)
            {
                 BadRequest(ModelState);
            }

            if (bookId != updatedBook.Id)
            {
                 BadRequest(ModelState);
            }

            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                ModelState.AddModelError("", "Book doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                 StatusCode(404, ModelState);
            }

            if (!_unitOfWork.BookRepository.UpdateBook(updatedBook))
            {
                ModelState.AddModelError("", $"Something went wrong updating the book " + $"{updatedBook.BookTitle} ");
                 StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

             return NoContent();
        }

        [Route("api/books/bookId")]
        [HttpDelete("{bookId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteBook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                 NotFound();
            }

            var bookToDelete = _unitOfWork.BookRepository.GetBookByIdNotMapped(bookId);

            if (!_unitOfWork.BookRepository.DeleteBook(bookToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                    $"{bookToDelete.BookTitle}");
                 StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

             return NoContent();
        }
    }
}
