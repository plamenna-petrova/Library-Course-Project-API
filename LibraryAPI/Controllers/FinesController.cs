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
    public class FinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FineDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetFines()
        {
            var finesToGet = _unitOfWork.FineRepository.GetFines();

            return Ok(finesToGet);
        }

        [Route("api/fines/fineId")]
        [HttpGet("{fineId}", Name = "GetFineById")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetFineById(int fineId)
        {
            if (!_unitOfWork.FineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            var singleFine = _unitOfWork.FineRepository.GetFineById(fineId);

            return Ok(singleFine);
        }

        [Route("api/fines/librarians/fineId")]
        [HttpGet("librarians/{fineId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(LibrarianDto))]
        public IActionResult GetLibrarianWhoIssuedFine(int fineId)
        {
            if (!_unitOfWork.FineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            var librarian = _unitOfWork.FineRepository.GetLibrarianWhoIssuedFine(fineId);

            return Ok(librarian);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FineDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateFine([FromBody] FineCreateDto newFine)
        {
            if (newFine == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.FineRepository.FineExists(newFine.Id))
            {
                ModelState.AddModelError("", "Such fine Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.FineRepository.CreateFine(newFine))
            {
                ModelState.AddModelError("", $"Something went wrong saving the fine " + $"{newFine.FineFee}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetFineById", new { fineId = newFine.Id }, newFine);
        }

        [Route("api/fines/fineId")]
        [HttpPut("{fineId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateFine(int fineId, [FromBody] FineUpdateDto updatedFine)
        {
            if (updatedFine == null)
            {
                return BadRequest(ModelState);
            }

            if (fineId != updatedFine.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.FineRepository.FineExists(fineId))
            {
                ModelState.AddModelError("", "Fine doesn't exist!");
            }

            if (!_unitOfWork.FineRepository.UpdateFine(updatedFine))
            {
                ModelState.AddModelError("", $"Something went wrong updating the fine " + $"{updatedFine.FineFee}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/fines/fineId")]
        [HttpDelete("{fineId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteFine(int fineId)
        {
            if (!_unitOfWork.FineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            var fineToDelete = _unitOfWork.FineRepository.GetFineByIdNotMapped(fineId);

            if (!_unitOfWork.FineRepository.DeleteFine(fineToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{fineToDelete.FineFee}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }

    }
}
