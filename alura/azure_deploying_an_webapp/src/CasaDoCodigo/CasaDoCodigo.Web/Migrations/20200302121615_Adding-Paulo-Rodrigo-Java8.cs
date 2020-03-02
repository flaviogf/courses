using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDoCodigo.Web.Migrations
{
    public partial class AddingPauloRodrigoJava8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3a50a2d9-5991-4679-b4bd-c5940e7ad86c"), "Paulo Silveira" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5a2f806c-9607-4430-9195-bc562756dbc0"), "Rodrigo Turini" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4937c3eb-e645-4fea-8abe-59a881a41083"), "Java 8 Prático" });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { new Guid("3a50a2d9-5991-4679-b4bd-c5940e7ad86c"), new Guid("4937c3eb-e645-4fea-8abe-59a881a41083") });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { new Guid("5a2f806c-9607-4430-9195-bc562756dbc0"), new Guid("4937c3eb-e645-4fea-8abe-59a881a41083") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("3a50a2d9-5991-4679-b4bd-c5940e7ad86c"), new Guid("4937c3eb-e645-4fea-8abe-59a881a41083") });

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5a2f806c-9607-4430-9195-bc562756dbc0"), new Guid("4937c3eb-e645-4fea-8abe-59a881a41083") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3a50a2d9-5991-4679-b4bd-c5940e7ad86c"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5a2f806c-9607-4430-9195-bc562756dbc0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4937c3eb-e645-4fea-8abe-59a881a41083"));
        }
    }
}
