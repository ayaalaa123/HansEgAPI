using AutoMapper;
using HansEgAPI.Dtos.GovernorateDtos;
using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Profiles
{
    public class GovernorateProfiles : Profile
    {
        public GovernorateProfiles()
        {
            CreateMap<Governorate, GovernorateCreateDto>();

            CreateMap<GovernorateCreateDto, Governorate>();

            CreateMap<Task<List<Governorate>>, Task<List<GovernorateCreateDto>>>();

            CreateMap<Task<List<GovernorateCreateDto>>, Task<List<Governorate>>>();
            
            CreateMap<Governorate, GovernorateUpdateDto>();

            CreateMap<GovernorateUpdateDto, Governorate>();

            CreateMap<Task<List<Governorate>>, Task<List<GovernorateUpdateDto>>>();

            CreateMap<Task<List<GovernorateUpdateDto>>, Task<List<Governorate>>>();

            CreateMap<Governorate, GovernorateReadDto>();

            CreateMap<GovernorateReadDto, Governorate>();

            CreateMap<Task<List<Governorate>>, Task<List<GovernorateReadDto>>>();

            CreateMap<Task<List<GovernorateReadDto>>, Task<List<Governorate>>>();
        }
    }
}
