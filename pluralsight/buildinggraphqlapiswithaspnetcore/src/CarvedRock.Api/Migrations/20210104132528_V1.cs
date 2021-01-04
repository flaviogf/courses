using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarvedRock.Api.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    IntroducedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    PhotoFileName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[] { 1, "Use these sturdy shoes to pass any mountain range with ease.", new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 558, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, -3, 0, 0, 0)), "Mountain Walkers", "shutterstock_66842440.jpg", 219.5m, 4, 12, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[] { 2, "For your everyday marches in the army.", new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7847), new TimeSpan(0, -3, 0, 0, 0)), "Army Slippers", "shutterstock_222721876.jpg", 125.9m, 3, 56, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[] { 3, "This backpack can survive any tornado.", new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7884), new TimeSpan(0, -3, 0, 0, 0)), "Backpack Deluxe", "shutterstock_6170527.jpg", 199.99m, 5, 66, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[] { 4, "Anything you need to climb the mount Everest.", new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, -3, 0, 0, 0)), "Climbing Kit", "shutterstock_48040747.jpg", 299.5m, 5, 3, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[] { 5, "Simply the fastest kayak on earth and beyond for 2 persons.", new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, -3, 0, 0, 0)), "Blue Racer", "shutterstock_441989509.jpg", 350m, 5, 8, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[] { 6, "One person kayak with hyper boost button.", new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, -3, 0, 0, 0)), "Orange Demon", "shutterstock_495259978.jpg", 450m, 2, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
