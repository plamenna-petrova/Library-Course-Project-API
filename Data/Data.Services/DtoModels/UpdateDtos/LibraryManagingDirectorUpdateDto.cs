using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class LibraryManagingDirectorUpdateDto : BaseDtoModel
    {
        [Required]
        public string LibraryManagingDirectorFirstName { get; set; }
        [Required]
        public string LibraryManagingDirectorLastName { get; set; }
        public int WorkingExperienceInYears { get; set; }
    }
}
