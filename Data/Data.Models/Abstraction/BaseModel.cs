using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Abstraction
{
    public abstract class BaseModel : IBaseModel, IAuditInfo
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
