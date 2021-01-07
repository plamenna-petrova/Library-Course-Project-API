using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class LoanCreateDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime DateToReturn { get; set; }
        [Required]
        public bool IsActiveLoan { get; set; }
        public int BookId { get; set; }
        public int LibrarianId { get; set; }
    }
}
