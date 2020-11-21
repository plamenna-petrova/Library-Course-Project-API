using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Reader : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The reader's first name mustn't be more than 50 characters long!")]
        public string ReaderFirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The reader's last name mustn't be more than 50 characters long!")]
        public string ReaderLastName { get; set; }
        public int ReaderAge { get; set; }
        public enum ReaderOccupation { GradeSchoolStudent, HighSchoolStudent, Employed, Unemployed, Retiree }
        public string ReaderAddress { get; set; }
        public string ReaderCity { get; set; }
        public string ReaderEmail { get; set; }
        public int ReaderContactNumber { get; set; }
        public decimal LibraryFee { get; set; }
        public bool HasPayedTheLibraryFee { get; set; }
        public virtual ICollection<ReaderLibrarian> ReadersLibrarians { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<ReaderBook> ReadersBooks { get; set; }
        public virtual ICollection<Fine> Fines { get; set; }
    }
}
