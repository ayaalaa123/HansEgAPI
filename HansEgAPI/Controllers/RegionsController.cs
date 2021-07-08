using HansEgAPI.Dtos.RegionDtos;
using HansEgAPI.Services.RegionService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HansEgAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IAsyncRegionService _service;

        public RegionsController(IAsyncRegionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegionsAsync()
        {
            var regionsReadDtoFromService = await _service.GetRegionsAsync();

            return Ok(regionsReadDtoFromService);
        }

        [HttpGet]
        [Route("/api/GovernorateRegions/{governorateId}")]
        public async Task<IActionResult> GetGovernorateRegionsAsync(int governorateId)
        {
            if (governorateId == 0)
                return BadRequest();
         
            var regionsReadDtoFromService = await _service.GetGovernorateRegionsAsync(governorateId);

            if (regionsReadDtoFromService.Count == 0)
                return NotFound();

            return Ok(regionsReadDtoFromService);
        }

        [HttpGet("{regionId}")]
        public async Task<IActionResult> GetRegionByIdAsync(int regionId)
        {
            if (regionId == 0)
                return BadRequest();

            var regionReadDtoFromService = await _service.GetRegionByIdAsync(regionId);

            if (regionReadDtoFromService == null)
                return NotFound();

            return Ok(regionReadDtoFromService);
        }

        [HttpPost]
        public async Task<IActionResult> PostRegionAsync([FromBody] RegionCreateDto regionCreateDto)
        {
            if (regionCreateDto == null)
                return BadRequest();

            await _service.PostRegionAsync(regionCreateDto);

            return NoContent();
        }

        [HttpPut("{regionId}")]
        public async Task<IActionResult> UpdateRegionAsync(int regionId, [FromBody] RegionUpdateDto regionUpdateDto)
        {
            if (regionId == 0 || regionUpdateDto == null)
                return BadRequest();

            var regionReadDtoFromService = await _service.GetRegionByIdAsync(regionId);

            if (regionReadDtoFromService == null)
                return NotFound();

            await _service.UpdateRegionAsync(regionId, regionUpdateDto);

            return NoContent();
        }

        [HttpDelete("{regionId}")]
        public async Task<IActionResult> DeleteGovernorateAsync(int regionId)
        {
            if (regionId == 0)
                return BadRequest();

            var regionReadDtoFromService = await _service.GetRegionByIdAsync(regionId);

            if (regionReadDtoFromService == null)
                return NotFound();

            await _service.DeleteRegionAsync(regionId);

            return NoContent();
        }
    }
}
