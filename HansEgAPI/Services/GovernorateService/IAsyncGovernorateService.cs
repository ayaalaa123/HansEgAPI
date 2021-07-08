using HansEgAPI.Dtos.GovernorateDtos;
using HansEgAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.GovernorateService
{ 
    public interface IAsyncGovernorateService
    {
        Task<List<GovernorateReadDto>> GetGovernoratesAsync();

        Task<GovernorateReadDto> GetGovernorateByIdAsync(int governorateId);

        Task PostGovernorateAsync(GovernorateCreateDto governorateCreateDto);

        Task UpdateGovernorateAsync(int governorateId, GovernorateUpdateDto governorateUpdateDto);

        Task DeleteGovernorateAsync(int governorateId);
    }
}
