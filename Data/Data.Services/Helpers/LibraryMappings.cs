using AutoMapper;
using Data.Models.Models;
using Data.Services.DtoModels.CreateDtos;
using Data.Services.DtoModels.Dtos;
using Data.Services.DtoModels.UpdateDtos;

namespace Data.Services.Helpers
{
    class LibraryMappings : Profile
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
            //dto to create dto
            CreateMap<AuthorDto, AuthorCreateDto>().ReverseMap();
            CreateMap<BookImage, BookImageDto>().ReverseMap();
            CreateMap<BookImage, BookImageCreateDto>().ReverseMap();
            CreateMap<BookImage, BookImageUpdateDto>().ReverseMap();
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryCreateDto>().ReverseMap();
            CreateMap<Country, CountryUpdateDto>().ReverseMap();
        }
    }
}
