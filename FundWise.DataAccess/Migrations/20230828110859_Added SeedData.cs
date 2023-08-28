using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundWise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 80L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 8, 59, 506, DateTimeKind.Utc).AddTicks(1592));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 80L,
                column: "CreateAt",
                value: new DateTime(2023, 8, 28, 11, 5, 15, 379, DateTimeKind.Utc).AddTicks(2717));
        }
    }
}
