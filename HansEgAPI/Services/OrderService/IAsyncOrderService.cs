using HansEgAPI.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Services.OrderService
{
    public interface IAsyncOrderService
    {
        Task<List<OrderReadDto>> GetOrdersAsync();

        Task<OrderReadDto> GetOrderByIdAsync(int orderId);

        Task<List<OrderReadDto>> GetRegionOrdersAsync(int regionId);

        Task PostOrderAsync(OrderCreateDto orderCreateDto);

        Task UpdateOrderAsync(OrderReadDto orderReadDto, OrderUpdateDto orderUpdateDto);

        Task DeleteOrderAsync(int orderId);
    }
}
