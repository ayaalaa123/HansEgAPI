using HansEgAPI.Dtos;
using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository
{
    public interface IAsyncGovernorateRepo 
    {
        Task<bool> SaveChanges();

        Task<List<Governorate>> GetGovernorates();

        Task<Governorate> GetGovernorateById(int governorateId);

        void CreateGovernorate(Governorate governorate);

        void UpdateGovernorate(Governorate governorate);

        void DeleteGovernorate(Governorate governorate);
    }
}
