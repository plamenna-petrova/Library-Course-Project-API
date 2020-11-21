using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IFineRepository
    {
        ICollection<Fine> GetFines();
        Fine GetFineById(int fineId);
        Reader GetReaderWhoWasFined(int fineId);
        Librarian GetLibrarianWhoIssuedFine(int fineId);
        bool FineExists(int fineId);
        bool CreateFine(Fine fine);
        bool UpdateFine(Fine fine);
        bool DeleteFine(Fine fine);
        bool Save();
    }
}

