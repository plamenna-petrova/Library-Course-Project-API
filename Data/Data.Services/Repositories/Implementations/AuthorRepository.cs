using Data.DataConnection;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Helpers;
using Data.Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _authorContext;
        public AuthorRepository(ApplicationDbContext authorContext)
        {
            _authorContext = authorContext;
        }

        public AuthorDto GetAuthorById(int authorId)
        {
            var singleAuthor = _authorContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
            var mappedAuthor = MapConfig.Mapper.Map<AuthorDto>(singleAuthor);
            return mappedAuthor;
        }

        public Author GetAuthorByIdNotMapped(int authorId)
        {
            var author = _authorContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
            return author;
        }

        public ICollection<AuthorDto> GetAuthors()
        {
            var authors = _authorContext.Authors.OrderBy(a => a.AuthorLastName).ToList();
            var mappedAuthors =  MapConfig.Mapper.Map<ICollection<AuthorDto>>(authors);
            return mappedAuthors;
        }

        //public IQueryable<AuthorDto> GetAuthors(Func<Author, bool> func = null)
        //{
        //    var mappedFunc = MapConfig.Mapper.Map<IQueryable<AuthorDto>>(func);
        //    if (mappedFunc == null)
        //    {
        //        return _authorContext.Authors.AsQueryable<AuthorDto>();
        //    }
        //    else
        //    {
        //        return _authorContext.Authors.Where(mappedFunc).AsQueryable<AuthorDto>();
        //    }
        //}

        public ICollection<AuthorDto> GetAuthorsOfABook(int bookId)
        {
            var authorsOfABook = _authorContext.BooksAuthors.Where(b => b.BookId == bookId).Select(a => a.Author).ToList();
            var authorsOfABookMapped = MapConfig.Mapper.Map<ICollection<AuthorDto>>(authorsOfABook);
            return authorsOfABookMapped;
        }

        public ICollection<BookDto> GetBooksByAuthor(int authorId)
        {
            var booksByAuthor =  _authorContext.BooksAuthors.Where(a => a.AuthorId == authorId).Select(b => b.Book).ToList();
            var booksByAuthorMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksByAuthor);
            return booksByAuthorMapped;
        }

        public ICollection<PublisherDto> GetPublishersByAuthor(int authorId)
        {
            var publishersByAuthor = _authorContext.AuthorsPublishers.Where(a => a.AuthorId == authorId).Select(p => p.Publisher).ToList();
            var publishersByAuthorMapped = MapConfig.Mapper.Map<ICollection<PublisherDto>>(publishersByAuthor);
            return publishersByAuthorMapped;
        }

        public ICollection<AuthorDto> GetAuthorsByPublisher(int publisherId)
        {
            var authorsByPublisher = _authorContext.AuthorsPublishers.Where(p => p.PublisherId == publisherId).Select(a => a.Author).ToList();
            var authorsByPublisherMapped = MapConfig.Mapper.Map<ICollection<AuthorDto>>(authorsByPublisher);
            return authorsByPublisherMapped;
        }

        public CountryDto GetCountryOfAnAuthor(int authorId)
        {
            var country = _authorContext.Authors.Where(a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
            var mappedCountry = MapConfig.Mapper.Map<CountryDto>(country);
            return mappedCountry;
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

        public bool CreateAuthor(AuthorCreateDto authorToCreateDto)
        {
            var authorToCreate = MapConfig.Mapper.Map<Author>(authorToCreateDto);
            _authorContext.Add(authorToCreate);
            return Save();
        }

        public bool UpdateAuthor(AuthorUpdateDto authorToUpdateDto)
        {
            var authorToUpdate = MapConfig.Mapper.Map<Author>(authorToUpdateDto);
            _authorContext.Update(authorToUpdate);
            return Save();
        }

        public bool DeleteAuthor(Author authorToDelete)
        {
            _authorContext.Remove(authorToDelete);
            return Save();
        }

        public bool Save()
        {
            var saved = _authorContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

    }
}
