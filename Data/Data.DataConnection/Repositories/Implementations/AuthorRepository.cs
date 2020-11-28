using AutoMapper;
using Data.DataConnection.DtoModels.Dtos;
using Data.DataConnection.Repositories.Interfaces;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.DataConnection.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _authorContext;
        private readonly IMapper _mapper;
        public AuthorRepository(ApplicationDbContext authorContext)
        {
            _authorContext = authorContext;
        }

        public Author GetAuthorById(int authorId)
        {
            return _authorContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
            //var authorDto = new AuthorDto()
            //{
            //    Id = author.Id,
            //    AuthorFirstName = author.AuthorFirstName,
            //    AuthorLastName = author.AuthorLastName,
            //    AuthorBiography = author.AuthorBiography,
            //    CreatedAt = author.CreatedAt
            //};
            //return authorDto;
            //AutoMapper
        }

        public AuthorDto GetAuthorByIdMapped(int authorId)
        {
            var singleAuthor = _authorContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
            var mappedAuthor = _mapper.Map<AuthorDto>(singleAuthor);
            return mappedAuthor;
        }

        public ICollection<Author> GetAuthors()
        {
            return _authorContext.Authors.OrderBy(a => a.AuthorLastName).ToList();
        }

        public IQueryable<Author> GetAllAuthors(Func<Author, bool> func = null)
        {
            if (func == null)
            {
                return _authorContext.Authors.AsQueryable<Author>();
            }
            else
            {
                return _authorContext.Authors.Where(func).AsQueryable<Author>();
            }
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

        public bool AuthorExistsByLastName(string authorLastName)
        {
            bool value = _authorContext.Authors.Any(a => a.AuthorLastName.ToLower().Trim() == authorLastName.ToLower().Trim());
            return value;
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
