using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class GenreCreateDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
