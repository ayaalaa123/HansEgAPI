using HansEgAPI.Data;
using HansEgAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository.ClientRepo
{
    public class SqlAsyncClientRepo : IAsyncClientRepo
    {
        private readonly HansContext _context;

        public SqlAsyncClientRepo(HansContext context)
        {
            _context = context;
        }

        public async void CreateClient(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public void DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
        }

        public async Task<Client> GetClientById(int clientId)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task<List<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateClient(Client client)
        {
            // doesn't need any implementation cause autoMapper does
        }
    }
}
