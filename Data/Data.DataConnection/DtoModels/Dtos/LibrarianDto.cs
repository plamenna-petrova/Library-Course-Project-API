using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class LibrarianDto : BaseDtoModel
    {
        public string LibrarianFirstName { get; set; }
        public string LibrarianLastName { get; set; }
    }
}