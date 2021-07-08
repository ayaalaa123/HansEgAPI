using AutoMapper;
using HansEgAPI.Dtos.ClientDtos;
using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Profiles
{
    public class ClientProfiles : Profile
    {
        public ClientProfiles()
        {
            CreateMap<Client, ClientReadDto>();

            CreateMap<ClientReadDto, Client>();

            CreateMap<Task<List<Client>>, Task<List<ClientReadDto>>>();

            CreateMap<Task<List<ClientReadDto>>, Task<List<Client>>>();
            
            CreateMap<Client, ClientUpdateDto>();

            CreateMap<ClientUpdateDto, Client>();

            CreateMap<Task<List<Client>>, Task<List<ClientUpdateDto>>>();

            CreateMap<Task<List<ClientUpdateDto>>, Task<List<Client>>>();
            
            CreateMap<Client, ClientCreateDto>();

            CreateMap<ClientCreateDto, Client>();

            CreateMap<Task<List<Client>>, Task<List<ClientCreateDto>>>();

            CreateMap<Task<List<ClientCreateDto>>, Task<List<Client>>>();
        }
    }
}
