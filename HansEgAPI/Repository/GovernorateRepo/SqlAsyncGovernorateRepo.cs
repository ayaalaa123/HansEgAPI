using HansEgAPI.Data;
using HansEgAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Repository
{
    public class SqlAsyncGovernorateRepo : IAsyncGovernorateRepo
    {
        private readonly HansContext _context;

        public SqlAsyncGovernorateRepo(HansContext context)
        {
            _context = context;
        }

        public async void CreateGovernorate(Governorate governorate)
        {
            await _context.Governorates.AddAsync(governorate);
        }

        public void DeleteGovernorate(Governorate governorate)
        {
            _context.Governorates.Remove(governorate);
        }

        public async Task<Governorate> GetGovernorateById(int governorateId)
        {
            return await _context.Governorates.FirstOrDefaultAsync(g => g.GovernorateId== governorateId);
        }

        public async Task<List<Governorate>> GetGovernorates()
        {
            return await _context.Governorates.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateGovernorate(Governorate governorate)
        {
            // doesn't need any implementation cause autoMapper does
        }
    }
}
