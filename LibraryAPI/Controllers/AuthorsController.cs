﻿using System.Collections.Generic;
using AutoMapper;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthors()
        {
            var authorsToGet = _unitOfWork.AuthorRepository.GetAuthors();

            return Ok(authorsToGet);
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

            var singleAuthor = _unitOfWork.AuthorRepository.GetAuthorById(authorId);

            return Ok(singleAuthor);
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

            var authorsOfABook = _unitOfWork.AuthorRepository.GetAuthorsOfABook(bookId);

            return Ok(authorsOfABook);
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

            var booksByAuthor = _unitOfWork.AuthorRepository.GetBooksByAuthor(authorId);

            return Ok(booksByAuthor);
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

            var publishersByAuthor = _unitOfWork.AuthorRepository.GetPublishersByAuthor(authorId);

            return Ok(publishersByAuthor);
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

            var authorsByPublisher = _unitOfWork.AuthorRepository.GetAuthorsByPublisher(publisherId);

            return Ok(authorsByPublisher);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        //Author authorToCreate
        public IActionResult CreateAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            if (authorCreateDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.AuthorRepository.AuthorExistsByLastName(authorCreateDto.AuthorLastName))
            {
                ModelState.AddModelError("", "Such author Exists!");
                return StatusCode(404, ModelState);
            }

            var authorToCreate = _mapper.Map<Author>(authorCreateDto);

            if (!_unitOfWork.AuthorRepository.CreateAuthor(authorToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the author " + $"{authorToCreate.AuthorFirstName} {authorToCreate.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();
            
            return CreatedAtRoute("GetAuthorById", new { authorId = authorToCreate.Id }, authorCreateDto);
        }

        [Route("api/authors/authorId")]
        [HttpPut("{authorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        //Update Author (int authorId, [FromBody] Author authorToUpdate) - no automapper
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorUpdateDto authorUpdateDto)
        {
            if (authorUpdateDto == null)
            {
                return BadRequest(ModelState);
            }

            if (authorId != authorUpdateDto.Id)
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

            var authorToUpdate = _mapper.Map<Author>(authorUpdateDto);

            if (!_unitOfWork.AuthorRepository.UpdateAuthor(authorToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating the author " + $"{authorToUpdate.AuthorFirstName} {authorToUpdate.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

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

            //if (_unitOfWork.AuthorRepository.GetBooksByAuthor(authorId).Count() > 0)
            //{
            //    ModelState.AddModelError("", $"Author {authorToDelete.AuthorFirstName} {authorToDelete.AuthorLastName}" +
            //        "cannot be deleted because it is associated with at least one book");
            //    return StatusCode(409, ModelState);
            //}

            if (!_unitOfWork.AuthorRepository.DeleteAuthor(authorToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                    $"{authorToDelete.AuthorFirstName} {authorToDelete.AuthorLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
