using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    internal class MappingProfilesConfiguration : Profile
    {
        public MappingProfilesConfiguration()
        {
            CreateMap<RegisterRequestDTO, Owner>();
            CreateMap<RegisterRequestDTO, Employee>();
        }
    }
}
