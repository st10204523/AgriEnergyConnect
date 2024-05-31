using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriEnergyConnect.Models
{
    public class AgriEnergyConnectDbContext : DbContext
    {
        public AgriEnergyConnectDbContext()
        {
        }

        public AgriEnergyConnectDbContext(DbContextOptions<AgriEnergyConnectDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public object Farmers { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}