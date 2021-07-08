using AutoMapper;
using HansEgAPI.Dtos.RegionDtos;
using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Profiles
{
    public class RegionProfiles : Profile
    {
        public RegionProfiles()
        {
            CreateMap<Region, RegionUpdateDto>();

            CreateMap<RegionUpdateDto, Region>();
            
            CreateMap<Task<List<Region>>, Task<List<RegionUpdateDto>>>();

            CreateMap<Task<List<RegionUpdateDto>>, Task<List<Region>>>();

            CreateMap<Region, RegionCreateDto>();

            CreateMap<RegionCreateDto, Region>();

            CreateMap<Task<List<Region>>, Task<List<RegionCreateDto>>>();

            CreateMap<Task<List<RegionCreateDto>>, Task<List<Region>>>();

            CreateMap<Region, RegionReadDto>();

            CreateMap<RegionReadDto, Region>();

            CreateMap<Task<List<Region>>, Task<List<RegionReadDto>>>();

            CreateMap<Task<List<RegionReadDto>>, Task<List<Region>>>();
        }
    }
}
