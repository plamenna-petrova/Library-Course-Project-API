using Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Country : BaseModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The name of the country must be up to 50 characters in length!")]
        public string CountryName { get; set; }
        public  ICollection<Author> Authors { get; set; }
        public virtual ICollection<Reviewer> Reviewers { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
