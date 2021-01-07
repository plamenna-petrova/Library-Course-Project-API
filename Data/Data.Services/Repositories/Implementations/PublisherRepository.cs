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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _publisherContext;

        public PublisherRepository(ApplicationDbContext publisherContext)
        {
            _publisherContext = publisherContext;
        }

        public ICollection<PublisherDto> GetPublishers()
        {
            var publishers = _publisherContext.Publishers.OrderBy(p => p.PublisherName).ToList();
            var mappedPublishers = MapConfig.Mapper.Map<ICollection<PublisherDto>>(publishers);
            return mappedPublishers;
        }

        public PublisherDto GetPublisherById(int publisherId)
        {
            var singlePublisher = _publisherContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
            var mappedPublisher = MapConfig.Mapper.Map<PublisherDto>(singlePublisher);
            return mappedPublisher;
        }

        public Publisher GetPublisherByIdNotMapped(int publisherId) 
        {
            var publisher = _publisherContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
            return publisher;
        }

        public ICollection<BookDto> GetBooksOfAPublisher(int publisherId)
        {
            var booksOfAPublisher = _publisherContext.Books.Where(p => p.Publisher.Id == publisherId).ToList();
            var booksOfAPublisherMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksOfAPublisher);
            return booksOfAPublisherMapped;
        }

        public ICollection<PublisherDto> GetPublishersByAuthor(int authorId)
        {
            var publishersByAuthor = _publisherContext.AuthorsPublishers.Where(a => a.AuthorId == authorId).Select(p => p.Publisher).ToList();
            var publishersByAuthorMapped = MapConfig.Mapper.Map<ICollection<PublisherDto>>(publishersByAuthor);
            return publishersByAuthorMapped;
        }

        public ICollection<AuthorDto> GetAuthorsByPublisher(int publisherId)
        {
            var authorsByPublisher = _publisherContext.AuthorsPublishers.Where(p => p.PublisherId == publisherId).Select(a => a.Author).ToList();
            var authorsByPublisherMapped = MapConfig.Mapper.Map<ICollection<AuthorDto>>(authorsByPublisher);
            return authorsByPublisherMapped;
        }

        public CountryDto GetCountryOfAPublisher(int publisherId)
        {
            var countryOfAPublisher = _publisherContext.Publishers.Where(p => p.Id == publisherId).Select(c => c.Country).FirstOrDefault();
            var countryOfAPublisherMapped = MapConfig.Mapper.Map<CountryDto>(countryOfAPublisher);
            return countryOfAPublisherMapped;
        }

        public bool PublisherExists(int publisherId)
        {
            return _publisherContext.Publishers.Any(p => p.Id == publisherId);
        }

        public bool CreatePublisher(PublisherCreateDto publisherToCreateDto)
        {
            var publisherToCreate = MapConfig.Mapper.Map<Publisher>(publisherToCreateDto);
            _publisherContext.Add(publisherToCreate);
            return Save();
        }

        public bool UpdatePublisher(PublisherUpdateDto publisherToUpdateDto)
        {
            var publisherToUpdate = MapConfig.Mapper.Map<Publisher>(publisherToUpdateDto);
            _publisherContext.Update(publisherToUpdate);
            return Save();
        }

        public bool DeletePublisher(Publisher publisher)
        {
            _publisherContext.Remove(publisher);
            return Save();
        }

        public bool Save()
        {
            var saved = _publisherContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
