using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class GenreCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
