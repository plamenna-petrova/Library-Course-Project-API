﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthors()
        {
            var authors = _unitOfWork.AuthorRepository.GetAuthors();

            var authorsDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorLastName = author.AuthorLastName,
                    AuthorBiography = author.AuthorBiography,
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
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var author = _unitOfWork.AuthorRepository.GetAuthorById(authorId);

            var authorDto = new AuthorDto()
            {
                Id = author.Id,
                AuthorFirstName = author.AuthorFirstName,
                AuthorLastName = author.AuthorLastName,
                AuthorBiography = author.AuthorBiography,
            };

            //use AutoMapper

            return Ok(authorDto);
        }

        [Route("api/authors/books/bookId")]
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsOfABook(int bookId)
        {
            if (!_unitOfWork.BookRepository.BookExistsById(bookId))
            {
                return NotFound();
            }

            //Response - Headers, etc... - to do

            var authors = _unitOfWork.AuthorRepository.GetAuthorsOfABook(bookId);

            var authorsDto = new List<AuthorDto>();
            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorLastName = author.AuthorLastName,
                    AuthorBiography = author.AuthorBiography,
                });
            }

            return Ok(authorsDto);
        }

        [Route("api/authors/authorId/books")]
        [HttpGet("{authorId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetBooksByAuthor(int authorId)
        {
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var books = _unitOfWork.AuthorRepository.GetBooksByAuthor(authorId);

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
                });
            }

            return Ok(booksDto);
        }

        [Route("api/authors/publishers/publisherId")]
        [HttpGet("publishers/{publisherId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsByPublisher(int publisherId)
        {
            if (!_unitOfWork.PublisherRepository.PublisherExists(publisherId))
            {
                return NotFound();
            }

            var authors = _unitOfWork.AuthorRepository.GetAuthorsByPublisher(publisherId);

            var authorsDto = new List<AuthorDto>();
            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorLastName = author.AuthorLastName,
                    AuthorBiography = author.AuthorBiography,
                });
            }

            return Ok(authorsDto);
        }

        [Route("api/authors/authorId/publishers")]
        [HttpGet("{authorId}/publishers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PublisherDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetPublishersByAuthor(int authorId)
        {
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var publishers = _unitOfWork.AuthorRepository.GetPublishersByAuthor(authorId);

            var publishersDto = new List<PublisherDto>();

            foreach (var publisher in publishers)
            {
                publishersDto.Add(new PublisherDto
                {
                    Id = publisher.Id,
                    PublisherName = publisher.PublisherName,
                });
            }

            return Ok(publishersDto);
        }

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

            if (!_unitOfWork.AuthorRepository.CreateAuthor(authorToCreate))
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

            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                ModelState.AddModelError("", "Author doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.AuthorRepository.UpdateAuthor(authorToUpdate))
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
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var authorToDelete = _unitOfWork.AuthorRepository.GetAuthorById(authorId);

            if (_unitOfWork.AuthorRepository.GetBooksByAuthor(authorId).Count() > 0)
            {
                ModelState.AddModelError("", $"Author {authorToDelete.AuthorFirstName} {authorToDelete.AuthorLastName}" +
                    "cannot be deleted because it is associated with at least one book");
                return StatusCode(409, ModelState);
            }

            if (!_unitOfWork.AuthorRepository.DeleteAuthor(authorToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                    $"{authorToDelete.AuthorFirstName} {authorToDelete.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
