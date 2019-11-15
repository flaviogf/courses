using Microsoft.EntityFrameworkCore.Migrations;

namespace Section7.PaginationAndMethodSyntax.Migrations
{
    public partial class add_column_users_file_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Users");
        }
    }
}
