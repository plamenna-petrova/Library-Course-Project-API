using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int countryId);
        Country GetCountryOfAnAuthor(int authorId);
        Country GetCountryOfAReviewer(int reviewerId);
        Country GetCountryOfAPublisher(int publisherId);
        ICollection<Author> GetAuthorsFromACountry(int countryId);
        ICollection<Reviewer> GetReviewersFromACountry(int countryId);
        ICollection<Publisher> GetPublishersFromACountry(int countryId);
        bool CountryExists(int countryId);
        bool IsDuplicateCountryName(int countryId, string countryName);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
