using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARHospitalProject.Migrations
{
    public partial class M20220509108600 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Appointments",
                newName: "EndingTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "EndingTime",
                table: "Appointments",
                newName: "BookingDate");
        }
    }
}
