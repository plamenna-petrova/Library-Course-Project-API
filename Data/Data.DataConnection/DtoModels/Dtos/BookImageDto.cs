using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class BookImageDto : BaseDtoModel
    {
        public string BookImageUrl { get; set; }
        public string BookImageShortDecsription { get; set; }
    }
}
