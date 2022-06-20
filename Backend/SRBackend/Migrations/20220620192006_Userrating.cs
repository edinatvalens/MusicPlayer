using Microsoft.EntityFrameworkCore.Migrations;

namespace SRBackend.Migrations
{
    public partial class Userrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "SongRating",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_id",
                table: "SongRating");
        }
    }
}
