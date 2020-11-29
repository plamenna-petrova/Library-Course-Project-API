using Data.DataConnection;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class LibraryManagingDirectorRepository : ILibraryManagingDirectorRepository
    {
        private readonly ApplicationDbContext _libraryManagingDirectorContext;

        public LibraryManagingDirectorRepository(ApplicationDbContext libraryManagingDirectorContext)
        {
            _libraryManagingDirectorContext = libraryManagingDirectorContext;
        }

        public ICollection<LibraryManagingDirector> GetLibraryManagingDirector()
        {
            return _libraryManagingDirectorContext.LibraryManagingDirectors.OrderBy(lmd => lmd.LibraryManagingDirectorLastName).ToList();
        }

        public LibraryManagingDirector GetLibraryManagingDirectorById(int libraryManagingDirectorId)
        {
            return _libraryManagingDirectorContext.LibraryManagingDirectors.Where(lmd => lmd.Id == libraryManagingDirectorId).FirstOrDefault();
        }

        public ICollection<Librarian> GetLibrariansOfALibraryManagingDirector(int libraryManagingDirectorId)
        {
            return _libraryManagingDirectorContext.Librarians.Where(lmd => lmd.LibraryManagingDirector.Id == libraryManagingDirectorId).ToList();
        }

        public bool LibraryManagingDirectorExists(int libraryManagingDirectorId)
        {
            return _libraryManagingDirectorContext.LibraryManagingDirectors.Any(lmd => lmd.Id == libraryManagingDirectorId);
        }

        public bool CreateLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector)
        {
            _libraryManagingDirectorContext.Add(libraryManagingDirector);
            return Save();
        }

        public bool UpdateLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector)
        {
            _libraryManagingDirectorContext.Update(libraryManagingDirector);
            return Save();
        }

        public bool DeleteLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector)
        {
            _libraryManagingDirectorContext.Remove(libraryManagingDirector);
            return Save();
        }

        public bool Save()
        {
            var saved = _libraryManagingDirectorContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
