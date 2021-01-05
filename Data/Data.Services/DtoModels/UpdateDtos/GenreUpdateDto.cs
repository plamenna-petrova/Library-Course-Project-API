using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class GenreUpdateDto : BaseDtoModel
    {
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
