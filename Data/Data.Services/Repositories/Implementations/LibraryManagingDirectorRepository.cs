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
    public class LibraryManagingDirectorRepository : ILibraryManagingDirectorRepository
    {
        private readonly ApplicationDbContext _libraryManagingDirectorContext;

        public LibraryManagingDirectorRepository(ApplicationDbContext libraryManagingDirectorContext)
        {
            _libraryManagingDirectorContext = libraryManagingDirectorContext;
        }

        public ICollection<LibraryManagingDirectorDto> GetLibraryManagingDirectors()
        {
            var librayManagingDirectors = _libraryManagingDirectorContext.LibraryManagingDirectors.OrderBy(lmd => lmd.LibraryManagingDirectorLastName).ToList();
            var libraryManagingDirectorsMapped = MapConfig.Mapper.Map<ICollection<LibraryManagingDirectorDto>>(librayManagingDirectors);
            return libraryManagingDirectorsMapped;
        }

        public LibraryManagingDirectorDto GetLibraryManagingDirectorById(int libraryManagingDirectorId)
        {
            var singleLibraryManagingDirector = _libraryManagingDirectorContext.LibraryManagingDirectors.Where(lmd => lmd.Id == libraryManagingDirectorId).FirstOrDefault();
            var libraryManagingDirectorMapped = MapConfig.Mapper.Map<LibraryManagingDirectorDto>(singleLibraryManagingDirector);
            return libraryManagingDirectorMapped;
        }

        public LibraryManagingDirector GetLibraryManagingDirectorByIdNotMapped(int libraryManagingDirectorId)
        {
            var libraryManagingDirector = _libraryManagingDirectorContext.LibraryManagingDirectors.Where(lmd => lmd.Id == libraryManagingDirectorId).FirstOrDefault();
            return libraryManagingDirector;
        }

        public ICollection<LibrarianDto> GetLibrariansOfALibraryManagingDirector(int libraryManagingDirectorId)
        {
            var librariansOfALibraryManagingDirector = _libraryManagingDirectorContext.Librarians.Where(lmd => lmd.LibraryManagingDirector.Id == libraryManagingDirectorId).ToList();
            var librariansOfALibraryManagingDirectorMapped = MapConfig.Mapper.Map<ICollection<LibrarianDto>>(librariansOfALibraryManagingDirector);
            return librariansOfALibraryManagingDirectorMapped;
        }

        public bool LibraryManagingDirectorExists(int libraryManagingDirectorId)
        {
            return _libraryManagingDirectorContext.LibraryManagingDirectors.Any(lmd => lmd.Id == libraryManagingDirectorId);
        }

        public bool CreateLibraryManagingDirector(LibraryManagingDirectorCreateDto libraryManagingDirectorToCreateDto)
        {
            var libraryManagingDirectorToCreate = MapConfig.Mapper.Map<LibraryManagingDirector>(libraryManagingDirectorToCreateDto);
            _libraryManagingDirectorContext.Add(libraryManagingDirectorToCreate);
            return Save();
        }

        public bool UpdateLibraryManagingDirector(LibraryManagingDirectorUpdateDto libraryManagingDirectorToUpdateDto)
        {
            var libraryManagingDirectorToUpdate = MapConfig.Mapper.Map<LibraryManagingDirector>(libraryManagingDirectorToUpdateDto);
            _libraryManagingDirectorContext.Update(libraryManagingDirectorToUpdate);
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
