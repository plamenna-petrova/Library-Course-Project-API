using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class PublisherUpdateDto : BaseDtoModel
    {
        [Required]
        public string PublisherName { get; set; }
        public int CountryId { get; set; }
    }
}
