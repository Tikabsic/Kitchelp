using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    internal class MappingProfilesConfiguration : Profile
    {
        public MappingProfilesConfiguration()
        {
            CreateMap<RegisterRequest, Owner>();
            CreateMap<RegisterRequest, Employee>();
            CreateMap<RestaurantRegisterRequest, Restaurant>();
        }
    }
}
