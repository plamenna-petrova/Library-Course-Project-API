using Data.Services.DtoModels.Interfaces;
using System;

namespace Data.Services.DtoModels.Abstraction
{
    public abstract class BaseDtoModel : IBaseDtoModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
