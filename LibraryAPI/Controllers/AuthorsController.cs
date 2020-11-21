using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataConnection.DtoModels.Dtos;
using Data.DataConnection.Repositories.Interfaces;
using Data.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("localhost:44332")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IPublisherRepository _publisherRepository;
        private ICountryRepository _countryRepository;
        public AuthorsController(IAuthorRepository authorRepository, IBookRepository bookRepository, ICountryRepository countryRepository, IPublisherRepository publisherRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _countryRepository = countryRepository;
            _publisherRepository = publisherRepository;
        }

        [Route("api/authors")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorsDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorLastName = author.AuthorLastName,
                    AuthorBiography = author.AuthorBiography,
                    CreatedAt = author.CreatedAt
                });
            }

            return Ok(authorsDto);
        }

        [Route("api/authors/authorId")]
        [HttpGet("{authorId}", Name = "GetAuthorById")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorById(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var author = _authorRepository.GetAuthorById(authorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorDto = new AuthorDto()
            {
                Id = author.Id,
                AuthorFirstName = author.AuthorFirstName,
                AuthorLastName = author.AuthorLastName,
                AuthorBiography = author.AuthorBiography,
                CreatedAt = author.CreatedAt
            };

            return Ok(authorDto);
        }

        [Route("api/authors/books/bookId")]
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsOfABook(int bookId)
        {
            if (!_bookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            var authors = _authorRepository.GetAuthorsOfABook(bookId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorsDto = new List<AuthorDto>();
            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorLastName = author.AuthorLastName,
                    AuthorBiography = author.AuthorBiography,
                    CreatedAt = author.CreatedAt
                });
            }

            return Ok(authorsDto);
        }

        [Route("api/authors/authorId/books")]
        [HttpGet("{authorId/books}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetBooksByAuthor(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var books = _authorRepository.GetBooksByAuthor(authorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booksDto = new List<BookDto>();

            foreach (var book in books)
            {
                booksDto.Add(new BookDto
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    BookTitle = book.BookTitle,
                    BookEdition = book.BookEdition,
                    DatePublished = book.DatePublished,
                    BookPages = book.BookPages,
                    BookAnnotation = book.BookAnnotation,
                    CreatedAt = book.CreatedAt
                });
            }

            return Ok(booksDto);
        }

        [Route("api/authors/publishers/publisherId")]
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsByPublisher(int publisherId)
        {
            if (!_publisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var authors = _authorRepository.GetAuthorsByPublisher(publisherId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorsDto = new List<AuthorDto>();
            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorLastName = author.AuthorLastName,
                    AuthorBiography = author.AuthorBiography,
                    CreatedAt = author.CreatedAt
                });
            }

            return Ok(authorsDto);
        }

        [Route("api/authors/authorId/publishers")]
        [HttpGet("{authorId/books}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PublisherDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetPublishersByAuthor(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var publishers = _authorRepository.GetPublishersByAuthor(authorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publishersDto = new List<PublisherDto>();

            foreach (var publisher in publishers)
            {
                publishersDto.Add(new PublisherDto
                {
                    Id = publisher.Id,
                    PublisherName = publisher.PublisherName
                });
            }

            return Ok(publishersDto);
        }

        [Route("api/authors")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Author))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult CreateAuthor([FromBody] Author authorToCreate)
        {
            if (authorToCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!_countryRepository.CountryExists(authorToCreate.Country.Id))
            {
                ModelState.AddModelError("", "Country doesn't exist!");
                return StatusCode(404, ModelState);
            }

            authorToCreate.Country = _countryRepository.GetCountryById(authorToCreate.Country.Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_authorRepository.CreateAuthor(authorToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the author " + $"{authorToCreate.AuthorFirstName} {authorToCreate.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAuthorById", new { authorId = authorToCreate.Id }, authorToCreate);
        }

        [Route("api/authors/authorId")]
        [HttpPut("{authorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateAuthor(int authorId, [FromBody] Author authorToUpdate)
        {
            if (authorToUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (authorId != authorToUpdate.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_authorRepository.AuthorExists(authorId))
            {
                ModelState.AddModelError("", "Author doesn't exist!");
            }

            if (!_countryRepository.CountryExists(authorToUpdate.Country.Id))
            {
                ModelState.AddModelError("", "Country doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            authorToUpdate.Country = _countryRepository.GetCountryById(authorToUpdate.Country.Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_authorRepository.UpdateAuthor(authorToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating the author " + $"{authorToUpdate.AuthorFirstName} {authorToUpdate.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [Route("api/authors/authorId")]
        [HttpDelete("{authorId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteAuthor(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var authorToDelete = _authorRepository.GetAuthorById(authorId);

            if (_authorRepository.GetBooksByAuthor(authorId).Count() > 0)
            {
                ModelState.AddModelError("", $"Author {authorToDelete.AuthorFirstName} {authorToDelete.AuthorLastName}" +
                    "cannot be deleted because it is associated with at least one book");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_authorRepository.DeleteAuthor(authorToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                    $"{authorToDelete.AuthorFirstName} {authorToDelete.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
