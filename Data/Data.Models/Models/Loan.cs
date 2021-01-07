using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Loan : BaseModel
    {
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime DateToReturn { get; set; }
        [Required]
        public bool IsActiveLoan { get; set; }
        public virtual int? BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual int? LibrarianId { get; set; }
        public virtual Librarian Librarian { get; set; }
        public virtual Reader Reader { get; set; }
    }
}

