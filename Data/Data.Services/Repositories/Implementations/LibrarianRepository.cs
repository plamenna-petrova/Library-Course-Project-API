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
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly ApplicationDbContext _librarianContext;

        public LibrarianRepository(ApplicationDbContext librarianContext)
        {
            _librarianContext = librarianContext;
        }

        public ICollection<LibrarianDto> GetLibrarians()
        {
            var librarians = _librarianContext.Librarians.OrderBy(l => l.LibrarianLastName).ToList();
            var mappedLibrarians = MapConfig.Mapper.Map<ICollection<LibrarianDto>>(librarians);
            return mappedLibrarians;
        }

        public LibrarianDto GetLibrarianById(int librarianId)
        {
            var singleLibrarian = _librarianContext.Librarians.Where(l => l.Id == librarianId).FirstOrDefault();
            var mappedLibrarian = MapConfig.Mapper.Map<LibrarianDto>(singleLibrarian);
            return mappedLibrarian;
        }

        public Librarian GetLibrarianByIdNotMapped(int librarianId)
        {
            var librarian = _librarianContext.Librarians.Where(l => l.Id == librarianId).FirstOrDefault();
            return librarian;
        }

        public ICollection<BookDto> GetBooksOfALibrarian(int librarianId)
        {
            var booksOfALibrarian = _librarianContext.LibrariansBooks.Where(l => l.LibrarianId == librarianId).Select(b => b.Book).ToList();
            var booksOfALibrarianMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksOfALibrarian);
            return booksOfALibrarianMapped;
        }

        public ICollection<LibrarianDto> GetLibrariansOfABook(int bookId)
        {
            var librariansOfABook = _librarianContext.LibrariansBooks.Where(b => b.BookId == bookId).Select(l => l.Librarian).ToList();
            var librariansOfABookMapped = MapConfig.Mapper.Map<ICollection<LibrarianDto>>(librariansOfABook);
            return librariansOfABookMapped;
        }

        public ICollection<FineDto> GetFinesOfALibrarian(int librarianId)
        {
            var fines = _librarianContext.Fines.Where(l => l.Librarian.Id == librarianId).ToList();
            var mappedFines = MapConfig.Mapper.Map<ICollection<FineDto>>(fines);
            return mappedFines;
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

        public LibraryManagingDirectorDto GetLibraryManagingDirectorOfLibrarian(int librarianId)
        {
            var libraryManagingDirectorOfLibrarian = _librarianContext.Librarians.Where(l => l.Id == librarianId).Select(lmd => lmd.LibraryManagingDirector).FirstOrDefault();
            var libraryManagingDirectorOfLibrarianMapped = MapConfig.Mapper.Map<LibraryManagingDirectorDto>(libraryManagingDirectorOfLibrarian);
            return libraryManagingDirectorOfLibrarianMapped;
        }

        public bool LibrarianExists(int librarianId)
        {
            return _librarianContext.Librarians.Any(l => l.Id == librarianId);
        }

        public bool CreateLibrarian(LibrarianCreateDto librarianToCreateDto)
        {
            var librarianToCreate = MapConfig.Mapper.Map<Librarian>(librarianToCreateDto);
            _librarianContext.Add(librarianToCreate);
            return Save();
        }

        public bool UpdateLibrarian(LibrarianUpdateDto librarianToUpdateDto)
        {
            var librarianToUpdate = MapConfig.Mapper.Map<Librarian>(librarianToUpdateDto);
            _librarianContext.Update(librarianToUpdate);
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
