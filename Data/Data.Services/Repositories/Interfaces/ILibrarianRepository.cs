using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ILibrarianRepository
    {
        ICollection<LibrarianDto> GetLibrarians();
        LibrarianDto GetLibrarianById(int librarianId);
        Librarian GetLibrarianByIdNotMapped(int librarianId);
        ICollection<BookDto> GetBooksOfALibrarian(int librarianId);
        ICollection<LibrarianDto> GetLibrariansOfABook(int bookId);
        ICollection<FineDto> GetFinesOfALibrarian(int librarianId);
        ICollection<Loan> GetLoansOfALibrarian(int librarianId);
        ICollection<Librarian> GetLibrariansWhoServedReader(int readerId);
        ICollection<Reader> GetReadersOfALibrarian(int librarianId);
        LibraryManagingDirector GetLibraryManagingDirectorOfLibrarian(int librarian);
        bool LibrarianExists(int librarianId);
        bool CreateLibrarian(LibrarianCreateDto librarianToCreateDto);
        bool UpdateLibrarian(LibrarianUpdateDto librarianToUpdateDto);
        bool DeleteLibrarian(Librarian librarian);
        bool Save();
    }
}
