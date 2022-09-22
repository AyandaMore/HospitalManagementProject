using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARHospitalProject.Migrations
{
    public partial class M20220509154700 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "PatientReports",
                type: "uniqueidentifier",
                nullable: true);

           

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_AppointmentId",
                table: "PatientReports",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_Appointments_AppointmentId",
                table: "PatientReports",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_Appointments_AppointmentId",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_AppointmentId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "PatientReports");

           
        }
    }
}
