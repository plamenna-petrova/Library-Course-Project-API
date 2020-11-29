using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ILibraryManagingDirectorRepository
    {
        ICollection<LibraryManagingDirector> GetLibraryManagingDirector();
        LibraryManagingDirector GetLibraryManagingDirectorById(int libraryManagingDirectorId);
        ICollection<Librarian> GetLibrariansOfALibraryManagingDirector(int libraryManagingDirectorId);
        bool LibraryManagingDirectorExists(int libraryManagingDirectorId);
        bool CreateLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector);
        bool UpdateLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector);
        bool DeleteLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector);
        bool Save();
    }
}
