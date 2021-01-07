using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class ReviewerCreateDto 
    {
        public int Id { get; set; }
        [Required]
        public string ReviewerFirstName { get; set; }
        [Required]
        public string ReviewerLastName { get; set; }
        public int CountryId { get; set; }
    }
}
