using Data.Services.DtoModels.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Data.Services.DtoModels.UpdateDtos
{
    public class AuthorUpdateDto : BaseDtoModel
    {
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
