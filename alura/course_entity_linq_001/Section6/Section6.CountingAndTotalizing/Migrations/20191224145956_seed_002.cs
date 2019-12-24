using Microsoft.EntityFrameworkCore.Migrations;

namespace Section6.CountingAndTotalizing.Migrations
{
    public partial class seed_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 2, "Harum ratione fugit aliquid." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 1, "Ut et id qui." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 7, "Explicabo sapiente alias omnis cumque dignissimos reiciendis in dolores culpa." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 9, "Voluptas reprehenderit aut vel ullam consequuntur sit." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 1, "In odio delectus." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 3, "Tenetur hic qui veritatis earum aut qui quibusdam porro placeat." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 1, "Rerum doloremque voluptate." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 7, "Illo excepturi provident excepturi minus aliquam est magni." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 1, "Qui et eligendi cupiditate." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 7, "Est corrupti doloremque rerum iusto quidem dolorum omnis ipsa." });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Christie Corkery");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jonathon McDermott");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dean VonRueden");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Kim McKenzie");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Flora Bogan");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Ian Rice");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Andres Boehm");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Louise Lebsack");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Tommie Abbott");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Ralph Krajcik");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 1, 106, 2 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 9, 110, 3 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 10, 162, 8 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 2, 131, 7 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 8, 155, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 7, 117, 5 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 6, 104, 7 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 5, 145, 6 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 4, 198, 8 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Quantity", "TrackId" },
                values: new object[] { 3, 122, 5 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Deserunt incidunt corrupti voluptatem.", 19814 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 4, "Eum qui corrupti laudantium modi eligendi qui non.", 17972 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 1, "Debitis accusantium tempora amet nemo sint perspiciatis autem.", 12378 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 9, "Saepe assumenda rem inventore quia dolores.", 11220 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 2, "Eligendi itaque delectus.", 15859 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Voluptatem ut suscipit eius molestias.", 18242 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 5, "Neque est ut.", 19230 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 10, "Est architecto necessitatibus corrupti delectus natus quisquam.", 11640 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 1, "Mollitia doloremque numquam minus maiores earum veritatis.", 16001 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 9, "Expedita minima ipsa.", 17299 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_TrackId",
                table: "Items",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 4, "Explicabo sed sint." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 9, "Mollitia sunt aperiam vero et aperiam reiciendis." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 4, "Debitis ut aliquid mollitia quo ipsam vel ea." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 6, "Mollitia quidem quo nisi ea." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 2, "Culpa aut est exercitationem qui inventore." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 5, "Ab quae nesciunt praesentium mollitia optio vel repudiandae vitae dolor." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 8, "Voluptatem rem nostrum maxime est maxime est." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 2, "Aut placeat cum quis dolor blanditiis quia quasi in illo." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 10, "Id temporibus enim eius." });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArtistId", "Title" },
                values: new object[] { 6, "Sunt numquam est harum dolorem molestiae aut esse odit." });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Georgia Rohan");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kristy Bergnaum");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bryan Blick");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Shelley Cartwright");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Myra Schuppe");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Deborah Jaskolski");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Jerome McLaughlin");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Erik Kuvalis");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Marcia Rowe");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Rickey Thompson");

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Est architecto velit.", 10516 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 3, "Ullam atque quia esse.", 12077 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 10, "Nobis quia aliquam esse esse soluta voluptatem cupiditate placeat.", 10758 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 7, "Numquam dolore culpa placeat ipsam omnis ut.", 10380 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 4, "Reiciendis voluptas quod iste dolorum ut id assumenda ea.", 10072 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Hic quae tempore natus alias nihil dolores molestias vero odit.", 19305 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 2, "Et quisquam minus vero expedita necessitatibus omnis aut saepe.", 14901 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 4, "Vero veritatis ab temporibus reiciendis laborum maxime quas.", 12973 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 9, "Beatae possimus possimus molestiae neque provident recusandae.", 14309 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AlbumId", "Name", "Price" },
                values: new object[] { 1, "Porro optio magnam alias voluptates nihil odio blanditiis architecto.", 19036 });
        }
    }
}
