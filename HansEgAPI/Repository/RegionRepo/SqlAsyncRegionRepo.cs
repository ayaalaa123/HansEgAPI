using HansEgAPI.Data;
using HansEgAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository
{
    public class SqlAsyncRegionRepo : IAsyncRegionRepo
    {
        private readonly HansContext _context;

        public SqlAsyncRegionRepo(HansContext context)
        {
            _context = context;
        }

        public async void CreateRegion(Region region)
        {
            await _context.Regions.AddAsync(region);
        }

        public void DeleteRegion(Region region)
        {
            _context.Regions.Remove(region);
        }

        public async Task<List<Region>> GetGovernorateRegions(int governorateId)
        {
            return await _context.Regions.Include("Governorate").Where(g => g.GovernorateId == governorateId).ToListAsync();
        }

        public async Task<Region> GetRegionById(int regionId)
        {
            return await _context.Regions.Include("Governorate").FirstOrDefaultAsync(r => r.RegionId == regionId);
        }

        public async Task<List<Region>> GetRegions()
        {
            return await _context.Regions.Include("Governorate").ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateRegion(Region region)
        {
            // doesn't need any implementation cause autoMapper does
        }
    }
}
