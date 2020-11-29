using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class ReviewDto : BaseDtoModel
    {
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
