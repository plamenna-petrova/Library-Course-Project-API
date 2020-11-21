using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class ReviewerDto : BaseDtoModel
    {
        public string ReviewerFirstName { get; set; }
        public string ReviewerLastName { get; set; }
    }
}
