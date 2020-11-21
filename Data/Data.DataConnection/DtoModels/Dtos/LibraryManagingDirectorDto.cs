using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class LibraryManagingDirectorDto : BaseDtoModel
    {
        public string LibraryManagingDirectorFirstName { get; set; }
        public string LibraryManagingDirectorLastName { get; set; }
        public int WorkingExperienceInYears { get; set; }
    }
}
