using Data.DataConnection;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services.Repositories.Implementations
{
    public class FineRepository : IFineRepository
    {
        private readonly ApplicationDbContext _fineContext;

        public FineRepository(ApplicationDbContext fineContext)
        {
            _fineContext = fineContext;
        }

        public ICollection<Fine> GetFines()
        {
            return _fineContext.Fines.ToList();
        }

        public Fine GetFineById(int fineId)
        {
            return _fineContext.Fines.Where(f => f.Id == fineId).FirstOrDefault();
        }

        public Reader GetReaderWhoWasFined(int fineId)
        {
            var readerId = _fineContext.Fines.Where(f => f.Id == fineId).Select(read => read.Reader.Id).FirstOrDefault();
            return _fineContext.Readers.Where(read => read.Id == readerId).FirstOrDefault();
        }

        public Librarian GetLibrarianWhoIssuedFine(int fineId)
        {
            var librarianId = _fineContext.Fines.Where(f => f.Id == fineId).Select(l => l.Librarian.Id).FirstOrDefault();
            return _fineContext.Librarians.Where(l => l.Id == librarianId).FirstOrDefault();
        }

        public bool FineExists(int fineId)
        {
            return _fineContext.Fines.Any(f => f.Id == fineId);
        }

        public bool CreateFine(Fine fine)
        {
            _fineContext.Add(fine);
            return Save();
        }

        public bool UpdateFine(Fine fine)
        {
            _fineContext.Update(fine);
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
