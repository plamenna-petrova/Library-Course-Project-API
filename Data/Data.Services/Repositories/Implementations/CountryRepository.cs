using Data.DataConnection;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Helpers;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _countryContext;

        public CountryRepository(ApplicationDbContext countryRepository)
        {
            _countryContext = countryRepository;
        }

        public ICollection<CountryDto> GetCountries()
        {
            var countries = _countryContext.Countries.OrderBy(c => c.CountryName).ToList();
            var mappedCountries = MapConfig.Mapper.Map<ICollection<CountryDto>>(countries);
            return mappedCountries;
        }

        public CountryDto GetCountryById(int countryId)
        {
            var singleCountry = _countryContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();
            var mappedCountry = MapConfig.Mapper.Map<CountryDto>(singleCountry);
            return mappedCountry;
        }

        public Country GetCountryByIdNotMapped(int countryId)
        {
            return _countryContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryOfAnAuthor(int authorId)
        {
            return _countryContext.Authors.Where(a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
        }

        public Country GetCountryOfAReviewer(int reviewerId)
        {
            return _countryContext.Reviewers.Where(rev => rev.Id == reviewerId).Select(c => c.Country).FirstOrDefault();
        }

        public Country GetCountryOfAPublisher(int publisherId)
        {
            return _countryContext.Publishers.Where(p => p.Id == publisherId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Author> GetAuthorsFromACountry(int countryId)
        {
            return _countryContext.Authors.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Reviewer> GetReviewersFromACountry(int countryId)
        {
            return _countryContext.Reviewers.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Publisher> GetPublishersFromACountry(int countryId)
        {
            return _countryContext.Publishers.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool CountryExists(int countryId)
        {
            return _countryContext.Countries.Any(c => c.Id == countryId);
        }

        public bool IsDuplicateCountryName(int countryId, string countryName)
        {
            var country = _countryContext.Countries.Where(c => c.CountryName.Trim().ToUpper() == countryName.Trim().ToUpper() && c.Id != countryId).FirstOrDefault();

            return country == null ? false : true;
        }

        public bool CreateCountry(CountryCreateDto countryToCreateDto)
        {
            var countryToCreate = MapConfig.Mapper.Map<Country>(countryToCreateDto);
            _countryContext.Add(countryToCreate);
            return Save();
        }

        public bool UpdateCountry(CountryUpdateDto countryToUpdateDto)
        {
            var countryToUpdate = MapConfig.Mapper.Map<Country>(countryToUpdateDto);
            _countryContext.Update(countryToUpdate);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _countryContext.Remove(country);
            return Save();
        }

        public bool Save()
        {
            var saved = _countryContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
