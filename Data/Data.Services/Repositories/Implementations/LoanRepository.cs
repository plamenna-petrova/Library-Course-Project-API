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
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _loanContext;

        public LoanRepository(ApplicationDbContext loanContext)
        {
            _loanContext = loanContext;
        }

        public ICollection<LoanDto> GetLoans()
        {
            var loans = _loanContext.Loans.OrderBy(lo => lo.DateToReturn).ToList();
            var mappedLoans = MapConfig.Mapper.Map<ICollection<LoanDto>>(loans);
            return mappedLoans;
        }

        public LoanDto GetLoanById(int loanId)
        {
            var singleLoan = _loanContext.Loans.Where(lo => lo.Id == loanId).FirstOrDefault();
            var mappedLoan = MapConfig.Mapper.Map<LoanDto>(singleLoan);
            return mappedLoan;
        }

        public Loan GetLoanByIdNotMapped(int loanId)
        {
            var loan = _loanContext.Loans.Where(lo => lo.Id == loanId).FirstOrDefault();
            return loan;
        }

        public Book GetBookOfALoan(int loanId)
        {
            var bookId = _loanContext.Loans.Where(lo => lo.Id == loanId).Select(b => b.Book.Id).FirstOrDefault();
            return _loanContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Librarian GetLibrarianWhoProcessedLoan(int loanId)
        {
            var librarianId = _loanContext.Loans.Where(lo => lo.Id == loanId).Select(l => l.Librarian.Id).FirstOrDefault();
            return _loanContext.Librarians.Where(l => l.Id == librarianId).FirstOrDefault();
        }

        public Reader GetReaderOfALoan(int loanId)
        {
            var readerId = _loanContext.Loans.Where(lo => lo.Id == loanId).Select(read => read.Reader.Id).FirstOrDefault();
            return _loanContext.Readers.Where(read => read.Id == readerId).FirstOrDefault();
        }

        public bool LoanExists(int loanId)
        {
            return _loanContext.Loans.Any(lo => lo.Id == loanId);
        }

        public bool CreateLoan(LoanCreateDto loanToCreateDto)
        {
            var loanToCreate = MapConfig.Mapper.Map<Loan>(loanToCreateDto);
            _loanContext.Add(loanToCreate);
            return Save();
        }

        public bool UpdateLoan(LoanUpdateDto loanToUpdateDto)
        {
            var loanToUpdate = MapConfig.Mapper.Map<Loan>(loanToUpdateDto);
            _loanContext.Update(loanToUpdate);
            return Save();
        }

        public bool DeleteLoan(Loan loan)
        {
            _loanContext.Remove(loan);
            return Save();
        }

        public bool Save()
        {
            var saved = _loanContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
