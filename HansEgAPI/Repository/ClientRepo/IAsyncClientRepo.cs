using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository.ClientRepo
{
    public interface IAsyncClientRepo
    {
        Task<bool> SaveChanges();

        Task<List<Client>> GetClients();

        Task<Client> GetClientById(int clientId);

        void CreateClient(Client client);

        void UpdateClient(Client client);

        void DeleteClient(Client client);
    }
}
