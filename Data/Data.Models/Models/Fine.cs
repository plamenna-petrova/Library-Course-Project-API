using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Fine : BaseModel
    {
        [Required]
        [MaxLength(1000, ErrorMessage = "The description of the fine mustn't be longer than 1000 symbols!")]
        public string FineDescription { get; set; }
        public decimal FineFee { get; set; }
        public virtual int? ReaderId { get; set; }
        public virtual Reader Reader { get; set; }
        public virtual int? LibrarianId { get; set; }
        public virtual Librarian Librarian { get; set; }
    }
}

