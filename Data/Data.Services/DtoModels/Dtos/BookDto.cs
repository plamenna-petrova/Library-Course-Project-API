using Data.Models.Models;
using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class BookDto : BaseDtoModel
    {
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public string BookEdition { get; set; }
        public DateTime? DatePublished { get; set; }
        public int BookPages { get; set; }
        public string BookAnnotation { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int BookImageId { get; set; }
        public BookImage BookImage { get; set; }
    }
}
