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
    public class ReaderRepository : IReaderRepository
    {
        private readonly ApplicationDbContext _readerContext;

        public ReaderRepository(ApplicationDbContext readerContext)
        {
            _readerContext = readerContext;
        }

        public ICollection<ReaderDto> GetReaders()
        {
            var readers = _readerContext.Readers.OrderBy(read => read.ReaderLastName).ToList();
            var mappedReaders = MapConfig.Mapper.Map<ICollection<ReaderDto>>(readers);
            return mappedReaders;
        }

        public ReaderDto GetReaderById(int readerId)
        {
            var singleReader = _readerContext.Readers.Where(read => read.Id == readerId).FirstOrDefault();
            var mappedReader = MapConfig.Mapper.Map<ReaderDto>(singleReader);
            return mappedReader;
        }

        public Reader GetReaderByIdNotMapped(int readerId)
        {
            var reader = _readerContext.Readers.Where(read => read.Id == readerId).FirstOrDefault(); 
            return reader;
        }

        public bool IsDuplicateReaderEmail(int readerId, string readerEmail)
        {
            var reader = _readerContext.Readers.Where(read => read.ReaderEmail.Trim().ToUpper() == readerEmail.Trim().ToUpper() && read.Id != readerId).FirstOrDefault();

            return reader == null ? false : true;
        }

        public ICollection<LibrarianDto> GetLibrariansWhoServedReader(int readerId)
        {
            var librariansWhoServedReader = _readerContext.ReadersLibrarians.Where(read => read.ReaderId == readerId).Select(l => l.Librarian).ToList();
            var librariansWhoServedReaderMapped = MapConfig.Mapper.Map<ICollection<LibrarianDto>>(librariansWhoServedReader);
            return librariansWhoServedReaderMapped;
        }

        public ICollection<ReaderDto> GetReadersOfALibrarian(int librarianId)
        {
            var readersOfALibrarian = _readerContext.ReadersLibrarians.Where(l => l.LibrarianId == librarianId).Select(read => read.Reader).ToList();
            var readersOfALibrarianMapped = MapConfig.Mapper.Map<ICollection<ReaderDto>>(readersOfALibrarian);
            return readersOfALibrarianMapped;
        }

        public ICollection<LoanDto> GetLoansOfAReader(int readerId)
        {
            var loansOfAReader = _readerContext.Loans.Where(read => read.Reader.Id == readerId).ToList();
            var loansOfAReaderMapped = MapConfig.Mapper.Map<ICollection<LoanDto>>(loansOfAReader);
            return loansOfAReaderMapped;
        }

        public ICollection<BookDto> GetBooksOfAReader(int readerId)
        {
            var booksOfAReader = _readerContext.ReadersBooks.Where(read => read.ReaderId == readerId).Select(b => b.Book).ToList();
            var booksOfAReaderMapped = MapConfig.Mapper.Map<ICollection<BookDto>>(booksOfAReader);
            return booksOfAReaderMapped;
        }

        public ICollection<ReaderDto> GetReadersOfABook(int bookId)
        {
            var readersOfABook = _readerContext.ReadersBooks.Where(b => b.BookId == bookId).Select(read => read.Reader).ToList();
            var readersOfABookMapped = MapConfig.Mapper.Map<ICollection<ReaderDto>>(readersOfABook);
            return readersOfABookMapped;
        }

        public ICollection<FineDto> GetFinesOfAReader(int readerId)
        {
            var finesOfAReader = _readerContext.Fines.Where(read => read.Reader.Id == readerId).ToList();
            var finesOfAReaderMapped = MapConfig.Mapper.Map<ICollection<FineDto>>(finesOfAReader);
            return finesOfAReaderMapped;
        }

        public bool ReaderExists(int readerId)
        {
            return _readerContext.Readers.Any(read => read.Id == readerId);
        }

        public bool CreateReader(ReaderCreateDto readerToCreateDto)
        {
            var readerToCreate = MapConfig.Mapper.Map<Reader>(readerToCreateDto);
            _readerContext.Add(readerToCreate);
            return Save();
        }

        public bool UpdateReader(ReaderUpdateDto readerToUpdateDto)
        {
            var readerToUpdate = MapConfig.Mapper.Map<Reader>(readerToUpdateDto);
            _readerContext.Update(readerToUpdate);
            return Save();
        }

        public bool DeleteReader(Reader reader)
        {
            _readerContext.Remove(reader);
            return Save();
        }

        public bool Save()
        {
            var saved = _readerContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
