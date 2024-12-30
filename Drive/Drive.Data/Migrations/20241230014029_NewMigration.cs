using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 40, 29, 373, DateTimeKind.Utc).AddTicks(3472));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Diretory",
                keyColumn: "DirectoryId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 30, 1, 34, 20, 702, DateTimeKind.Utc).AddTicks(6502));
        }
    }
}
