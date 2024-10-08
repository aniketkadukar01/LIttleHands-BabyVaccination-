using AutoMapper;
using LittleHands.DataModels;
using LittleHands.Models;

namespace LittleHands.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
