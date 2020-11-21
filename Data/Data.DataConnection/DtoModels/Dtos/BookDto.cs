using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class BookDto : BaseDtoModel
    {
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public string BookEdition { get; set; }
        public DateTime? DatePublished { get; set; }
        public int BookPages { get; set; }
        public string BookAnnotation { get; set; }
    }
}
