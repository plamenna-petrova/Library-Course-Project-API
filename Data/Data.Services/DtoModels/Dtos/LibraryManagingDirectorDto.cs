using Data.Services.DtoModels.Abstraction;

namespace Data.Services.DtoModels.Dtos
{
    public class LibraryManagingDirectorDto : BaseDtoModel
    {
        public string LibraryManagingDirectorFirstName { get; set; }
        public string LibraryManagingDirectorLastName { get; set; }
        public int WorkingExperienceInYears { get; set; }
    }
}
