using Data.DataConnection.DtoModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Abstraction
{
    public abstract class BaseDtoModel : IBaseDtoModel
    {
        public int Id { get; set; }
        //public DateTime CreatedAt { get; set; }
    }
}
