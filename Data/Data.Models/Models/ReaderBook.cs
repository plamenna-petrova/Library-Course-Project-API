using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class ReaderBook
    {
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
