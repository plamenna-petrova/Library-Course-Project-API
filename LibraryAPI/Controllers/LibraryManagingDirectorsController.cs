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
    public class LibraryManagingDirectorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryManagingDirectorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LibraryManagingDirectorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetLibraryManagingDirectors()
        {
            var libraryManagingDirectorsToGet = _unitOfWork.LibraryManagingDirectorRepository.GetLibraryManagingDirectors();

            return Ok(libraryManagingDirectorsToGet);
        }

        [Route("api/librarymanagingdirectors/libraryManagingDirectorId")]
        [HttpGet("{libraryManagingDirectorId}", Name = "GetLibraryManagingDirectorById")]
        [ProducesResponseType(200, Type = typeof(LibraryManagingDirectorDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLibraryManagingDirectorById(int libraryManagingDirectorId)
        {
            if (!_unitOfWork.LibraryManagingDirectorRepository.LibraryManagingDirectorExists(libraryManagingDirectorId))
            {
                return NotFound();
            }

            var singleLibraryManagingDirector = _unitOfWork.LibraryManagingDirectorRepository.GetLibraryManagingDirectorById(libraryManagingDirectorId);

            return Ok(singleLibraryManagingDirector);
        }

        [Route("api/librarymanagingdirectors/libraryManagingDirectorId/librarians")]
        [HttpGet("{libraryManagingDirectorId}/librarians")]
        [ProducesResponseType(200, Type = typeof (IEnumerable<LibrarianDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLibrariansOfALibraryManagingDirector(int libraryManagingDirectorId)
        {
            if (!_unitOfWork.LibraryManagingDirectorRepository.LibraryManagingDirectorExists(libraryManagingDirectorId))
            {
                return NotFound();
            }

            var librarians = _unitOfWork.LibraryManagingDirectorRepository.GetLibrariansOfALibraryManagingDirector(libraryManagingDirectorId);

            return Ok(librarians);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LibraryManagingDirectorDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateLibraryManagingDirector([FromBody] LibraryManagingDirectorCreateDto newLibraryManagingDirector)
        {
            if (newLibraryManagingDirector == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.LibraryManagingDirectorRepository.LibraryManagingDirectorExists(newLibraryManagingDirector.Id))
            {
                ModelState.AddModelError("", "Such library managing director Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.LibraryManagingDirectorRepository.CreateLibraryManagingDirector(newLibraryManagingDirector))
            {
                ModelState.AddModelError("", $"Something went wrong saving the library managing director " + $"{newLibraryManagingDirector.LibraryManagingDirectorFirstName}{newLibraryManagingDirector.LibraryManagingDirectorLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetLibraryManagingDirectorById", new { libraryManagingDirectorId = newLibraryManagingDirector.Id }, newLibraryManagingDirector);
        }

        [Route("api/librarymanagingdirectors/libraryManagingDirectorId")]
        [HttpPut("{libraryManagingDirectorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateLibraryManagingDirector(int libraryManagingDirectorId, [FromBody] LibraryManagingDirectorUpdateDto updatedLibraryManagingDirector)
        {
            if (updatedLibraryManagingDirector == null)
            {
                return BadRequest(ModelState);
            }

            if (libraryManagingDirectorId != updatedLibraryManagingDirector.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.LibraryManagingDirectorRepository.LibraryManagingDirectorExists(libraryManagingDirectorId))
            {
                ModelState.AddModelError("", "Library managing director doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.LibraryManagingDirectorRepository.UpdateLibraryManagingDirector(updatedLibraryManagingDirector))
            {
                ModelState.AddModelError("", $"Something went wrong updating the library managing director " + $"{updatedLibraryManagingDirector.LibraryManagingDirectorFirstName}{updatedLibraryManagingDirector.LibraryManagingDirectorLastName}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/librarymanagingdirectors/libraryManagingDirectorId")]
        [HttpDelete("{libraryManagingDirectorId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteLibraryManagingDirector(int libraryManagingDirectorId)
        {
            if (!_unitOfWork.LibraryManagingDirectorRepository.LibraryManagingDirectorExists(libraryManagingDirectorId))
            {
                return NotFound();
            }

            var libraryManagingDirectorToDelete = _unitOfWork.LibraryManagingDirectorRepository.GetLibraryManagingDirectorByIdNotMapped(libraryManagingDirectorId);

            if (!_unitOfWork.LibraryManagingDirectorRepository.DeleteLibraryManagingDirector(libraryManagingDirectorToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{libraryManagingDirectorToDelete.LibraryManagingDirectorFirstName}{libraryManagingDirectorToDelete.LibraryManagingDirectorLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
