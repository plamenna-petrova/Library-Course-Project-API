using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Genre : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The name of the genre must be no more than 50 characters in length!")]
        public string GenreName { get; set; }
        [MaxLength(100, ErrorMessage = "The description of the genre mustn't be more than 50 characters long!")]
        public string GenreDescription { get; set; }
        public virtual ICollection<BookGenre> BooksGenres { get; set; }
    }
}
