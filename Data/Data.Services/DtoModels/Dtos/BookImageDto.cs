using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class BookImageDto : BaseDtoModel
    {
        public string BookImageUrl { get; set; }
        public string BookImageShortDecsription { get; set; }
    }
}
