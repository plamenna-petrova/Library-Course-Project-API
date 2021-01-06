using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ILibraryManagingDirectorRepository
    {
        ICollection<LibraryManagingDirectorDto> GetLibraryManagingDirectors();
        LibraryManagingDirectorDto GetLibraryManagingDirectorById(int libraryManagingDirectorId);
        LibraryManagingDirector GetLibraryManagingDirectorByIdNotMapped(int libraryManagingDirectorId);
        ICollection<LibrarianDto> GetLibrariansOfALibraryManagingDirector(int libraryManagingDirectorId);
        bool LibraryManagingDirectorExists(int libraryManagingDirectorId);
        bool CreateLibraryManagingDirector(LibraryManagingDirectorCreateDto libraryManagingDirectorToCreateDto);
        bool UpdateLibraryManagingDirector(LibraryManagingDirectorUpdateDto libraryManagingDirectorToUpdateDto);
        bool DeleteLibraryManagingDirector(LibraryManagingDirector libraryManagingDirector);
        bool Save();
    }
}
