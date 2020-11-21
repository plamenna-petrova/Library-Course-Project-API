using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class GenreDto : BaseDtoModel
    {
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
