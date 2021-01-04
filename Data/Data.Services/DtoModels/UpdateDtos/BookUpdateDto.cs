using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class BookUpdateDto : BaseDtoModel
    {
        public string ISBN { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public string BookEdition { get; set; }
        public DateTime? DatePublished { get; set; }
        public int BookPages { get; set; }
        public string BookAnnotation { get; set; }
    }
}
