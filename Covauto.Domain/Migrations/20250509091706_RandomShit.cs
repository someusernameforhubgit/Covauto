using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RandomShit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rit_Adres_AfkomstID",
                table: "Rit");

            migrationBuilder.DropForeignKey(
                name: "FK_Rit_Adres_BestemmingID",
                table: "Rit");

            migrationBuilder.DropIndex(
                name: "IX_Rit_AfkomstID",
                table: "Rit");

            migrationBuilder.DropIndex(
                name: "IX_Rit_BestemmingID",
                table: "Rit");

            migrationBuilder.DropColumn(
                name: "AfkomstID",
                table: "Rit");

            migrationBuilder.DropColumn(
                name: "BestemmingID",
                table: "Rit");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Gebruiker",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Autos",
                newName: "Model");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Rit",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "Gebruiker",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kleur",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Merk",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Land",
                table: "Adres",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Adres",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RitID",
                table: "Adres",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Adres",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Huisnummer", "Land", "Order", "RitID", "Straat" },
                values: new object[] { "6A", "Nederland", 1, 1, "Expiditieweg" });

            migrationBuilder.UpdateData(
                table: "Adres",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Huisnummer", "Land", "Order", "RitID", "Straat" },
                values: new object[] { "49", "Nederland", 2, 1, "J.F. Kennedylaan" });

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Kleur", "Merk", "Model" },
                values: new object[] { "Zwart", "Honda", "Civic" });

            migrationBuilder.UpdateData(
                table: "Gebruiker",
                keyColumn: "ID",
                keyValue: 1,
                column: "Achternaam",
                value: "Peter");

            migrationBuilder.UpdateData(
                table: "Rit",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2025, 5, 9, 11, 17, 5, 764, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.CreateIndex(
                name: "IX_Adres_RitID",
                table: "Adres",
                column: "RitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Rit_RitID",
                table: "Adres",
                column: "RitID",
                principalTable: "Rit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Rit_RitID",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_RitID",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Rit");

            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "Kleur",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Merk",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Land",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "RitID",
                table: "Adres");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "Gebruiker",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Autos",
                newName: "Naam");

            migrationBuilder.AddColumn<int>(
                name: "AfkomstID",
                table: "Rit",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BestemmingID",
                table: "Rit",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Adres",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Huisnummer", "Straat" },
                values: new object[] { "49", "J.F. Kennedylaan" });

            migrationBuilder.UpdateData(
                table: "Adres",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Huisnummer", "Straat" },
                values: new object[] { "6A", "Expiditieweg" });

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "ID",
                keyValue: 1,
                column: "Naam",
                value: "Auto 1");

            migrationBuilder.UpdateData(
                table: "Rit",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AfkomstID", "BestemmingID" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Rit_AfkomstID",
                table: "Rit",
                column: "AfkomstID");

            migrationBuilder.CreateIndex(
                name: "IX_Rit_BestemmingID",
                table: "Rit",
                column: "BestemmingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rit_Adres_AfkomstID",
                table: "Rit",
                column: "AfkomstID",
                principalTable: "Adres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rit_Adres_BestemmingID",
                table: "Rit",
                column: "BestemmingID",
                principalTable: "Adres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
