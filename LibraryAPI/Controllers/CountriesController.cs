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
    public class CountriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetCountries()
        {
            var countriesToGet = _unitOfWork.CountryRepository.GetCountries();

            return Ok(countriesToGet);
        }

        [Route("api/countries/countryId")]
        [HttpGet("{countryId}", Name = "GetCountryById")]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetCountryById(int countryId)
        {
            if (!_unitOfWork.CountryRepository.CountryExists(countryId))
            {
                return NotFound();
            }

            var singleCountry = _unitOfWork.CountryRepository.GetCountryById(countryId);

            return Ok(singleCountry);
        }

        [Route("api/countries/authors/authorId")]
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryOfAnAuthor(int authorId)
        {
            if (!_unitOfWork.AuthorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var country = _unitOfWork.CountryRepository.GetCountryOfAnAuthor(authorId);

            return Ok(country);
        }

        [Route("api/countries/countryId/authors")]
        [HttpGet("{countryId}/authors")]
        [ProducesResponseType(200, Type = typeof (IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorsFromACountry(int countryId)
        {
            if (!_unitOfWork.CountryRepository.CountryExists(countryId))
            {
                return NotFound();
            }

            var authors = _unitOfWork.CountryRepository.GetAuthorsFromACountry(countryId);

            return Ok(authors);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CountryDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult CreateCountry([FromBody] CountryCreateDto newCountry)
        {
            if (newCountry == null)
            {
                return BadRequest(ModelState);
            }

            if (_unitOfWork.CountryRepository.CountryExists(newCountry.Id))
            {
                ModelState.AddModelError("", "Such country Exists!");
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.CountryRepository.CreateCountry(newCountry))
            {
                ModelState.AddModelError("", $"Something went wrong saving the country " + $"{newCountry.CountryName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return CreatedAtRoute("GetCountryById", new { countryId = newCountry.Id }, newCountry);
        }

        [Route("api/countries/countryId")]
        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult UpdateCountry(int countryId, [FromBody] CountryUpdateDto updatedCountry)
        {
            if (updatedCountry == null)
            {
                return BadRequest(ModelState);
            }

            if (countryId != updatedCountry.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_unitOfWork.CountryRepository.CountryExists(countryId))
            {
                ModelState.AddModelError("", "Country doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(404, ModelState);
            }

            if (!_unitOfWork.CountryRepository.UpdateCountry(updatedCountry))
            {
                ModelState.AddModelError("", $"Something went wrong updating the country " + $"{updatedCountry.CountryName}");
            }

            _unitOfWork.Commit();

            return NoContent();
        }

        [Route("api/countries/countryId")]
        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_unitOfWork.CountryRepository.CountryExists(countryId))
            {
                return NotFound();
            }

            var countryToDelete = _unitOfWork.CountryRepository.GetCountryByIdNotMapped(countryId);

            if (!_unitOfWork.CountryRepository.DeleteCountry(countryToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " + $"{countryToDelete.CountryName}");
                return StatusCode(500, ModelState);
            }

            _unitOfWork.Commit();

            return NoContent();
        }
    }
   
}
