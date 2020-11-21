using Data.DataConnection.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class AuthorDto : BaseDtoModel
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
    }
}

