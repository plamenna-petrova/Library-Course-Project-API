using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IBookRepository
    {
        ICollection<BookDto> GetBooks();
        BookDto GetBookById(int bookId);
        Book GetBookByIdNotMapped(int bookId);
        BookDto GetBookByISBN(string bookISBN);
        decimal GetBookRating(int bookId);
        bool BookExistsById(int bookId);
        bool BookExistsByISBN(string bookISBN);
        bool IsDuplicateISBN(int bookId, string bookISBN);
        ICollection<Author> GetAuthorsOfABook(int bookId);
        ICollection<Book> GetBooksByAuthor(int authorId);
        ICollection<Genre> GetAllGenresForABook(int bookId);
        ICollection<Book> GetAllBooksForGenre(int genreId);
        ICollection<Review> GetReviewsOfABook(int bookId);
        ICollection<Reviewer> GetReviewersOfABook(int bookId);
        ICollection<Book> GetBooksOfAReviewer(int reviewerId);
        Publisher GetPublisherOfABook(int bookId);
        ICollection<Book> GetBooksOfALibrarian(int librarianId);
        ICollection<Librarian> GetLibrariansOfABook(int bookId);
        ICollection<Loan> GetLoansOfABook(int bookId);
        ICollection<Book> GetBooksOfAReader(int readerId);
        ICollection<Reader> GetReadersOfABook(int bookId);
        BookImage GetImageOfABook(int bookId);
        //bool CreateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book);
        bool CreateBook(BookCreateDto bookToCreateDto);
        //bool UpdateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book);
        bool UpdateBook(BookUpdateDto bookToUpdateDto);
        bool DeleteBook(Book book);
        bool Save();
    }
}
