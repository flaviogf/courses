using Microsoft.EntityFrameworkCore.Migrations;

namespace Section5.OrderingQueries.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Emmett Kassulke" },
                    { 2, "Alyssa Legros" },
                    { 3, "Allison McDermott" },
                    { 4, "Madeline Deckow" },
                    { 5, "Rebecca Dibbert" },
                    { 6, "Candice Gaylord" },
                    { 7, "Bessie Gleason" },
                    { 8, "Helen Schinner" },
                    { 9, "Mindy Hoeger" },
                    { 10, "Gerard Berge" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Name" },
                values: new object[,]
                {
                    { 7, 2, "Hauck - Will" },
                    { 1, 3, "Jacobi, Gottlieb and Tillman" },
                    { 3, 4, "Bernier Inc" },
                    { 9, 4, "Wolf Inc" },
                    { 4, 5, "Weimann, Purdy and Beahan" },
                    { 10, 6, "Deckow - Auer" },
                    { 2, 9, "Bruen, Vandervort and Stoltenberg" },
                    { 6, 9, "Krajcik, Schneider and Pouros" },
                    { 8, 9, "Legros Group" },
                    { 5, 10, "Reichel, Casper and Ferry" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Trantow and Sons" },
                    { 10, 1, "Hickle - Emmerich" },
                    { 8, 3, "Bernier - Weissnat" },
                    { 6, 9, "Weber Inc" },
                    { 7, 4, "Bogisich, Homenick and Bernier" },
                    { 9, 4, "Schroeder - McCullough" },
                    { 3, 2, "Nolan Group" },
                    { 4, 2, "Becker Group" },
                    { 5, 6, "Bednar - Howe" },
                    { 2, 8, "Gerhold - Haag" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
