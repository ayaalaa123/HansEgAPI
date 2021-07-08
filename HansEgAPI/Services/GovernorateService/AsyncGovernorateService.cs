using AutoMapper;
using HansEgAPI.Dtos.GovernorateDtos;
using HansEgAPI.Models;
using HansEgAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.GovernorateService
{
    public class AsyncGovernorateService : IAsyncGovernorateService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncGovernorateRepo _repo;

        public AsyncGovernorateService(IMapper mapper, IAsyncGovernorateRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        
        public async Task DeleteGovernorateAsync(int governorateId)
        {
            var governorateFromRepo = await _repo.GetGovernorateById(governorateId);

            if (governorateFromRepo == null)
                throw new ArgumentNullException(nameof(governorateFromRepo));

            _repo.DeleteGovernorate(governorateFromRepo);

            await _repo.SaveChanges();
        }

        public async Task<GovernorateReadDto> GetGovernorateByIdAsync(int governorateId)
        {
            var governorateFromRepo = await _repo.GetGovernorateById(governorateId);

            return _mapper.Map<GovernorateReadDto>(governorateFromRepo);
        }

        public async Task<List<GovernorateReadDto>> GetGovernoratesAsync()
        {
            var governoratesFromRepo = await _repo.GetGovernorates();

            return _mapper.Map<List<GovernorateReadDto>>(governoratesFromRepo);
        }

        public async Task PostGovernorateAsync(GovernorateCreateDto governorateCreateDto)
        {
            var governorate = _mapper.Map<Governorate>(governorateCreateDto);

            _repo.CreateGovernorate(governorate);

            await _repo.SaveChanges();
        }

        public async Task UpdateGovernorateAsync(int governorateId, GovernorateUpdateDto governorateUpdateDto)
        {
            var governorateFromRepo = await _repo.GetGovernorateById(governorateId);

            if (governorateFromRepo == null)
                throw new ArgumentNullException(nameof(governorateFromRepo));

            _mapper.Map(governorateUpdateDto, governorateFromRepo);

            await _repo.SaveChanges();
        }
    }
}
