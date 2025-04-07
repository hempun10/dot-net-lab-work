using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myapp.Migrations
{
    /// <inheritdoc />
    public partial class addeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 11, "UK Block", "Grade 11" },
                    { 12, "Nepal Block", "Grade 12" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 11, "Female", "Alice" },
                    { 2, 11, "Male", "Bob" },
                    { 3, 12, "Male", "Charlie" },
                    { 4, 11, "Male", "David" },
                    { 5, 12, "Female", "Emma" },
                    { 6, 12, "Male", "Frank" },
                    { 7, 12, "Female", "Grace" },
                    { 8, 11, "Male", "Henry" },
                    { 9, 11, "Female", "Ivy" },
                    { 10, 12, "Male", "Jack" },
                    { 11, 11, "Female", "Kate" },
                    { 12, 12, "Male", "Liam" },
                    { 13, 11, "Female", "Mia" },
                    { 14, 12, "Male", "Nathan" },
                    { 15, 12, "Female", "Olivia" },
                    { 16, 11, "Male", "Paul" },
                    { 17, 11, "Female", "Quinn" },
                    { 18, 12, "Male", "Ryan" },
                    { 19, 12, "Female", "Sophia" },
                    { 20, 11, "Male", "Thomas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
