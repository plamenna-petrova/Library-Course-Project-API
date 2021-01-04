using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class BookImageCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string BookImageUrl { get; set; }
        public string BookImageShortDecsription { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
