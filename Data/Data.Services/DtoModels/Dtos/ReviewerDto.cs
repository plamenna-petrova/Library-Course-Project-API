using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class ReviewerDto : BaseDtoModel
    {
        public string ReviewerFirstName { get; set; }
        public string ReviewerLastName { get; set; }
    }
}
