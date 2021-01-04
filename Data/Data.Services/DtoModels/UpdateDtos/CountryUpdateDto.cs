using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class CountryUpdateDto : BaseDtoModel
    {
        [Required]
        public string CountryName { get; set; }
    }
}
