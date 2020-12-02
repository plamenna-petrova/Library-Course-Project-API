using AutoMapper;
using Data.Models.Models;
using Data.Services.DtoModels.Dtos.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //mapper
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
