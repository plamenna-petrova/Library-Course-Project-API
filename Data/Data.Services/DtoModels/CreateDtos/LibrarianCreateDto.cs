using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class LibrarianCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string LibrarianFirstName { get; set; }
        [Required]
        public string LibrarianLastName { get; set; }
    }
}
