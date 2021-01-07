using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class LoanUpdateDto : BaseDtoModel
    {
        public DateTime IssueDate { get; set; }
        public DateTime DateToReturn { get; set; }
        public bool IsActiveLoan { get; set; }
        public int BookId { get; set; }
        public int LibrarianId { get; set; }
        public int ReaderId { get; set; }
    }
}
