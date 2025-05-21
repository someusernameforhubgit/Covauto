using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class datetobegingend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Ritten",
                newName: "End");

            migrationBuilder.AddColumn<DateTime>(
                name: "Begin",
                table: "Ritten",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ritten",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Begin", "End" },
                values: new object[] { new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 14, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Begin",
                table: "Ritten");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Ritten",
                newName: "Datum");

            migrationBuilder.UpdateData(
                table: "Ritten",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
