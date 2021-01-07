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
    public class ReadersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReadersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReaderDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReaders()
        {
            var readersToGet = _unitOfWork.ReaderRepository.GetReaders();

            return Ok(readersToGet);
        }

        [Route("api/readers/readerId")]
        [HttpGet("{readerId}", Name = "GetReaderById")]
        [ProducesResponseType(200, Type = typeof(ReaderDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetReaderById(int readerId)
        {
            if (!_unitOfWork.ReaderRepository.ReaderExists(readerId))
            {
                return NotFound();
            }

            var singleReader = _unitOfWork.ReaderRepository.GetReaderById(readerId);

            return Ok(singleReader);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReaderDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateReader([FromBody] ReaderCreateDto newReader)
        {
            if (newReader == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.ReaderRepository.ReaderExists(newReader.Id))
            {
                ModelState.AddModelError("", "Such reader Exists");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.ReaderRepository.CreateReader(newReader))
            {
                ModelState.AddModelError("", $"Something went wrong saving the reader " + $"{newReader.ReaderFirstName}{newReader.ReaderLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetReaderById", new { readerId = newReader.Id }, newReader);
        }

        [Route("api/readers/readerId")]
        [HttpPut("{readerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateReader(int readerId, [FromBody] ReaderUpdateDto updatedReader)
        {
            if (updatedReader == null)
            {
                return BadRequest(ModelState);
            }

            if (readerId != updatedReader.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.ReaderRepository.ReaderExists(readerId))
            {
                ModelState.AddModelError("", "Reader doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.ReaderRepository.UpdateReader(updatedReader))
            {
                ModelState.AddModelError("", $"Something went wrong updating the reader " + $"{updatedReader.ReaderFirstName}{updatedReader.ReaderLastName}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/readers/readerId")]
        [HttpDelete("{readerId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteReader(int readerId)
        {
            if (!_unitOfWork.ReaderRepository.ReaderExists(readerId))
            {
                return NoContent();
            }

            var readerToDelete = _unitOfWork.ReaderRepository.GetReaderByIdNotMapped(readerId);

            if (!_unitOfWork.ReaderRepository.DeleteReader(readerToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{readerToDelete.ReaderFirstName}{readerToDelete.ReaderLastName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
