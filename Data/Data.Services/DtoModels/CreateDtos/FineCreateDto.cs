using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class FineCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string FineDescription { get; set; }
        [Required]
        public decimal FineFee { get; set; }
    }
}
