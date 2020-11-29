using AutoMapper;
using Data.Models.Models;
using Data.Services.DtoModels.Dtos;

namespace Data.Services.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
