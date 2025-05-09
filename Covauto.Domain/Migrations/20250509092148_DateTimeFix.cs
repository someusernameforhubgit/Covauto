using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rit",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rit",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 9, 11, 17, 5, 764, DateTimeKind.Local).AddTicks(1884));
        }
    }
}
