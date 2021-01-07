using Data.Services.DtoModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class FineUpdateDto : BaseDtoModel
    {
        [Required]
        public string FineDescription { get; set; }
        [Required]
        public decimal FineFee { get; set; }
        public int ReaderId { get; set; }
        public int LibrarianId { get; set; }
    }
}
