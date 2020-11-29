using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ILibrarianRepository
    {
        ICollection<Librarian> GetLibrarians();
        Librarian GetLibrarianById(int librarianId);
        ICollection<Book> GetBooksOfALibrarian(int librarianId);
        ICollection<Librarian> GetLibrariansOfABook(int bookId);
        ICollection<Loan> GetLoansOfALibrarian(int librarianId);
        ICollection<Librarian> GetLibrariansWhoServedReader(int readerId);
        ICollection<Reader> GetReadersOfALibrarian(int librarianId);
        LibraryManagingDirector GetLibraryManagingDirectorOfLibrarian(int librarian);
        bool LibrarianExists(int librarianId);
        bool CreateLibrarian(Librarian librarian);
        bool UpdateLibrarian(Librarian librarian);
        bool DeleteLibrarian(Librarian librarian);
        bool Save();
    }
}
