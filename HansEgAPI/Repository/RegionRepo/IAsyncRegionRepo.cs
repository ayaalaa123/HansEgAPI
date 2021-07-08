using HansEgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository
{
    public interface IAsyncRegionRepo 
    {
        Task<bool> SaveChanges();

        Task<List<Region>> GetRegions();

        Task<List<Region>> GetGovernorateRegions(int governorateId);

        Task<Region> GetRegionById(int regionId);

        void CreateRegion(Region region);

        void UpdateRegion(Region region);

        void DeleteRegion(Region region);
    }
}
