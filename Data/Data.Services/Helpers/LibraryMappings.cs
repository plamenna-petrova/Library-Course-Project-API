using AutoMapper;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;

namespace LData.Services.Helpers
{
    public class LibraryMappings : Profile
    {
        public LibraryMappings()
        {
            //model to dto
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            //model to create dto
            CreateMap<Author, AuthorCreateDto>().ReverseMap();
            //model to update dto
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();
        }
    }
}
