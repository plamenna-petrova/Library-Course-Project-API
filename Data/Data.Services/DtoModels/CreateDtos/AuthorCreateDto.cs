using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class AuthorCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
