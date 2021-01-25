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
    public class LoansController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoansController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LoanDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetLoans()
        {
            var loansToGet = _unitOfWork.LoanRepository.GetLoans();

            return Ok(loansToGet);
        }

        [Route("api/loans/loanId")]
        [HttpGet("{loanId}", Name = "GetLoanById")]
        [ProducesResponseType(200, Type = typeof(LoanDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetLoanById(int loanId)
        {
            if (!_unitOfWork.LoanRepository.LoanExists(loanId))
            {
                return NotFound();
            }

            var singleLoan = _unitOfWork.LoanRepository.GetLoanById(loanId);

            return Ok(singleLoan);
        }

        [Route("api/loans/books/loanId")]
        [HttpGet("books/{loanId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBookOfALoan(int loanId)
        {
            if (!_unitOfWork.LoanRepository.LoanExists(loanId))
            {
                return NotFound();
            }

            var bookOfALoan = _unitOfWork.LoanRepository.GetBookOfALoan(loanId);

            return Ok(bookOfALoan);
        }

        [Route("api/loans/librarians/loanId")]
        [HttpGet("librarians/{loanId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(LibrarianDto))]
        public IActionResult GetLibrarianWhoProcessedLoan(int loanId)
        {
            if (!_unitOfWork.LoanRepository.LoanExists(loanId))
            {
                return NotFound();
            }

            var librarianWhoProcessedLoan = _unitOfWork.LoanRepository.GetLibrarianWhoProcessedLoan(loanId);

            return Ok(librarianWhoProcessedLoan);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LoanDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateLoan([FromBody] LoanCreateDto newLoan)
        {
            if (newLoan == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.LoanRepository.LoanExists(newLoan.Id))
            {
                ModelState.AddModelError("", "Such loan Exists");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.LoanRepository.CreateLoan(newLoan))
            {
                ModelState.AddModelError("", $"Something went wrong saving the loan " + $"{newLoan.IssueDate}{newLoan.DateToReturn}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetLoanById", new { loanId = newLoan.Id }, newLoan);
        }

        [Route("api/loans/loanId")]
        [HttpPut("{loanId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateLoan(int loanId, [FromBody] LoanUpdateDto updatedLoan)
        {
            if (updatedLoan == null)
            {
                return BadRequest(ModelState);
            }

            if (loanId != updatedLoan.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.LoanRepository.LoanExists(loanId))
            {
                ModelState.AddModelError("", "Loan doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.LoanRepository.UpdateLoan(updatedLoan))
            {
                ModelState.AddModelError("", $"Something went wrong updating the loan " + $"{updatedLoan.IssueDate}{updatedLoan.DateToReturn}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/loans/loanId")]
        [HttpDelete("{loanId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteLoan(int loanId)
        {
            if (!_unitOfWork.LoanRepository.LoanExists(loanId))
            {
                return NotFound();
            }

            var loanToDelete = _unitOfWork.LoanRepository.GetLoanByIdNotMapped(loanId);

            if (!_unitOfWork.LoanRepository.DeleteLoan(loanToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{loanToDelete.IssueDate}{loanToDelete.DateToReturn}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
