using Data.DataConnection.DtoModels.Dtos;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        IQueryable<Author> GetAllAuthors(Func<Author, bool> func = null);
        Author GetAuthorById(int authorId);
        //AuthorDto
        AuthorDto GetAuthorByIdMapped(int authorId);
        ICollection<Author> GetAuthorsOfABook(int bookId);
        ICollection<Book> GetBooksByAuthor(int authorId);
        ICollection<Publisher> GetPublishersByAuthor(int authorId);
        ICollection<Author> GetAuthorsByPublisher(int publisherId);
        Country GetCountryOfAnAuthor(int authorId);
        bool AuthorExists(int authorId);
        bool AuthorExistsByLastName(string authorLastName);
        bool CreateAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Author author);
        bool Save();
    }
}

