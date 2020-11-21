using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class LibrarianBook
    {
        public int LibrarianId { get; set; }
        public Librarian Librarian { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}