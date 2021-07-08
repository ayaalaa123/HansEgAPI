using HansEgAPI.Data;
using HansEgAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository.OrderRepo
{
    public class SqlAsyncOrderRepo : IAsyncOrderRepo
    {
        private readonly HansContext _context;

        public SqlAsyncOrderRepo(HansContext context)
        {
            _context = context;
        }

        public async void CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders.Include("Region.Governorate").Include("Client").FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.Include("Region.Governorate").Include("Client").ToListAsync();
        }

        public async Task<List<Order>> GetRegionOrders(int regionId)
        {
            return await _context.Orders.Include("Region.Governorate").Where(r => r.RegionId == regionId).ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateOrder(Order order)
        {
            // doesn't need any implementation cause autoMapper does
        }
    }
}
