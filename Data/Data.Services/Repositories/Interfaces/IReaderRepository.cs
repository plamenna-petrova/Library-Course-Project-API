using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IReaderRepository
    {
        ICollection<Reader> GetReaders();
        Reader GetReaderById(int readerId);
        bool IsDuplicateReaderEmail(int readerId, string readerEmail);
        ICollection<Librarian> GetLibrariansWhoServedReader(int readerId);
        ICollection<Reader> GetReadersOfALibrarian(int librarianId);
        ICollection<Loan> GetLoansOfAReader(int readerId);
        ICollection<Book> GetBooksOfAReader(int readerId);
        ICollection<Reader> GetReadersOfABook(int bookId);
        ICollection<Fine> GetFinesOfAReader(int readerId);
        bool ReaderExists(int readerId);
        bool CreateReader(Reader reader);
        bool UpdateReader(Reader reader);
        bool DeleteReader(Reader reader);
        bool Save();
    }
}
