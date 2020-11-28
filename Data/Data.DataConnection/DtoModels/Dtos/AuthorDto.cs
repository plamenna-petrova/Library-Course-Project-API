﻿using Data.DataConnection.DtoModels.Abstraction;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DataConnection.DtoModels.Dtos
{
    public class AuthorDto : BaseDtoModel
    {
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}

