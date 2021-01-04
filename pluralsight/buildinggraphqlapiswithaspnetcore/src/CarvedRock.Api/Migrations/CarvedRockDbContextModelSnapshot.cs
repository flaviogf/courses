﻿// <auto-generated />
using System;
using CarvedRock.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarvedRock.Api.Migrations
{
    [DbContext(typeof(CarvedRockDbContext))]
    partial class CarvedRockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CarvedRock.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("IntroducedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Use these sturdy shoes to pass any mountain range with ease.",
                            IntroducedAt = new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 558, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, -3, 0, 0, 0)),
                            Name = "Mountain Walkers",
                            PhotoFileName = "shutterstock_66842440.jpg",
                            Price = 219.5m,
                            Rating = 4,
                            Stock = 12,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "For your everyday marches in the army.",
                            IntroducedAt = new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7847), new TimeSpan(0, -3, 0, 0, 0)),
                            Name = "Army Slippers",
                            PhotoFileName = "shutterstock_222721876.jpg",
                            Price = 125.9m,
                            Rating = 3,
                            Stock = 56,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "This backpack can survive any tornado.",
                            IntroducedAt = new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7884), new TimeSpan(0, -3, 0, 0, 0)),
                            Name = "Backpack Deluxe",
                            PhotoFileName = "shutterstock_6170527.jpg",
                            Price = 199.99m,
                            Rating = 5,
                            Stock = 66,
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Anything you need to climb the mount Everest.",
                            IntroducedAt = new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, -3, 0, 0, 0)),
                            Name = "Climbing Kit",
                            PhotoFileName = "shutterstock_48040747.jpg",
                            Price = 299.5m,
                            Rating = 5,
                            Stock = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
                            IntroducedAt = new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, -3, 0, 0, 0)),
                            Name = "Blue Racer",
                            PhotoFileName = "shutterstock_441989509.jpg",
                            Price = 350m,
                            Rating = 5,
                            Stock = 8,
                            Type = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "One person kayak with hyper boost button.",
                            IntroducedAt = new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, -3, 0, 0, 0)),
                            Name = "Orange Demon",
                            PhotoFileName = "shutterstock_495259978.jpg",
                            Price = 450m,
                            Rating = 2,
                            Stock = 1,
                            Type = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
