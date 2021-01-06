using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class LibrarianUpdateDto : BaseDtoModel
    {
        [Required]
        public string LibrarianFirstName { get; set; }
        [Required]
        public string LibrarianLastName { get; set; }
        public int LibraryManagingDirectorId { get; set; }
    }
}
