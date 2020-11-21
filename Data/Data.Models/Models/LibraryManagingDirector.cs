using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class LibraryManagingDirector : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The first name of the managing director of the library cannot exceed 50 characters!")]
        public string LibraryManagingDirectorFirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The last name of the managin director of the library cannot exceed 50 characters!")]
        public string LibraryManagingDirectorLastName { get; set; }
        public int WorkingExperienceInYears { get; set; }
        public virtual ICollection<Librarian> Librarians { get; set; }
    }
}

