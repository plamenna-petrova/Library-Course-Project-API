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
    public class FineRepository : IFineRepository
    {
        private readonly ApplicationDbContext _fineContext;

        public FineRepository(ApplicationDbContext fineContext)
        {
            _fineContext = fineContext;
        }

        public ICollection<FineDto> GetFines()
        {
            var fines = _fineContext.Fines.ToList();
            var mappedFines = MapConfig.Mapper.Map<ICollection<FineDto>>(fines);
            return mappedFines;
        }

        public FineDto GetFineById(int fineId)
        {
            var singleFine = _fineContext.Fines.Where(f => f.Id == fineId).FirstOrDefault();
            var mappedFine = MapConfig.Mapper.Map<FineDto>(singleFine);
            return mappedFine;
        }

        public Fine GetFineByIdNotMapped(int fineId)
        {
            var fine = _fineContext.Fines.Where(f => f.Id == fineId).FirstOrDefault();
            return fine;
        }

        public Reader GetReaderWhoWasFined(int fineId)
        {
            var readerId = _fineContext.Fines.Where(f => f.Id == fineId).Select(read => read.Reader.Id).FirstOrDefault();
            return _fineContext.Readers.Where(read => read.Id == readerId).FirstOrDefault();
        }

        public LibrarianDto GetLibrarianWhoIssuedFine(int fineId)
        {
            var librarianWhoIssuedFine = _fineContext.Fines.Where(f => f.Id == fineId).Select(l => l.Librarian).FirstOrDefault();
            var librarianWhoIssuedFineMapped = MapConfig.Mapper.Map<LibrarianDto>(librarianWhoIssuedFine);
            return librarianWhoIssuedFineMapped;
        }

        public bool FineExists(int fineId)
        {
            return _fineContext.Fines.Any(f => f.Id == fineId);
        }

        public bool CreateFine(FineCreateDto fineToCreateDto)
        {
            var fineToCreate = MapConfig.Mapper.Map<Fine>(fineToCreateDto);
            _fineContext.Add(fineToCreate);
            return Save();
        }

        public bool UpdateFine(FineUpdateDto fineToUpdateDto)
        {
            var fineToUpdate = MapConfig.Mapper.Map<Fine>(fineToUpdateDto);
            _fineContext.Update(fineToUpdate);
            return Save();
        }

        public bool DeleteFine(Fine fine)
        {
            _fineContext.Remove(fine);
            return Save();
        }

        public bool Save()
        {
            var saved = _fineContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
