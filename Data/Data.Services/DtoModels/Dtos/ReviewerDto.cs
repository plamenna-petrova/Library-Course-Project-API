using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class ReviewerDto : BaseDtoModel
    {
        public string ReviewerFirstName { get; set; }
        public string ReviewerLastName { get; set; }
    }
}
