using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Book : BaseModel
    {
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "ISBN must be between 3 and characters long!")]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "The book's title cannot be more than 100 characters long!")]
        public string BookTitle { get; set; }
        public string BookEdition { get; set; }
        public DateTime? DatePublished { get; set; }
        public int BookPages { get; set; }
        [MaxLength(2000, ErrorMessage = "The book's annotation length cannot surpass 2000 characters!")]
        public string BookAnnotation { get; set; }
        public virtual ICollection<BookAuthor> BooksAuthors { get; set; }
        public virtual ICollection<BookGenre> BooksGenres { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BookReviewer> BooksReviewers { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<LibrarianBook> LibrariansBooks { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<ReaderBook> ReadersBooks { get; set; }
        public virtual BookImage BookImage { get; set; }
    }
}
