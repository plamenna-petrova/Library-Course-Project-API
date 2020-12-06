using Data.Models.Models;
using Data.Services.DtoModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
   
    public interface IAuthorRepository
    {
        ICollection<AuthorDto> GetAuthors();
        //IQueryable<AuthorDto> GetAuthors(Func<AuthorDto, bool> filter = null);
        AuthorDto GetAuthorById(int authorId);
        ICollection<AuthorDto> GetAuthorsOfABook(int bookId);
        ICollection<BookDto> GetBooksByAuthor(int authorId);
        ICollection<PublisherDto> GetPublishersByAuthor(int authorId);
        ICollection<AuthorDto> GetAuthorsByPublisher(int publisherId);
        CountryDto GetCountryOfAnAuthor(int authorId);
        bool AuthorExists(int authorId);
        bool AuthorExistsByLastName(string authorLastName);
        bool CreateAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(AuthorDto author);
        bool Save();
    }
}
