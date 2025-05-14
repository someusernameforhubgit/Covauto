using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Merk = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Kleur = table.Column<string>(type: "TEXT", nullable: false),
                    KilometerStand = table.Column<int>(type: "INTEGER", nullable: false),
                    Beschikbaar = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                    Admin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ritten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GebruikerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Kilometers = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ritten", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ritten_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ritten_Gebruikers_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruikers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    RitID = table.Column<int>(type: "INTEGER", nullable: false),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Straat = table.Column<string>(type: "TEXT", nullable: false),
                    Huisnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Land = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adres_Ritten_RitID",
                        column: x => x.RitID,
                        principalTable: "Ritten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "ID", "Beschikbaar", "KilometerStand", "Kleur", "Merk", "Model" },
                values: new object[] { 1, true, 1000, "Zwart", "Honda", "Civic" });

            migrationBuilder.InsertData(
                table: "Gebruikers",
                columns: new[] { "ID", "Achternaam", "Admin", "Voornaam" },
                values: new object[] { 1, "Peter", true, "Bas" });

            migrationBuilder.InsertData(
                table: "Ritten",
                columns: new[] { "ID", "AutoID", "Datum", "GebruikerID", "Kilometers" },
                values: new object[] { 1, 1, new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1000 });

            migrationBuilder.InsertData(
                table: "Adres",
                columns: new[] { "ID", "Huisnummer", "Land", "Order", "Plaats", "RitID", "Straat" },
                values: new object[,]
                {
                    { 1, "6A", "Nederland", 1, "Doetinchem", 1, "Expiditieweg" },
                    { 2, "49", "Nederland", 2, "Doetinchem", 1, "J.F. Kennedylaan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_RitID",
                table: "Adres",
                column: "RitID");

            migrationBuilder.CreateIndex(
                name: "IX_Ritten_AutoID",
                table: "Ritten",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ritten_GebruikerID",
                table: "Ritten",
                column: "GebruikerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Ritten");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
