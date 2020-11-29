using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class FineDto : BaseDtoModel
    {
        public string FineDescription { get; set; }
        public decimal FineFee { get; set; }
    }
}
