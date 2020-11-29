using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class GenreDto : BaseDtoModel
    {
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
