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
        public int ReaderId { get; set; }
        public int LibrarianId { get; set; }
    }
}
