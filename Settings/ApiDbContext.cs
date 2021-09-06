using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingApi.Models;
using ParkingApi.Models.Config;
using ParkingApi.Settings;
using System;

namespace ParkingApi.Settings
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Valet> Valets { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Session> Sessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new ValetConfig());
            modelBuilder.ApplyConfiguration(new ParkingConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new SessionConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}


