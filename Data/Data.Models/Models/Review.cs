using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Review : BaseModel
    {
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Headlines must be in the range of 10 and 200 characters!")]
        public string HeadLine { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 50, ErrorMessage = "The text of a review must be between 50 and 5000 characters!")]
        public string ReviewText { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "The rating must be between 1 and 10 stars!")]
        public int Rating { get; set; }
        public virtual int? BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual int? ReviewerId { get; set; }
        public virtual Reviewer Reviewer { get; set; }
    }
}

