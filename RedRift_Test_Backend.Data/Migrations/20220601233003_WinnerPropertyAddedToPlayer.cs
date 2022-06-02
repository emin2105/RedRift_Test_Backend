using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedRift_Test_Backend.Data.Migrations
{
    public partial class WinnerPropertyAddedToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Winner",
                table: "PlayerSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "PlayerSessions");
        }
    }
}
