using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarvedRock.Api.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Review = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 5, 8, 52, 6, 453, DateTimeKind.Unspecified).AddTicks(5575), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 5, 8, 52, 6, 465, DateTimeKind.Unspecified).AddTicks(5080), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 5, 8, 52, 6, 465, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 5, 8, 52, 6, 465, DateTimeKind.Unspecified).AddTicks(5151), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 5, 8, 52, 6, 465, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 5, 8, 52, 6, 465, DateTimeKind.Unspecified).AddTicks(5185), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 1, 1, "First released almost 30 years ago, the Titan 26078 is a classic work boot. It’s also one of Timberland’s all time best sellers.", "Crossed the Himalayas" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 2, 1, "One of the most comfortable hiking boots available, each pair comes complete with the Power Fit Comfort System, designed to offer maximum support at key areas of your feet.", "Comfortable" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 3, 2, "They have absolutely no break in period and can literally be worn to work the day that you get them.", "Indestructible" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 4, 2, "The safety toe is made from an aluminium alloy which offers all the protection of steel but half the weight. The soles are also oil, abrasion and slip resistant.", "Safety toe" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 5, 3, "The Better Backpack is made from 100% recycled plastic but looks and feels like canvas. We were sent the grey bag with the tan leather accents and silver zippers. I’ve personally always liked tan leather paired with the color grey and appreciate the feel of the leather pull tabs and handles at the top of the bag. Additionally the inside is navy blue with a diagonal stitch pattern which gives it an air of sophistication.", "Feels like canvas" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 6, 5, "So this is my 1st ever kayak and my 1st experience paddling a kayak. I struggled with whether I should spend more money to buy a \"Fishing\" kayak, or even a \"higher end\" kayak because my fear was paddling around a bathtub on the lake. I have to say, I love this kayak for me. It doesn't have a lot of the bells and whistles that some of the pricier kayaks have but, I'm not disappointed.\r\n\r\nIt's pretty bare bones aside from some dry storage areas and some bungees. It does have a bungee to hold your paddle on the side. I feel it paddles very easy. It goes exactly where I want it to, I didn't struggle to keep it on course. A stiff wind can knock you off track but it was very sturdy and I feel like it would take a lot to tip it over. I stayed fairly dry aside from the dripping off the paddle but its a sit on top so thats to be expected.", "So this is my 1st ever..." });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 7, 5, "I am a fit 5'7 woman 140lbs and I take my 30# dog along with no troubles. I have fished with it by using a bucket strapped in the back with my bungee cords. It holds my rods and small tackle tray, bug spray etc so I can get to it all easily. I can even get it up on the roof of my jeep alone. ", "Great for all genders" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 8, 5, "Very happy with my purchase and I recommend this to anyone who doesn't want to spend over 600$ on a kayak but also doesn't want a cheap ole hunk of plastic. ", "Happy" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[] { 9, 6, "Hobie took the paddle out of the hands of the masses, and changed kayak fishing forever. Ive heavily fished the 'Revo' since 2011 and feel its about perfect for my use. As a serious cyclist its a natural fit, and it can cover huge distances. The torque the Mirage drive generates in rough conditions is often overlooked. I feel it could easily pull any propeller driven kayak backwards in a tug-o-war. I recently weighed my bare hull at 69#s, and that's not too shabby for ANY pedal yak. I still fish from paddle yaks, but I spend more time with the rods in my hands when on the Revo.", "Hobie took the paddle out" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 558, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7847), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7884), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7911), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2020, 12, 4, 10, 25, 28, 569, DateTimeKind.Unspecified).AddTicks(7916), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
