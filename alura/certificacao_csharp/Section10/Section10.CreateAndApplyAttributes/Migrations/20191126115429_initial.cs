using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Section10.CreateAndApplyAttributes.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "Date" },
                values: new object[] { 1, 1000, new DateTime(2019, 11, 21, 8, 54, 29, 183, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "Date" },
                values: new object[] { 2, 10000, new DateTime(2019, 11, 26, 8, 54, 29, 187, DateTimeKind.Local).AddTicks(2554) });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "Date" },
                values: new object[] { 3, 100000, new DateTime(2019, 12, 1, 8, 54, 29, 187, DateTimeKind.Local).AddTicks(2601) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
