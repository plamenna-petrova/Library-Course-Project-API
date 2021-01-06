using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Librarian : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The librarian's first name cannot exceed 50 characters!")]
        public string LibrarianFirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The librarian's last name cannot exceed 50 characters!")]
        public string LibrarianLastName { get; set; }
        public virtual ICollection<LibrarianBook> LibrariansBooks { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<ReaderLibrarian> ReadersLibrarians { get; set; }
        public virtual int? LibraryManagingDirectorId { get; set; }
        public virtual LibraryManagingDirector LibraryManagingDirector { get; set; }
    }
}