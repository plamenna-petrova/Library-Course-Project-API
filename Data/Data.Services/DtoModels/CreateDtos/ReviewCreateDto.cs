using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class ReviewCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string HeadLine { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public int Rating { get; set; }
        public int BookId { get; set; }
        public int ReviewerId { get; set; }
    }
}
