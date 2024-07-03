using ZooTracker.Models;
using ZooTracker.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {}
        

        public DbSet<JWTRefreshToken> JwtRefreshToken { get; set; }
        public DbSet<JwtBlacklistToken> JwtBlacklistToken { get; set; }
        public DbSet<EnterpriseLogging> EnterpriseLogging { get; set; }
        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<ZooAddress> Address { get; set; }
        public DbSet<OpenDaysHours> OpenDaysHours { get; set; }
        public DbSet<ZooAnimal> Animal {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base class's method

            modelBuilder.Entity<ZooAnimal>()
                .HasIndex(za => new { za.Name, za.ZooId })
                .IsUnique();
        }
    }
}
