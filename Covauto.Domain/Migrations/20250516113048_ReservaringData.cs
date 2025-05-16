using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ReservaringData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reserveringen",
                columns: new[] { "ID", "AutoID", "Begin", "End", "GebruikerID" },
                values: new object[] { 1, 1, new DateTime(2025, 12, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reserveringen",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
