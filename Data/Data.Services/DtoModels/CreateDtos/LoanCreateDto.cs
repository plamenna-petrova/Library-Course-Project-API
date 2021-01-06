using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class LoanCreateDto
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateToReturn { get; set; }
        public bool IsActiveLoan { get; set; }
    }
}
