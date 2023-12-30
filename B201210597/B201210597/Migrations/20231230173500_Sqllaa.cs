using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B201210597.Migrations
{
    public partial class Sqllaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AppointmentId",
                table: "Departments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_AppointmentId",
                table: "Clinics",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Appointments_AppointmentId",
                table: "Clinics",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Appointments_AppointmentId",
                table: "Departments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Appointments_AppointmentId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Appointments_AppointmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_AppointmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_AppointmentId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Clinics");
        }
    }
}
