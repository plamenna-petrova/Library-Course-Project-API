using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class ReviewDto : BaseDtoModel
    {
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
