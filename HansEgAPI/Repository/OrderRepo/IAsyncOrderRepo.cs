using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository.OrderRepo
{
    public interface IAsyncOrderRepo
    {
        Task<bool> SaveChanges();

        Task<List<Order>> GetOrders();

        Task<Order> GetOrderById(int orderId);

        Task<List<Order>> GetRegionOrders(int regionId);

        void CreateOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(Order order);
    }
}
