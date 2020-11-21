using Data.Models.Abstraction;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class BookAuthor 
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

