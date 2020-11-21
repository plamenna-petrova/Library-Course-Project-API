using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class ReaderLibrarian
    {
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int LibrarianId { get; set; }
        public Librarian Librarian { get; set; }
    }
}
