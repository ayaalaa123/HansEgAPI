using HansEgAPI.Dtos.GovernorateDtos;
using HansEgAPI.Services.GovernorateService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HansEgAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GovernoratesController : ControllerBase
    {
        private readonly IAsyncGovernorateService _service;

        public GovernoratesController(IAsyncGovernorateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGovernoratesAsync()
        {
            var governoratesReadDtoFromService = await _service.GetGovernoratesAsync();

            return Ok(governoratesReadDtoFromService);
        }

        [HttpGet("{governorateId}")]
        public async Task<IActionResult> GetGovernorateByIdAsync(int governorateId)
        {
            if (governorateId == 0)
                return BadRequest();

            var governorateReadDtoFromService = await _service.GetGovernorateByIdAsync(governorateId);

            if (governorateReadDtoFromService == null)
                return NotFound();

            return Ok(governorateReadDtoFromService);
        }

        [HttpPost]
        public async Task<IActionResult> PostGovernorateAsync([FromBody] GovernorateCreateDto governorateCreateDto)
        {
            if (governorateCreateDto == null)
                return BadRequest();

            await _service.PostGovernorateAsync(governorateCreateDto);

            return NoContent();
        }

        [HttpPut("{governorateId}")]
        public async Task<IActionResult> UpdateGovernorateAsync(int governorateId, [FromBody] GovernorateUpdateDto governorateUpdateDto)
        {
            if (governorateId == 0 || governorateUpdateDto == null)
                return BadRequest();

            var governorateReadDtoFromService = await _service.GetGovernorateByIdAsync(governorateId);

            if (governorateReadDtoFromService == null)
                return NotFound();

            await _service.UpdateGovernorateAsync(governorateId, governorateUpdateDto);

            return NoContent();
        }

        [HttpDelete("{governorateId}")]
        public async Task<IActionResult> DeleteGovernorate(int governorateId)
        {
            if (governorateId == 0)
                return BadRequest();

            var governorateReadDtoFromService = await _service.GetGovernorateByIdAsync(governorateId);

            if (governorateReadDtoFromService == null)
                return NotFound();

            await _service.DeleteGovernorateAsync(governorateId);

            return NoContent();
        }
    }
}