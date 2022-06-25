using Microsoft.EntityFrameworkCore.Migrations;

namespace SRBackend.Migrations
{
    public partial class lenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SongLenght",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongLenght",
                table: "Song");
        }
    }
}
