using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author GetAuthorById(int authorId);
        //AuthorDto
        ICollection<Author> GetAuthorsOfABook(int bookId);
        ICollection<Book> GetBooksByAuthor(int authorId);
        ICollection<Publisher> GetPublishersByAuthor(int authorId);
        ICollection<Author> GetAuthorsByPublisher(int publisherId);
        Country GetCountryOfAnAuthor(int authorId);
        bool AuthorExists(int authorId);
        bool CreateAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Author author);
        bool Save();
    }
}

