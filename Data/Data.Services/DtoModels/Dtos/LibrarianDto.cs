using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class LibrarianDto : BaseDtoModel
    {
        public string LibrarianFirstName { get; set; }
        public string LibrarianLastName { get; set; }
    }
}