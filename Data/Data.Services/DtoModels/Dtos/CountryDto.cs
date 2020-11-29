using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class CountryDto : BaseDtoModel
    {
        public string CountryName { get; set; }
    }
}
