using HansEgAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansEgAPI.Data
{
    public class HansContext : DbContext
    {
        public HansContext(DbContextOptions<HansContext> opt) : base(opt)
        {
        }

        public DbSet<Governorate> Governorates { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
