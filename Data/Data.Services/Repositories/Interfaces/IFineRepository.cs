using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IFineRepository
    {
        ICollection<FineDto> GetFines();
        FineDto GetFineById(int fineId);
        Fine GetFineByIdNotMapped(int fineId);
        Reader GetReaderWhoWasFined(int fineId);
        Librarian GetLibrarianWhoIssuedFine(int fineId);
        bool FineExists(int fineId);
        bool CreateFine(FineCreateDto fineToCreateDto);
        bool UpdateFine(FineUpdateDto fineToUpdateDto);
        bool DeleteFine(Fine fine);
        bool Save();
    }
}
