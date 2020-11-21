using Data.DataConnection.Repositories.Interfaces;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataConnection.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _bookContext;

        public BookRepository(ApplicationDbContext bookDbContext)
        {
            _bookContext = bookDbContext;
        }

        public ICollection<Book> GetBooks()
        {
            return _bookContext.Books.OrderBy(b => b.BookTitle).ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _bookContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Book GetBookByISBN(string bookISBN)
        {
            return _bookContext.Books.Where(b => b.ISBN == bookISBN).FirstOrDefault();
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

        public ICollection<Author> GetAuthorsOfABook(int bookId)
        {
            return _bookContext.BooksAuthors.Where(b => b.BookId == bookId).Select(a => a.Author).ToList();
        }

        public ICollection<Book> GetBooksByAuthor(int authorId)
        {
            return _bookContext.BooksAuthors.Where(a => a.AuthorId == authorId).Select(b => b.Book).ToList();
        }

        public ICollection<Book> GetAllBooksForGenre(int genreId)
        {
            return _bookContext.BooksGenres.Where(g => g.GenreId == genreId).Select(b => b.Book).ToList();
        }

        public ICollection<Genre> GetAllGenresForABook(int bookId)
        {
            return _bookContext.BooksGenres.Where(b => b.BookId == bookId).Select(g => g.Genre).ToList();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            return _bookContext.Reviews.Where(b => b.Book.Id == bookId).ToList();
        }

        public ICollection<Reviewer> GetReviewersOfABook(int bookId)
        {
            return _bookContext.BooksReviewers.Where(b => b.BookId == bookId).Select(rev => rev.Reviewer).ToList();
        }

        public ICollection<Book> GetBooksOfAReviewer(int reviewerId)
        {
            return _bookContext.BooksReviewers.Where(rev => rev.ReviewerId == reviewerId).Select(b => b.Book).ToList();
        }

        public Publisher GetPublisherOfABook(int bookId)
        {
            var publisherId = _bookContext.Books.Where(b => b.Id == bookId).Select(p => p.Publisher.Id).FirstOrDefault();
            return _bookContext.Publishers.Where(p => p.Id == publisherId).FirstOrDefault();
        }

        public ICollection<Book> GetBooksOfALibrarian(int librarianId)
        {
            return _bookContext.LibrariansBooks.Where(l => l.LibrarianId == librarianId).Select(b => b.Book).ToList();
        }

        public ICollection<Librarian> GetLibrariansOfABook(int bookId)
        {
            return _bookContext.LibrariansBooks.Where(b => b.BookId == bookId).Select(l => l.Librarian).ToList();
        }

        public ICollection<Loan> GetLoansOfABook(int bookId)
        {
            return _bookContext.Loans.Where(b => b.Book.Id == bookId).ToList();
        }

        public ICollection<Book> GetBooksOfAReader(int readerId)
        {
            return _bookContext.ReadersBooks.Where(read => read.ReaderId == readerId).Select(b => b.Book).ToList();
        }

        public ICollection<Reader> GetReadersOfABook(int bookId)
        {
            return _bookContext.ReadersBooks.Where(b => b.BookId == bookId).Select(read => read.Reader).ToList();
        }

        public BookImage GetImageOfABook(int bookId)
        {
            var bookImageId = _bookContext.Books.Where(b => b.Id == bookId).Select(bi => bi.BookImage.Id).FirstOrDefault();
            return _bookContext.BookImages.Where(bi => bi.Id == bookImageId).FirstOrDefault();
        }

        public bool CreateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book)
        {
            var authors = _bookContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
            var genres = _bookContext.Genres.Where(g => genresId.Contains(g.Id)).ToList();
            var reviewers = _bookContext.Reviewers.Where(rev => reviewersId.Contains(rev.Id)).ToList();
            var librarians = _bookContext.Librarians.Where(l => librariansId.Contains(l.Id)).ToList();
            var readers = _bookContext.Readers.Where(r => readersId.Contains(r.Id)).ToList();

            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor()
                {
                    Author = author,
                    Book = book
                };
                _bookContext.Add(bookAuthor);
            }

            foreach (var genre in genres)
            {
                var bookGenre = new BookGenre()
                {
                    Genre = genre,
                    Book = book
                };
                _bookContext.Add(bookGenre);
            }

            foreach (var reviewer in reviewers)
            {
                var bookReviewer = new BookReviewer()
                {
                    Reviewer = reviewer,
                    Book = book
                };
                _bookContext.Add(bookReviewer);
            }

            foreach (var librarian in librarians)
            {
                var librarianBook = new LibrarianBook()
                {
                    Book = book,
                    Librarian = librarian
                };
                _bookContext.Add(librarianBook);
            }

            foreach (var reader in readers)
            {
                var readerBook = new ReaderBook()
                {
                    Book = book,
                    Reader = reader
                };
                _bookContext.Add(readerBook);
            }

            _bookContext.Add(book);

            return Save();
        }

        public bool UpdateBook(List<int> authorsId, List<int> genresId, List<int> reviewersId, List<int> librariansId, List<int> readersId, Book book)
        {
            var authors = _bookContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
            var genres = _bookContext.Genres.Where(g => genresId.Contains(g.Id)).ToList();
            var reviewers = _bookContext.Reviewers.Where(rev => reviewersId.Contains(rev.Id)).ToList();
            var librarians = _bookContext.Librarians.Where(l => librariansId.Contains(l.Id)).ToList();
            var readers = _bookContext.Readers.Where(r => readersId.Contains(r.Id)).ToList();

            var bookAuthorsToDelete = _bookContext.BooksAuthors.Where(b => b.BookId == book.Id);
            var bookGenresToDelete = _bookContext.BooksGenres.Where(b => b.BookId == book.Id);
            var bookReviewersToDelete = _bookContext.BooksReviewers.Where(b => b.BookId == book.Id);
            var bookLibrariansToDelete = _bookContext.LibrariansBooks.Where(b => b.BookId == book.Id);
            var bookReadersToDelete = _bookContext.ReadersBooks.Where(b => b.BookId == book.Id);

            _bookContext.RemoveRange(bookAuthorsToDelete);
            _bookContext.RemoveRange(bookGenresToDelete);
            _bookContext.RemoveRange(bookReviewersToDelete);
            _bookContext.RemoveRange(bookLibrariansToDelete);
            _bookContext.RemoveRange(bookReadersToDelete);

            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor()
                {
                    Author = author,
                    Book = book
                };
                _bookContext.Add(bookAuthor);
            }

            foreach (var genre in genres)
            {
                var bookGenre = new BookGenre()
                {
                    Genre = genre,
                    Book = book
                };
                _bookContext.Add(bookGenre);
            }

            foreach (var reviewer in reviewers)
            {
                var bookReviewer = new BookReviewer()
                {
                    Reviewer = reviewer,
                    Book = book
                };
                _bookContext.Add(bookReviewer);
            }

            foreach (var librarian in librarians)
            {
                var librarianBook = new LibrarianBook()
                {
                    Book = book,
                    Librarian = librarian
                };
                _bookContext.Add(librarianBook);
            }

            foreach (var reader in readers)
            {
                var readerBook = new ReaderBook()
                {
                    Book = book,
                    Reader = reader
                };
                _bookContext.Add(readerBook);
            }

            _bookContext.Add(book);

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