using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class AuthorCreateDto
    {
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
