using AutoMapper;
using HansEgAPI.Dtos.OrderDtos;
using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Profiles
{
    public class OrderProfiles : Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderReadDto>();

            CreateMap<OrderReadDto, Order>();

            CreateMap<Task<List<Order>>, Task<List<OrderReadDto>>>();

            CreateMap<Task<List<OrderReadDto>>, Task<List<Order>>>();
            
            CreateMap<Order, OrderCreateDto>();

            CreateMap<OrderCreateDto, Order>();

            CreateMap<Task<List<Order>>, Task<List<OrderCreateDto>>>();

            CreateMap<Task<List<OrderCreateDto>>, Task<List<Order>>>();

            CreateMap<Order, OrderUpdateDto>();

            CreateMap<OrderUpdateDto, Order>();

            CreateMap<Task<List<Order>>, Task<List<OrderUpdateDto>>>();

            CreateMap<Task<List<OrderUpdateDto>>, Task<List<Order>>>();
        }
    }
}
