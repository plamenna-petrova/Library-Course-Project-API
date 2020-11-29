using Data.Services.DtoModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Abstraction
{
    public class BaseDtoModel : IBaseDtoModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
