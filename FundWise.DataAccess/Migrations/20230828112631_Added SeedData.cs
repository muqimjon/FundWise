using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundWise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "DateOfBirth", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "Role", "UpdateAt" },
                values: new object[,]
                {
                    { 10L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2034), new DateTime(1990, 5, 14, 19, 0, 0, 0, DateTimeKind.Utc), "johndoe@example.com", "John", false, "Doe", "password", "123-456-7890", 3, null },
                    { 20L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2083), new DateTime(1985, 10, 24, 19, 0, 0, 0, DateTimeKind.Utc), "emilysmith@example.com", "Emily", false, "Smith", "password", "987-654-3210", 3, null },
                    { 30L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2087), new DateTime(1978, 3, 7, 19, 0, 0, 0, DateTimeKind.Utc), "michaeljohnson@example.com", "Michael", false, "Johnson", "password", "555-123-4567", 1, null },
                    { 40L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2090), new DateTime(1995, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "jessicawilliams@example.com", "Jessica", false, "Williams", "password", "111-222-3333", 3, null },
                    { 50L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2092), new DateTime(1992, 9, 9, 19, 0, 0, 0, DateTimeKind.Utc), "sanjar@example.com", "Sanjar", false, "Tursunov", "password", "998-91-234-56-78", 3, null },
                    { 60L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2095), new DateTime(1992, 9, 9, 19, 0, 0, 0, DateTimeKind.Utc), "sanjar@example.com", "Sanjar", false, "Tursunov", "password", "998-91-234-56-78", 3, null },
                    { 70L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2097), new DateTime(1993, 4, 4, 19, 0, 0, 0, DateTimeKind.Utc), "umid@example.com", "Umid", false, "Ismoilov", "password", "998-93-456-78-90", 3, null },
                    { 80L, new DateTime(2023, 8, 28, 11, 26, 31, 719, DateTimeKind.Utc).AddTicks(2099), new DateTime(1991, 11, 14, 19, 0, 0, 0, DateTimeKind.Utc), "nodir@example.com", "Nodir", false, "Nazarov", "password", "998-94-567-89-01", 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 80L);
        }
    }
}
