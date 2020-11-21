using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Publisher : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The name of the publisher must be at the maxiumum of 50 characters in length!")]
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<AuthorPublisher> AuthorsPublishers { get; set; }
        public virtual Country Country { get; set; }
    }
}