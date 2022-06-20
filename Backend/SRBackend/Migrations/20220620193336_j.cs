using Microsoft.EntityFrameworkCore.Migrations;

namespace SRBackend.Migrations
{
    public partial class j : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_User_UserID",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_User_UserID",
                table: "Favorites",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
