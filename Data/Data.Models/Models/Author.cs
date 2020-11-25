using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models.Models
{
    public class Author : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The author's first name cannot exceed 50 characters!")]
        public string AuthorFirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The author's last name cannot exceed 50 characters!")]
        public string AuthorLastName { get; set; }
        [MaxLength(3000, ErrorMessage = "The biography of the author mustn't be in excess of 2000 characters!")]
        public string AuthorBiography { get; set; }
        public virtual ICollection<BookAuthor> BooksAuthors { get; set; }
        public virtual ICollection<AuthorPublisher> AuthorsPublishers { get; set; }
        public virtual int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
