﻿using Data.Models.Models;
using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class ReviewerDto : BaseDtoModel
    {
        public string ReviewerFirstName { get; set; }
        public string ReviewerLastName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
