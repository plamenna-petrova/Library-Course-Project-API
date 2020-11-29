using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class FineDto : BaseDtoModel
    {
        public string FineDescription { get; set; }
        public decimal FineFee { get; set; }
    }
}