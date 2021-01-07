using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class PublisherCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string PublisherName { get; set; }
        public int CountryId { get; set; }
    }
}
