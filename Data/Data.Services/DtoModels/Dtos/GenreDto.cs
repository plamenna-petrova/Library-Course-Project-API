using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class GenreDto : BaseDtoModel
    {
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
