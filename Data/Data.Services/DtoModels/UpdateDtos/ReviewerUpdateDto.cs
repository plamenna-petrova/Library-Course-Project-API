using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class ReviewerUpdateDto : BaseDtoModel
    {
        [Required]
        public string ReviewerFirstName { get; set; }
        [Required]    
        public string ReviewerLastName { get; set; }
        public int CountryId { get; set; }
    }
}
