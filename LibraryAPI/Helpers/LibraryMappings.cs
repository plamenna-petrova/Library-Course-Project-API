using AutoMapper;
using Data.DataConnection.DtoModels.CreateDtos;
using Data.DataConnection.DtoModels.Dtos;
using Data.DataConnection.DtoModels.UpdateDtos;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Helpers
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
