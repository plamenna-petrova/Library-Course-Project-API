using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class BookImageUpdateDto : BaseDtoModel
    {
        [Required]
        public string BookImageUrl { get; set; }
        public string BookImageShortDecsription { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
