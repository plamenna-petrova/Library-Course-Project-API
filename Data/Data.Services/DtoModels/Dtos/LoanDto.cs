using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class LoanDto : BaseDtoModel
    {
        public DateTime IssueDate { get; set; }
        public DateTime DateToReturn { get; set; }
        public bool IsActiveLoan { get; set; }
    }
}
