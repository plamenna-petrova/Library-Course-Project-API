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
        ICollection<AuthorDto> GetAuthorsOfABook(int bookId);
        ICollection<BookDto> GetBooksByAuthor(int authorId);
        ICollection<GenreDto> GetAllGenresForABook(int bookId);
        ICollection<BookDto> GetAllBooksForGenre(int genreId);
        ICollection<Review> GetReviewsOfABook(int bookId);
        ICollection<Reviewer> GetReviewersOfABook(int bookId);
        ICollection<Book> GetBooksOfAReviewer(int reviewerId);
        PublisherDto GetPublisherOfABook(int bookId);
        ICollection<BookDto> GetBooksOfALibrarian(int librarianId);
        ICollection<LibrarianDto> GetLibrariansOfABook(int bookId);
        ICollection<Loan> GetLoansOfABook(int bookId);
        ICollection<Book> GetBooksOfAReader(int readerId);
        ICollection<Reader> GetReadersOfABook(int bookId);
        BookImageDto GetImageOfABook(int bookId);
        //bool CreateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book);
        bool CreateBook(BookCreateDto bookToCreateDto);
        //bool UpdateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book);
        bool UpdateBook(BookUpdateDto bookToUpdateDto);
        bool DeleteBook(Book book);
        bool Save();
    }
}
