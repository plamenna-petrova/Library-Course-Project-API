using Data.DataConnection.Repositories.Interfaces;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataConnection.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _authorContext;

        public AuthorRepository(ApplicationDbContext authorContext)
        {
            _authorContext = authorContext;
        }

        public Author GetAuthorById(int authorId)
        {
            return _authorContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _authorContext.Authors.OrderBy(a => a.AuthorLastName).ToList();
        }

        public ICollection<Author> GetAuthorsOfABook(int bookId)
        {
            return _authorContext.BooksAuthors.Where(b => b.BookId == bookId).Select(a => a.Author).ToList();
        }

        public ICollection<Book> GetBooksByAuthor(int authorId)
        {
            return _authorContext.BooksAuthors.Where(a => a.AuthorId == authorId).Select(b => b.Book).ToList();
        }
        public ICollection<Publisher> GetPublishersByAuthor(int authorId)
        {
            return _authorContext.AuthorsPublishers.Where(a => a.AuthorId == authorId).Select(p => p.Publisher).ToList();
        }

        public ICollection<Author> GetAuthorsByPublisher(int publisherId)
        {
            return _authorContext.AuthorsPublishers.Where(p => p.PublisherId == publisherId).Select(a => a.Author).ToList();
        }

        public Country GetCountryOfAnAuthor(int authorId)
        {
            return _authorContext.Authors.Where(a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
        }

        public bool AuthorExists(int authorId)
        {
            return _authorContext.Authors.Any(a => a.Id == authorId);
        }

        public bool CreateAuthor(Author author)
        {
            _authorContext.Add(author);
            return Save();
        }

        public bool UpdateAuthor(Author author)
        {
            _authorContext.Update(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _authorContext.Remove(author);
            return Save();
        }

        public bool Save()
        {
            var saved = _authorContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

    }
}
