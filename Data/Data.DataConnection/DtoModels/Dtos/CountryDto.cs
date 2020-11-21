using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class CountryDto : BaseDtoModel
    {
        public string CountryName { get; set; }
    }
}
