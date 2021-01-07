using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface IReaderRepository
    {
        ICollection<ReaderDto> GetReaders();
        ReaderDto GetReaderById(int readerId);
        Reader GetReaderByIdNotMapped(int readerId);
        bool IsDuplicateReaderEmail(int readerId, string readerEmail);
        ICollection<LibrarianDto> GetLibrariansWhoServedReader(int readerId);
        ICollection<ReaderDto> GetReadersOfALibrarian(int librarianId);
        ICollection<LoanDto> GetLoansOfAReader(int readerId);
        ICollection<BookDto> GetBooksOfAReader(int readerId);
        ICollection<ReaderDto> GetReadersOfABook(int bookId);
        ICollection<FineDto> GetFinesOfAReader(int readerId);
        bool ReaderExists(int readerId);
        bool CreateReader(ReaderCreateDto readerToCreateDto);
        bool UpdateReader(ReaderUpdateDto readerToUpdateDto);
        bool DeleteReader(Reader reader);
        bool Save();
    }
}
