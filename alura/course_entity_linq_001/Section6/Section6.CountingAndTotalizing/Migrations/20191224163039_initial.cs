using Microsoft.EntityFrameworkCore.Migrations;

namespace Section6.CountingAndTotalizing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Clay Block" },
                    { 2, "Jerome Morissette" },
                    { 3, "Victoria McDermott" },
                    { 4, "Travis Mills" },
                    { 5, "Gerald Dicki" },
                    { 6, "Jan Pagac" },
                    { 7, "Shannon Runolfsson" },
                    { 8, "Stacy Gorczany" },
                    { 9, "Adam Boyer" },
                    { 10, "Sadie Senger" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Title" },
                values: new object[,]
                {
                    { 6, 1, "Nulla doloribus odio commodi aut et porro rerum dignissimos." },
                    { 10, 1, "Sed dolor consequatur voluptas itaque vel unde." },
                    { 8, 4, "Veniam eius provident nihil impedit ex aliquam et." },
                    { 9, 5, "Nam corporis dolorem quasi dolores odio." },
                    { 1, 7, "Dolorem animi et minus tempora error." },
                    { 2, 7, "Officiis sit eum nemo magnam occaecati." },
                    { 4, 9, "Et perspiciatis accusamus." },
                    { 5, 9, "Asperiores voluptatem ab quaerat." },
                    { 7, 9, "Voluptatem perspiciatis eveniet earum dolores." },
                    { 3, 10, "Et error et ut." }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "Name", "Price" },
                values: new object[,]
                {
                    { 10, 10, "Ipsam doloribus aliquid delectus et maiores facilis qui.", 14315 },
                    { 8, 8, "Optio beatae nihil aut ratione illo ipsum.", 11044 },
                    { 4, 9, "Accusantium debitis occaecati veniam sequi.", 16662 },
                    { 9, 9, "Repellat excepturi sequi ipsum aliquid enim quia nam repellat laudantium.", 16165 },
                    { 7, 2, "Ea modi qui illum sed enim deleniti qui eum.", 15493 },
                    { 2, 4, "Odit et esse.", 12235 },
                    { 1, 5, "Tempora voluptas rerum tempora dolores laboriosam ea aut nam suscipit.", 12792 },
                    { 3, 5, "Dolore velit qui aut.", 14080 },
                    { 5, 5, "Doloremque ut odio ipsum ipsum delectus.", 10963 },
                    { 6, 5, "Odit voluptatibus aliquam quia tempore similique ut dolorum sequi.", 17941 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "Quantity", "TrackId" },
                values: new object[,]
                {
                    { 5, 10285, 167, 10 },
                    { 6, 12781, 116, 10 },
                    { 7, 10839, 118, 8 },
                    { 8, 14528, 108, 8 },
                    { 9, 17971, 199, 4 },
                    { 2, 14712, 137, 9 },
                    { 1, 15960, 142, 7 },
                    { 4, 12271, 141, 7 },
                    { 3, 10105, 124, 2 },
                    { 10, 17980, 152, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TrackId",
                table: "Items",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
