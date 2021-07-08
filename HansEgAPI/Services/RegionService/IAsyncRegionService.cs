using HansEgAPI.Dtos.RegionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.RegionService
{
    public interface IAsyncRegionService
    {
        Task<List<RegionReadDto>> GetRegionsAsync();

        Task<List<RegionReadDto>> GetGovernorateRegionsAsync(int governorateId);

        Task<RegionReadDto> GetRegionByIdAsync(int regionId);

        Task PostRegionAsync(RegionCreateDto regionCreateDto);

        Task UpdateRegionAsync(int regionId, RegionUpdateDto regionDto);

        Task DeleteRegionAsync(int regionId);
    }
}
