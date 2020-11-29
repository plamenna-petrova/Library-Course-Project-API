using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        ICollection<Loan> GetLoans();
        Loan GetLoanById(int loanId);
        Book GetBookOfALoan(int loanId);
        Librarian GetLibrarianWhoProcessedLoan(int loanId);
        Reader GetReaderOfALoan(int loanId);
        bool LoanExists(int loanId);
        bool CreateLoan(Loan loan);
        bool UpdateLoan(Loan loan);
        bool DeleteLoan(Loan loan);
        bool Save();
    }
}
