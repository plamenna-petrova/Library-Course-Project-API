using Data.Models.Models;
using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class LibrarianDto : BaseDtoModel
    {
        public string LibrarianFirstName { get; set; }
        public string LibrarianLastName { get; set; }
        public int LibraryManagingDirectorId { get; set; }
        public LibraryManagingDirector LibraryManagingDirector { get; set; }
    }
}
