using AutoMapper;
using HansEgAPI.Dtos.OrderDtos;
using HansEgAPI.Models;
using HansEgAPI.Repository;
using HansEgAPI.Repository.OrderRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.OrderService
{
    public class AsyncOrderService : IAsyncOrderService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncOrderRepo _repo;
        private readonly IAsyncRegionRepo _regionRepo;

        public AsyncOrderService(IMapper mapper, IAsyncOrderRepo repo, IAsyncRegionRepo regionRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _regionRepo = regionRepo;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var orderFromRepo = await _repo.GetOrderById(orderId);

            if (orderFromRepo == null)
                throw new ArgumentNullException(nameof(orderFromRepo));

            _repo.DeleteOrder(orderFromRepo);

            await _repo.SaveChanges();
        }

        public async Task<OrderReadDto> GetOrderByIdAsync(int orderId)
        {
            var orderFromRepo = await _repo.GetOrderById(orderId);

            return _mapper.Map<OrderReadDto>(orderFromRepo);
        }

        public async Task<List<OrderReadDto>> GetOrdersAsync()
        {
            var ordersFromRepo = await _repo.GetOrders();

            return _mapper.Map<List<OrderReadDto>>(ordersFromRepo);
        }

        public async Task<List<OrderReadDto>> GetRegionOrdersAsync(int regionId)
        {
            var regionFromRepo = await _regionRepo.GetRegionById(regionId);

            if (regionFromRepo == null)
                return new List<OrderReadDto>();

            var regionOrdersFromRepo = await _repo.GetRegionOrders(regionId);
            
            return  _mapper.Map<List<OrderReadDto>>(regionOrdersFromRepo);
        }

        public async Task PostOrderAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);

            _repo.CreateOrder(order);

            await _repo.SaveChanges();
        }

        public async Task UpdateOrderAsync(OrderReadDto orderReadDto, OrderUpdateDto orderUpdateDto)
        {
            var orderFromRepo = await _repo.GetOrderById(orderReadDto.OrderId);

            _mapper.Map(orderUpdateDto, orderFromRepo);

            await _repo.SaveChanges();
        } 
    }
}
