﻿using Data.Models.Models;
using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class PublisherDto : BaseDtoModel
    {
        [Required]
        public string PublisherName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
