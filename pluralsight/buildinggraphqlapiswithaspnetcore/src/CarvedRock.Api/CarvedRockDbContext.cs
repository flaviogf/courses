using System;
using CarvedRock.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api
{
    public class CarvedRockDbContext : DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Mountain Walkers",
                    Description = "Use these sturdy shoes to pass any mountain range with ease.",
                    Price = 219.5m,
                    Rating = 4,
                    Type = EProductType.Boots,
                    Stock = 12,
                    PhotoFileName = "shutterstock_66842440.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 2,
                    Name = "Army Slippers",
                    Description = "For your everyday marches in the army.",
                    Price = 125.9m,
                    Rating = 3,
                    Type = EProductType.Boots,
                    Stock = 56,
                    PhotoFileName = "shutterstock_222721876.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 3,
                    Name = "Backpack Deluxe",
                    Description = "This backpack can survive any tornado.",
                    Price = 199.99m,
                    Rating = 5,
                    Type = EProductType.ClimbingGear,
                    Stock = 66,
                    PhotoFileName = "shutterstock_6170527.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 4,
                    Name = "Climbing Kit",
                    Description = "Anything you need to climb the mount Everest.",
                    Price = 299.5m,
                    Rating = 5,
                    Type = EProductType.ClimbingGear,
                    Stock = 3,
                    PhotoFileName = "shutterstock_48040747.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 5,
                    Name = "Blue Racer",
                    Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
                    Price = 350m,
                    Rating = 5,
                    Type = EProductType.Kayaks,
                    Stock = 8,
                    PhotoFileName = "shutterstock_441989509.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 6,
                    Name = "Orange Demon",
                    Description = "One person kayak with hyper boost button.",
                    Price = 450m,
                    Rating = 2,
                    Type = EProductType.Kayaks,
                    Stock = 1,
                    PhotoFileName = "shutterstock_495259978.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }
            );
        }
    }
}
