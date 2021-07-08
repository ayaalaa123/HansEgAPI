using HansEgAPI.Dtos.ClientDtos;
using HansEgAPI.Services.ClientService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;

namespace HansEgAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IAsyncClientService _service;

        public ClientsController(IAsyncClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientsAsync()
        {
            var clientsReadDtoFromService = await _service.GetClientsAsync();

            return Ok(clientsReadDtoFromService);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClientByIdAsync(int clientId)
        {
            if (clientId == 0)
                return BadRequest();

            var clinetReadDtoFromService = await _service.GetClientByIdAsync(clientId);

            if (clinetReadDtoFromService == null)
                return StatusCode((int)ClientReadDto.GetNotFoundErrorModel.StatusCode, ClientReadDto.GetNotFoundErrorModel);

            return Ok(clinetReadDtoFromService);
        }

        [HttpPost]
        public async Task<IActionResult> PostClientAsync([FromBody] ClientCreateDto clientCreateDto)
        {
            if (clientCreateDto == null)
                return StatusCode((int)ClientCreateDto.GetCanNotBeNullErrorModel.StatusCode, ClientCreateDto.GetCanNotBeNullErrorModel);

            await _service.PostClientAsync(clientCreateDto);

            return StatusCode((int)HttpStatusCode.Created, clientCreateDto);
        }

        [HttpPut("{clinetId}")]
        public async Task<IActionResult> UpdateClientAsync(int clinetId, [FromBody] ClientUpdateDto clientUpdateDto)
        {
            if (clinetId == 0 || clientUpdateDto == null)
                return BadRequest();

            var clientReadDtoFromService = await _service.GetClientByIdAsync(clinetId);

            if (clientReadDtoFromService == null)
          
            await _service.UpdateClientAsync(clientReadDtoFromService, clientUpdateDto);

            return StatusCode((int)HttpStatusCode.OK, clientUpdateDto);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClientAsync(int clientId)
        {
            if (clientId == 0)
                return BadRequest();

            var clientReadDtoFromService = await _service.GetClientByIdAsync(clientId);

            if (clientReadDtoFromService == null)
                return StatusCode((int)ClientReadDto.GetNotFoundErrorModel.StatusCode, ClientReadDto.GetNotFoundErrorModel);

            await _service.DeleteClientAsync(clientId);

            return NoContent();
        }

    }
}
