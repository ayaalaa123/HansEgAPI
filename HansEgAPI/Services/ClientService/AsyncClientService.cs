using AutoMapper;
using HansEgAPI.Dtos.ClientDtos;
using HansEgAPI.Models;
using HansEgAPI.Repository;
using HansEgAPI.Repository.ClientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.ClientService
{
    public class AsyncClientService : IAsyncClientService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncClientRepo _repo;

        public AsyncClientService(IMapper mapper, IAsyncClientRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task DeleteClientAsync(int clientId)
        {
            var clientFromRepo = await _repo.GetClientById(clientId);

            if (clientFromRepo == null)
                throw new ArgumentNullException(nameof(clientFromRepo));

            _repo.DeleteClient(clientFromRepo);

            await _repo.SaveChanges();
        }

        public async Task<ClientReadDto> GetClientByIdAsync(int clientId)
        {
            var clientFromRepo = await _repo.GetClientById(clientId);

            return _mapper.Map<ClientReadDto>(clientFromRepo);
        }

        public async Task<List<ClientReadDto>> GetClientsAsync()
        {
            var clientsFromRepo = await _repo.GetClients();

            return _mapper.Map<List<ClientReadDto>>(clientsFromRepo);
        }

        public async Task PostClientAsync(ClientCreateDto clientCreateDto)
        {
            var clinet = _mapper.Map<Client>(clientCreateDto);

            _repo.CreateClient(clinet);

            await _repo.SaveChanges();
        }

        public async Task UpdateClientAsync(ClientReadDto clientReadDto, ClientUpdateDto clientUpdateDto)
        {
            var clientFromRepo = await _repo.GetClientById(clientReadDto.ClientId);

            _mapper.Map(clientUpdateDto, clientFromRepo);

            await _repo.SaveChanges();
        }
    }
}
