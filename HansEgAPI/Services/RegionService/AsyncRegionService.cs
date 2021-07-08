using AutoMapper;
using HansEgAPI.Dtos.RegionDtos;
using HansEgAPI.Models;
using HansEgAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.RegionService
{
    public class AsyncRegionService : IAsyncRegionService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRegionRepo _repo;
        private readonly IAsyncGovernorateRepo _governorateRepo;

        public AsyncRegionService(IMapper mapper, IAsyncRegionRepo repo, IAsyncGovernorateRepo governorateRepo)
        {
            _repo = repo;
            _governorateRepo = governorateRepo;
            _mapper = mapper;
        }

        public async Task DeleteRegionAsync(int regionId)
        {
            var regionFromRepo = await _repo.GetRegionById(regionId);

            if (regionFromRepo == null)
                throw new ArgumentNullException(nameof(regionFromRepo));

            _repo.DeleteRegion(regionFromRepo);

            await _repo.SaveChanges();
        }

        public async Task<List<RegionReadDto>> GetGovernorateRegionsAsync(int governorateId)
        {
            var governorateFromRepo = await _governorateRepo.GetGovernorateById(governorateId);

            if (governorateFromRepo == null)
                return new List<RegionReadDto>();

            var regionsFromRepo = await _repo.GetGovernorateRegions(governorateId);

            return _mapper.Map<List<RegionReadDto>>(regionsFromRepo);
        }

        public async Task<RegionReadDto> GetRegionByIdAsync(int regionId)
        {
            var regionFromRepo = await _repo.GetRegionById(regionId);

            return _mapper.Map<RegionReadDto>(regionFromRepo);
        }

        public async Task<List<RegionReadDto>> GetRegionsAsync()
        {
            var regionsFromRepo = await _repo.GetRegions();

            return _mapper.Map<List<RegionReadDto>>(regionsFromRepo);
        }

        public async Task PostRegionAsync(RegionCreateDto regionDto)
        {
            var region = _mapper.Map<Region>(regionDto);

            _repo.CreateRegion(region);

            await _repo.SaveChanges();
        }

        public async Task UpdateRegionAsync(int regionId, RegionUpdateDto regionUpdateDto)
        {
            var regionFromRepo = await _repo.GetRegionById(regionId);

            if (regionFromRepo == null)
                throw new ArgumentNullException(nameof(regionFromRepo));

            if(regionUpdateDto.GovernorateId == null)
            {
                regionUpdateDto.GovernorateId = regionFromRepo.Governorate.GovernorateId;
            }

            _mapper.Map(regionUpdateDto, regionFromRepo);

            await _repo.SaveChanges();
        }
    }
}
