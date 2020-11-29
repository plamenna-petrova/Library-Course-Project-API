using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        ICollection<Publisher> GetPublishers();
        Publisher GetPublisherById(int publisherId);
        ICollection<Book> GetBooksOfAPublisher(int publisherId);
        ICollection<Publisher> GetPublishersByAuhtor(int authorId);
        ICollection<Author> GetAuthorsByPublisher(int publisherId);
        Country GetCountryOfAPublisher(int publisherId);
        bool PublisherExists(int oublisherId);
        bool CreatePublisher(Publisher publisher);
        bool UpdatePublisher(Publisher publisher);
        bool DeletePublisher(Publisher publisher);
        bool Save();
    }
}

