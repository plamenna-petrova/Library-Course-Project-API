using Data.Services.DtoModels.Abstraction;
using System;

namespace Data.Services.DtoModels.Dtos
{
    public class LoanDto : BaseDtoModel
    {
        public DateTime IssueDate { get; set; }
        public DateTime DateToReturn { get; set; }
        public bool IsActiveLoan { get; set; }
    }
}