using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        ICollection<LoanDto> GetLoans();
        LoanDto GetLoanById(int loanId);
        Loan GetLoanByIdNotMapped(int loanId);
        BookDto GetBookOfALoan(int loanId);
        LibrarianDto GetLibrarianWhoProcessedLoan(int loanId);
        Reader GetReaderOfALoan(int loanId);
        bool LoanExists(int loanId);
        bool CreateLoan(LoanCreateDto loanToCreateDto);
        bool UpdateLoan(LoanUpdateDto loanToUpdateDto);
        bool DeleteLoan(Loan loan);
        bool Save();
    }
}
