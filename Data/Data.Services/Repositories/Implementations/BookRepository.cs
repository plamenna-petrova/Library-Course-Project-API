using Data.DataConnection;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using Data.Services.Helpers;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _bookContext;

        public BookRepository(ApplicationDbContext bookDbContext)
        {
            _bookContext = bookDbContext;
        }

        public ICollection<BookDto> GetBooks()
        {
            var books = _bookContext.Books.OrderBy(b => b.BookTitle).ToList();
            var mappedBooks = MapConfig.Mapper.Map<ICollection<BookDto>>(books);
            return mappedBooks;
        }

        public BookDto GetBookById(int bookId)
        {
            var singleBook = _bookContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
            var mappedBook = MapConfig.Mapper.Map<BookDto>(singleBook);
            return mappedBook;
        }

        public Book GetBookByIdNotMapped(int bookId)
        {
            return _bookContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public BookDto GetBookByISBN(string bookISBN)
        {
            var bookByISBN = _bookContext.Books.Where(b => b.ISBN == bookISBN).FirstOrDefault();
            var bookByISBNMapped = MapConfig.Mapper.Map<BookDto>(bookByISBN);
            return bookByISBNMapped;
        }

        public decimal GetBookRating(int bookId)
        {
            var reviews = _bookContext.Reviews.Where(r => r.Book.Id == bookId);

            if (reviews.Count() <= 0)
            {
                return 0;
            }

            return ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());
        }

        //return BookTitle, Author, group by BookTitle and Review Count - to do, Dtos

        public bool BookExistsById(int bookId)
        {
            return _bookContext.Books.Any(b => b.Id == bookId);
        }

        public bool BookExistsByISBN(string bookISBN)
        {
            return _bookContext.Books.Any(b => b.ISBN == bookISBN);
        }

        public bool IsDuplicateISBN(int bookId, string bookISBN)
        {
            var book = _bookContext.Books.Where(b => b.ISBN.Trim().ToUpper() == bookISBN.Trim().ToUpper() && b.Id != bookId).FirstOrDefault();

            return book == null ? false : true;
        }

        public ICollection<AuthorDto> GetAuthorsOfABook(int bookId)
        {
            var authorsOfABook = _bookContext.BooksAuthors.Where(b => b.BookId == bookId).Select(a => a.Author).ToList();
            var authorsOfABookMapped = MapConfig.Mapper.Map<ICollection<AuthorDto>>(authorsOfABook);
            return authorsOfABookMapped;
        }

        public ICollection<BookDto> GetBooksByAuthor(int authorId)
        {
            var booksByAuthor = _bookContext.BooksAuthors.Where(a => a.AuthorId == authorId).Select(b => b.Book).ToList();
            var booksByAuthorMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksByAuthor);
            return booksByAuthorMapped;
        }

        public ICollection<BookDto> GetAllBooksForGenre(int genreId)
        {
            var booksForGenre = _bookContext.BooksGenres.Where(g => g.GenreId == genreId).Select(b => b.Book).ToList();
            var booksForGenreMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksForGenre);
            return booksForGenreMapped;
        }

        public ICollection<GenreDto> GetAllGenresForABook(int bookId)
        {
            var genresForABook = _bookContext.BooksGenres.Where(b => b.BookId == bookId).Select(g => g.Genre).ToList();
            var genresForABookMapped = MapConfig.Mapper.Map<ICollection<GenreDto>>(genresForABook);
            return genresForABookMapped;
        }

        public ICollection<ReviewDto> GetReviewsOfABook(int bookId)
        {
            var reviewsOfABook = _bookContext.Reviews.Where(b => b.Book.Id == bookId).ToList();
            var reviewsOfABookMapped = MapConfig.Mapper.Map<ICollection<ReviewDto>>(reviewsOfABook);
            return reviewsOfABookMapped;
        }

        public ICollection<ReviewerDto> GetReviewersOfABook(int bookId)
        {
            var reviewersOfABook = _bookContext.BooksReviewers.Where(b => b.BookId == bookId).Select(rev => rev.Reviewer).ToList();
            var reviewersOfABookMapped = MapConfig.Mapper.Map<ICollection<ReviewerDto>>(reviewersOfABook);
            return reviewersOfABookMapped;
        }

        public ICollection<BookDto> GetBooksOfAReviewer(int reviewerId)
        {
            var booksOfAReviewer = _bookContext.BooksReviewers.Where(rev => rev.ReviewerId == reviewerId).Select(b => b.Book).ToList();
            var booksOfAReviewerMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksOfAReviewer);
            return booksOfAReviewerMapped;
        }

        public PublisherDto GetPublisherOfABook(int bookId)
        {
            //var publisherId = _bookContext.Books.Where(b => b.Id == bookId).Select(p => p.Publisher.Id).FirstOrDefault();
            //var publisher = _bookContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
            var publisher = _bookContext.Books.Where(b => b.Id == bookId).Select(p => p.Publisher).FirstOrDefault();
            var mappedPublisher = MapConfig.Mapper.Map<PublisherDto>(publisher);
            return mappedPublisher;
        }

        public ICollection<BookDto> GetBooksOfALibrarian(int librarianId)
        {
            var booksOfALibrarian = _bookContext.LibrariansBooks.Where(l => l.LibrarianId == librarianId).Select(b => b.Book).ToList();
            var booksOfALibrarianMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksOfALibrarian);
            return booksOfALibrarianMapped;
        }

        public ICollection<LibrarianDto> GetLibrariansOfABook(int bookId)
        {
            var librariansOfABook = _bookContext.LibrariansBooks.Where(b => b.BookId == bookId).Select(l => l.Librarian).ToList();
            var librariansOfABookMapped = MapConfig.Mapper.Map<ICollection<LibrarianDto>>(librariansOfABook);
            return librariansOfABookMapped;
        }

        public ICollection<LoanDto> GetLoansOfABook(int bookId)
        {
            var loansOfABook = _bookContext.Loans.Where(b => b.Book.Id == bookId).ToList();
            var loansOfABookMapped = MapConfig.Mapper.Map<ICollection<LoanDto>>(loansOfABook);
            return loansOfABookMapped;
        }

        public ICollection<BookDto> GetBooksOfAReader(int readerId)
        {
            var booksOfAReader = _bookContext.ReadersBooks.Where(read => read.ReaderId == readerId).Select(b => b.Book).ToList();
            var booksOfAReaderMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksOfAReader);
            return booksOfAReaderMapped;
        }

        public ICollection<ReaderDto> GetReadersOfABook(int bookId)
        {
            var readersOfABook = _bookContext.ReadersBooks.Where(b => b.BookId == bookId).Select(read => read.Reader).ToList();
            var readersOfABookMapped = MapConfig.Mapper.Map<ICollection<ReaderDto>>(readersOfABook);
            return readersOfABookMapped;
        }

        public BookImageDto GetImageOfABook(int bookId)
        {
            //var bookImageId = _bookContext.Books.Where(b => b.Id == bookId).Select(bi => bi.BookImage.Id).FirstOrDefault();
            //return _bookContext.BookImages.Where(bi => bi.Id == bookImageId).FirstOrDefault();
            var bookImage = _bookContext.Books.Where(b => b.Id == bookId).Select(bi => bi.BookImage).FirstOrDefault();
            var mappedBookImage = MapConfig.Mapper.Map<BookImageDto>(bookImage);
            return mappedBookImage;
        }

        //public bool CreateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book)
        //{
        //    var authors = _bookContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
        //    var genres = _bookContext.Genres.Where(g => genresId.Contains(g.Id)).ToList();
        //    var reviewers = _bookContext.Reviewers.Where(rev => reviewersId.Contains(rev.Id)).ToList();
        //    var librarians = _bookContext.Librarians.Where(l => librariansId.Contains(l.Id)).ToList();
        //    var readers = _bookContext.Readers.Where(r => readersId.Contains(r.Id)).ToList();

        //    foreach (var author in authors)
        //    {
        //        var bookAuthor = new BookAuthor()
        //        {
        //            Author = author,
        //            Book = book
        //        };
        //        _bookContext.Add(bookAuthor);
        //    }

        //    foreach (var genre in genres)
        //    {
        //        var bookGenre = new BookGenre()
        //        {
        //            Genre = genre,
        //            Book = book
        //        };
        //        _bookContext.Add(bookGenre);
        //    }

        //    foreach (var reviewer in reviewers)
        //    {
        //        var bookReviewer = new BookReviewer()
        //        {
        //            Reviewer = reviewer,
        //            Book = book
        //        };
        //        _bookContext.Add(bookReviewer);
        //    }

        //    foreach (var librarian in librarians)
        //    {
        //        var librarianBook = new LibrarianBook()
        //        {
        //            Book = book,
        //            Librarian = librarian
        //        };
        //        _bookContext.Add(librarianBook);
        //    }

        //    foreach (var reader in readers)
        //    {
        //        var readerBook = new ReaderBook()
        //        {
        //            Book = book,
        //            Reader = reader
        //        };
        //        _bookContext.Add(readerBook);
        //    }

        //    _bookContext.Add(book);

        //    return Save();
        //}

        public bool CreateBook(BookCreateDto bookToCreateDto)
        {
            var bookToCreate = MapConfig.Mapper.Map<Book>(bookToCreateDto);
            _bookContext.Add(bookToCreate);
            return Save();
        }

        //public bool UpdateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book)
        //{
        //    var authors = _bookContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
        //    var genres = _bookContext.Genres.Where(g => genresId.Contains(g.Id)).ToList();
        //    var reviewers = _bookContext.Reviewers.Where(rev => reviewersId.Contains(rev.Id)).ToList();
        //    var librarians = _bookContext.Librarians.Where(l => librariansId.Contains(l.Id)).ToList();
        //    var readers = _bookContext.Readers.Where(r => readersId.Contains(r.Id)).ToList();

        //    var bookAuthorsToDelete = _bookContext.BooksAuthors.Where(b => b.BookId == book.Id);
        //    var bookGenresToDelete = _bookContext.BooksGenres.Where(b => b.BookId == book.Id);
        //    var bookReviewersToDelete = _bookContext.BooksReviewers.Where(b => b.BookId == book.Id);
        //    var bookLibrariansToDelete = _bookContext.LibrariansBooks.Where(b => b.BookId == book.Id);
        //    var bookReadersToDelete = _bookContext.ReadersBooks.Where(b => b.BookId == book.Id);

        //    _bookContext.RemoveRange(bookAuthorsToDelete);
        //    _bookContext.RemoveRange(bookGenresToDelete);
        //    _bookContext.RemoveRange(bookReviewersToDelete);
        //    _bookContext.RemoveRange(bookLibrariansToDelete);
        //    _bookContext.RemoveRange(bookReadersToDelete);

        //    foreach (var author in authors)
        //    {
        //        var bookAuthor = new BookAuthor()
        //        {
        //            Author = author,
        //            Book = book
        //        };
        //        _bookContext.Add(bookAuthor);
        //    }

        //    foreach (var genre in genres)
        //    {
        //        var bookGenre = new BookGenre()
        //        {
        //            Genre = genre,
        //            Book = book
        //        };
        //        _bookContext.Add(bookGenre);
        //    }

        //    foreach (var reviewer in reviewers)
        //    {
        //        var bookReviewer = new BookReviewer()
        //        {
        //            Reviewer = reviewer,
        //            Book = book
        //        };
        //        _bookContext.Add(bookReviewer);
        //    }

        //    foreach (var librarian in librarians)
        //    {
        //        var librarianBook = new LibrarianBook()
        //        {
        //            Book = book,
        //            Librarian = librarian
        //        };
        //        _bookContext.Add(librarianBook);
        //    }

        //    foreach (var reader in readers)
        //    {
        //        var readerBook = new ReaderBook()
        //        {
        //            Book = book,
        //            Reader = reader
        //        };
        //        _bookContext.Add(readerBook);
        //    }

        //    _bookContext.Add(book);

        //    return Save();
        //}

        public bool UpdateBook(BookUpdateDto bookToUpdateDto)
        {
            var bookToUpdate = MapConfig.Mapper.Map<Book>(bookToUpdateDto);
            _bookContext.Update(bookToUpdate);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _bookContext.Remove(book);
            return Save();
        }

        public bool Save()
        {
            var saved = _bookContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

    }
}
