using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GloboTicket.Services.EventCatalog.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), "Concerts" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), "Musicals" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"), "Plays" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"), "John Egbert", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTimeOffset(new DateTime(2021, 8, 21, 11, 54, 11, 393, DateTimeKind.Unspecified).AddTicks(7403), new TimeSpan(0, -3, 0, 0, 0)), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "/img/banjo.jpg", "John Egbert Live", 65 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"), "Michael Johnson", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTimeOffset(new DateTime(2021, 11, 21, 11, 54, 11, 397, DateTimeKind.Unspecified).AddTicks(8619), new TimeSpan(0, -3, 0, 0, 0)), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "/img/michael.jpg", "The State of Affairs: Michael Live!", 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"), "Nick Sailor", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), new DateTimeOffset(new DateTime(2021, 10, 21, 11, 54, 11, 397, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, -3, 0, 0, 0)), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "/img/musical.jpg", "To the Moon and Back", 135 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
