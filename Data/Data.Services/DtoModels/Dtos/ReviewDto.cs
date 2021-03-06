﻿using Data.Models.Models;
using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels.Dtos
{
    public class ReviewDto : BaseDtoModel
    {
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
