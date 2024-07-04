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
        public DbSet<ZooAnimal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base class's method

            // Unique constraint on ZooAnimal
            modelBuilder.Entity<ZooAnimal>()
                .HasIndex(za => new { za.Name, za.ZooId })
                .IsUnique();

            SeedData(modelBuilder); // Call the seed data method
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var createdBy = "admin@admin.com";
            var createdDate = DateTime.UtcNow;

            // Seed Zoos
            modelBuilder.Entity<Zoo>().HasData(
                new Zoo
                {
                    Id = 1,
                    Name = "CityA Zoo",
                    MainAttraction = "Lions",
                    TicketCost = 25.0,
                    ChildTicket = 15.0,
                    SeniorTicket = 20.0,
                    IsActive = true,
                    CreatedBy = createdBy,
                    CreatedDate = createdDate
                },
                new Zoo
                {
                    Id = 2,
                    Name = "CityB Zoo",
                    MainAttraction = "Tigers",
                    TicketCost = 30.0,
                    ChildTicket = 18.0,
                    SeniorTicket = 25.0,
                    IsActive = true,
                    CreatedBy = createdBy,
                    CreatedDate = createdDate
                }
            );

            // Seed Zoo Addresses
            modelBuilder.Entity<ZooAddress>().HasData(
                new ZooAddress
                {
                    Id = 1,
                    Street1 = "123 Zoo St",
                    City = "CityA",
                    State = "StateA",
                    Zip = "12345",
                    CreatedDate = createdDate,
                    CreatedBy = createdBy,
                    IsActive = true,
                    ZooId = 1
                },
                new ZooAddress
                {
                    Id = 2,
                    Street1 = "456 Zoo Ln",
                    City = "CityB",
                    State = "StateB",
                    Zip = "67890",
                    CreatedDate = createdDate,
                    CreatedBy = createdBy,
                    IsActive = true,
                    ZooId = 2
                }
            );

            // Seed Open Days Hours for Zoo 1
            modelBuilder.Entity<OpenDaysHours>().HasData(
                new OpenDaysHours { Id = 1, DayOfWeek = "Monday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 1 },
                new OpenDaysHours { Id = 2, DayOfWeek = "Tuesday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 1 },
                new OpenDaysHours { Id = 3, DayOfWeek = "Wednesday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 1 },
                new OpenDaysHours { Id = 4, DayOfWeek = "Thursday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 1 },
                new OpenDaysHours { Id = 5, DayOfWeek = "Friday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 1 },
                new OpenDaysHours { Id = 6, DayOfWeek = "Saturday", IsOpen = true, OpenTime = new TimeOnly(10, 0), CloseTime = new TimeOnly(18, 0), ZooId = 1 },
                new OpenDaysHours { Id = 7, DayOfWeek = "Sunday", IsOpen = true, OpenTime = new TimeOnly(10, 0), CloseTime = new TimeOnly(18, 0), ZooId = 1 }
            );

            // Seed Open Days Hours for Zoo 2
            modelBuilder.Entity<OpenDaysHours>().HasData(
                new OpenDaysHours { Id = 8, DayOfWeek = "Monday", IsOpen = true, OpenTime = new TimeOnly(8, 0), CloseTime = new TimeOnly(16, 0), ZooId = 2 },
                new OpenDaysHours { Id = 9, DayOfWeek = "Tuesday", IsOpen = true, OpenTime = new TimeOnly(8, 0), CloseTime = new TimeOnly(16, 0), ZooId = 2 },
                new OpenDaysHours { Id = 10, DayOfWeek = "Wednesday", IsOpen = true, OpenTime = new TimeOnly(8, 0), CloseTime = new TimeOnly(16, 0), ZooId = 2 },
                new OpenDaysHours { Id = 11, DayOfWeek = "Thursday", IsOpen = true, OpenTime = new TimeOnly(8, 0), CloseTime = new TimeOnly(16, 0), ZooId = 2 },
                new OpenDaysHours { Id = 12, DayOfWeek = "Friday", IsOpen = true, OpenTime = new TimeOnly(8, 0), CloseTime = new TimeOnly(16, 0), ZooId = 2 },
                new OpenDaysHours { Id = 13, DayOfWeek = "Saturday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 2 },
                new OpenDaysHours { Id = 14, DayOfWeek = "Sunday", IsOpen = true, OpenTime = new TimeOnly(9, 0), CloseTime = new TimeOnly(17, 0), ZooId = 2 }
            );

            // Seed Zoo Animals for Zoo 1
            modelBuilder.Entity<ZooAnimal>().HasData(
                new ZooAnimal { Id = 1, Name = "Lion", FemaleNum = 3, MaleNum = 2, TotalNum = 5, IsActive = true, Habitat = "Savannah", ZooId = 1, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 2, Name = "Tiger", FemaleNum = 2, MaleNum = 3, TotalNum = 5, IsActive = true, Habitat = "Forest", ZooId = 1, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 3, Name = "Elephant", FemaleNum = 4, MaleNum = 1, TotalNum = 5, IsActive = true, Habitat = "Grassland", ZooId = 1, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 4, Name = "Giraffe", FemaleNum = 2, MaleNum = 2, TotalNum = 4, IsActive = true, Habitat = "Savannah", ZooId = 1, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 5, Name = "Panda", FemaleNum = 2, MaleNum = 2, TotalNum = 4, IsActive = true, Habitat = "Forest", ZooId = 1, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 6, Name = "Penguin", FemaleNum = 5, MaleNum = 5, TotalNum = 10, IsActive = true, Habitat = "Arctic", ZooId = 1, CreatedDate = createdDate, CreatedBy = createdBy }
            );

            // Seed Zoo Animals for Zoo 2
            modelBuilder.Entity<ZooAnimal>().HasData(
                new ZooAnimal { Id = 7, Name = "Lion", FemaleNum = 3, MaleNum = 2, TotalNum = 5, IsActive = true, Habitat = "Savannah", ZooId = 2, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 8, Name = "Tiger", FemaleNum = 2, MaleNum = 3, TotalNum = 5, IsActive = true, Habitat = "Forest", ZooId = 2, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 9, Name = "Elephant", FemaleNum = 4, MaleNum = 1, TotalNum = 5, IsActive = true, Habitat = "Grassland", ZooId = 2, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 10, Name = "Giraffe", FemaleNum = 2, MaleNum = 2, TotalNum = 4, IsActive = true, Habitat = "Savannah", ZooId = 2, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 11, Name = "Panda", FemaleNum = 2, MaleNum = 2, TotalNum = 4, IsActive = true, Habitat = "Forest", ZooId = 2, CreatedDate = createdDate, CreatedBy = createdBy },
                new ZooAnimal { Id = 12, Name = "Penguin", FemaleNum = 5, MaleNum = 5, TotalNum = 10, IsActive = true, Habitat = "Arctic", ZooId = 2, CreatedDate = createdDate, CreatedBy = createdBy }
            );
        }

    }
}
