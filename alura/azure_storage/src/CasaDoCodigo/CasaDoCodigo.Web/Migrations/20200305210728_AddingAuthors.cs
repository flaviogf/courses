using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDoCodigo.Web.Migrations
{
    public partial class AddingAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("be69294b-e004-4f44-bdf9-16e0f30b09bc"), "Paulo Silveira" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("259c153a-d56f-484b-bc9b-110c8e90b8d3"), "Guilherme Silveira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("259c153a-d56f-484b-bc9b-110c8e90b8d3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("be69294b-e004-4f44-bdf9-16e0f30b09bc"));
        }
    }
}
