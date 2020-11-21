using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class BookReviewer
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
