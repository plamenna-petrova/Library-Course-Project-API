using Data.DataConnection;
using Data.Models.Models;
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

        public ICollection<Publisher> GetPublishers()
        {
            return _publisherContext.Publishers.OrderBy(p => p.PublisherName).ToList();
        }

        public Publisher GetPublisherById(int publisherId)
        {
            return _publisherContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
        }

        public ICollection<Book> GetBooksOfAPublisher(int publisherId)
        {
            return _publisherContext.Books.Where(p => p.Publisher.Id == publisherId).ToList();
        }

        public ICollection<Publisher> GetPublishersByAuhtor(int authorId)
        {
            return _publisherContext.AuthorsPublishers.Where(a => a.AuthorId == authorId).Select(p => p.Publisher).ToList();
        }

        public ICollection<Author> GetAuthorsByPublisher(int publisherId)
        {
            return _publisherContext.AuthorsPublishers.Where(p => p.PublisherId == publisherId).Select(a => a.Author).ToList();
        }

        public Country GetCountryOfAPublisher(int publisherId)
        {
            return _publisherContext.Publishers.Where(p => p.Id == publisherId).Select(c => c.Country).FirstOrDefault();
        }

        public bool PublisherExists(int publisherId)
        {
            return _publisherContext.Publishers.Any(p => p.Id == publisherId);
        }

        public bool CreatePublisher(Publisher publisher)
        {
            _publisherContext.Add(publisher);
            return Save();
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            _publisherContext.Update(publisher);
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
