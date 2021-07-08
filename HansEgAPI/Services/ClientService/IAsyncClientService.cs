using HansEgAPI.Dtos.ClientDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HansEgAPI.Services.ClientService
{
    public interface IAsyncClientService
    {
        Task<List<ClientReadDto>> GetClientsAsync();

        Task<ClientReadDto> GetClientByIdAsync(int clientId);

        Task PostClientAsync(ClientCreateDto clientCreateDto);

        Task UpdateClientAsync(ClientReadDto clientReadDto, ClientUpdateDto clientUpdateDto);

        Task DeleteClientAsync(int clientId);
    }
}
