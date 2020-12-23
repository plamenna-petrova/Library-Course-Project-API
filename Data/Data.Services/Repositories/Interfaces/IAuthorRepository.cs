using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
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
        bool CreateAuthor(AuthorCreateDto authorToCreateDto);
        bool UpdateAuthor(AuthorUpdateDto authorToUpdateDto);
        bool DeleteAuthor(AuthorDto authorDto);
        bool Save();
    }
}
