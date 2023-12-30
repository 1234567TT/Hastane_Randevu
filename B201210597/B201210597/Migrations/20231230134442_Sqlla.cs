using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B201210597.Migrations
{
    public partial class Sqlla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emial",
                table: "Kullaniciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TC",
                table: "Kullaniciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emial",
                table: "Kullaniciler");

            migrationBuilder.DropColumn(
                name: "TC",
                table: "Kullaniciler");
        }
    }
}
