using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        ICollection<PublisherDto> GetPublishers();
        PublisherDto GetPublisherById(int publisherId);
        Publisher GetPublisherByIdNotMapped(int publisherId);
        ICollection<BookDto> GetBooksOfAPublisher(int publisherId);
        ICollection<PublisherDto> GetPublishersByAuthor(int authorId);
        ICollection<AuthorDto> GetAuthorsByPublisher(int publisherId);
        CountryDto GetCountryOfAPublisher(int publisherId);
        bool PublisherExists(int oublisherId);
        bool CreatePublisher(PublisherCreateDto publisherToCreateDto);
        bool UpdatePublisher(PublisherUpdateDto publisherToUpdateDto);
        bool DeletePublisher(Publisher publisher);
        bool Save();
    }
}
