using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models.Models
{
    public class BookImage : BaseModel
    {
        [Required]
        public string BookImageUrl { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "There must be a small description of the image of the book with maximum length of 50 characters!")]
        public string BookImageShortDecsription { get; set; }
        [ForeignKey("Book")]
        public virtual int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
