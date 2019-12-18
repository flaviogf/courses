using Microsoft.EntityFrameworkCore.Migrations;

namespace Section3.LinqToEntities.Migrations
{
    public partial class insert_track_sweet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "GenreId", "Name" },
                values: new object[] { 1, 1, "Sweet Child O' Mine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
