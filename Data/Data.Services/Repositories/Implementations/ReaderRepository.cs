
using Data.DataConnection;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly ApplicationDbContext _readerContext;

        public ReaderRepository(ApplicationDbContext readerContext)
        {
            _readerContext = readerContext;
        }

        public ICollection<Reader> GetReaders()
        {
            return _readerContext.Readers.OrderBy(p => p.ReaderLastName).ToList();
        }

        public Reader GetReaderById(int readerId)
        {
            return _readerContext.Readers.Where(p => p.Id == readerId).FirstOrDefault();
        }

        public bool IsDuplicateReaderEmail(int readerId, string readerEmail)
        {
            var reader = _readerContext.Readers.Where(read => read.ReaderEmail.Trim().ToUpper() == readerEmail.Trim().ToUpper() && read.Id != readerId).FirstOrDefault();

            return reader == null ? false : true;
        }

        public ICollection<Librarian> GetLibrariansWhoServedReader(int readerId)
        {
            return _readerContext.ReadersLibrarians.Where(read => read.ReaderId == readerId).Select(l => l.Librarian).ToList();
        }

        public ICollection<Reader> GetReadersOfALibrarian(int librarianId)
        {
            return _readerContext.ReadersLibrarians.Where(l => l.LibrarianId == librarianId).Select(read => read.Reader).ToList();
        }

        public ICollection<Loan> GetLoansOfAReader(int readerId)
        {
            return _readerContext.Loans.Where(read => read.Reader.Id == readerId).ToList();
        }

        public ICollection<Book> GetBooksOfAReader(int readerId)
        {
            return _readerContext.ReadersBooks.Where(read => read.ReaderId == readerId).Select(b => b.Book).ToList();
        }

        public ICollection<Reader> GetReadersOfABook(int bookId)
        {
            return _readerContext.ReadersBooks.Where(b => b.BookId == bookId).Select(read => read.Reader).ToList();
        }

        public ICollection<Fine> GetFinesOfAReader(int readerId)
        {
            return _readerContext.Fines.Where(read => read.Reader.Id == readerId).ToList();
        }

        public bool ReaderExists(int readerId)
        {
            return _readerContext.Readers.Any(read => read.Id == readerId);
        }

        public bool CreateReader(Reader reader)
        {
            _readerContext.Add(reader);
            return Save();
        }

        public bool UpdateReader(Reader reader)
        {
            _readerContext.Update(reader);
            return Save();
        }

        public bool DeleteReader(Reader reader)
        {
            _readerContext.Remove(reader);
            return Save();
        }

        public bool Save()
        {
            var saved = _readerContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
