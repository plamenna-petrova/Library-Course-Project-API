using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class LibraryManagingDirectorCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string LibraryManagingDirectorFirstName { get; set; }
        [Required]
        public string LibraryManagingDirectorLastName { get; set; }
        public int WorkingExperienceInYears { get; set; }
    }
}
