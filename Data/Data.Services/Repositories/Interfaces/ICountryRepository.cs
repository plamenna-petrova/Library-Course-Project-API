﻿using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<CountryDto> GetCountries();
        CountryDto GetCountryById(int countryId);
        Country GetCountryByIdNotMapped(int countryId);
        CountryDto GetCountryOfAnAuthor(int authorId);
        CountryDto GetCountryOfAReviewer(int reviewerId);
        CountryDto GetCountryOfAPublisher(int publisherId);
        ICollection<AuthorDto> GetAuthorsFromACountry(int countryId);
        ICollection<ReviewerDto> GetReviewersFromACountry(int countryId);
        ICollection<PublisherDto> GetPublishersFromACountry(int countryId);
        bool CountryExists(int countryId);
        bool IsDuplicateCountryName(int countryId, string countryName);
        bool CreateCountry(CountryCreateDto countryToCreateDto);
        bool UpdateCountry(CountryUpdateDto countryToUpdateDto);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
