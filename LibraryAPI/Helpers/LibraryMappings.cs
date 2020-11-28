using AutoMapper;
using Data.DataConnection.DtoModels.Dtos;
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
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
