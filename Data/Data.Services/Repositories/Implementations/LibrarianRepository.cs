using Data.DataConnection;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly ApplicationDbContext _librarianContext;

        public LibrarianRepository(ApplicationDbContext librarianContext)
        {
            _librarianContext = librarianContext;
        }

        public ICollection<Librarian> GetLibrarians()
        {
            return _librarianContext.Librarians.OrderBy(l => l.LibrarianLastName).ToList();
        }

        public Librarian GetLibrarianById(int librarianId)
        {
            return _librarianContext.Librarians.Where(l => l.Id == librarianId).FirstOrDefault();
        }

        public ICollection<Book> GetBooksOfALibrarian(int librarianId)
        {
            return _librarianContext.LibrariansBooks.Where(l => l.LibrarianId == librarianId).Select(b => b.Book).ToList();
        }

        public ICollection<Librarian> GetLibrariansOfABook(int bookId)
        {
            return _librarianContext.LibrariansBooks.Where(b => b.BookId == bookId).Select(l => l.Librarian).ToList();
        }

        public ICollection<Loan> GetLoansOfALibrarian(int librarianId)
        {
            return _librarianContext.Loans.Where(l => l.Librarian.Id == librarianId).ToList();
        }

        public ICollection<Librarian> GetLibrariansWhoServedReader(int readerId)
        {
            return _librarianContext.ReadersLibrarians.Where(read => read.ReaderId == readerId).Select(l => l.Librarian).ToList();
        }

        public ICollection<Reader> GetReadersOfALibrarian(int librarianId)
        {
            return _librarianContext.ReadersLibrarians.Where(l => l.LibrarianId == librarianId).Select(read => read.Reader).ToList();
        }

        public LibraryManagingDirector GetLibraryManagingDirectorOfLibrarian(int librarianId)
        {
            var libraryManagingDirectorId = _librarianContext.Librarians.Where(l => l.Id == librarianId).Select(lmd => lmd.LibraryManagingDirector.Id).FirstOrDefault();
            return _librarianContext.LibraryManagingDirectors.Where(lmd => lmd.Id == libraryManagingDirectorId).FirstOrDefault();
        }

        public bool LibrarianExists(int librarianId)
        {
            return _librarianContext.Librarians.Any(l => l.Id == librarianId);
        }

        public bool CreateLibrarian(Librarian librarian)
        {
            _librarianContext.Add(librarian);
            return Save();
        }

        public bool UpdateLibrarian(Librarian librarian)
        {
            _librarianContext.Update(librarian);
            return Save();
        }

        public bool DeleteLibrarian(Librarian librarian)
        {
            _librarianContext.Remove(librarian);
            return Save();
        }

        public bool Save()
        {
            var saved = _librarianContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
