﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class CountryCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
