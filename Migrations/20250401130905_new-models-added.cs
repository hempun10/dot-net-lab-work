using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myapp.Migrations
{
    /// <inheritdoc />
    public partial class newmodelsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
