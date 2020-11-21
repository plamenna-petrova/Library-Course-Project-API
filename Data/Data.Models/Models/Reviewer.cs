using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Reviewer : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "No more than 50 symbols are allowed for the first name of the reviewer!")]
        public string ReviewerFirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "No more than 50 symbols are allowed for the reviewer's last name!")]
        public string ReviewerLastName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BookReviewer> BooksReviewers { get; set; }
        public virtual Country Country { get; set; }
    }
}
