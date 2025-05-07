using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Rit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Straat = table.Column<string>(type: "TEXT", nullable: false),
                    Huisnummer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Admin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AfkomstID = table.Column<int>(type: "INTEGER", nullable: false),
                    GebruikerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Kilometers = table.Column<int>(type: "INTEGER", nullable: false),
                    BestemmingID = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rit_Adres_AfkomstID",
                        column: x => x.AfkomstID,
                        principalTable: "Adres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rit_Adres_BestemmingID",
                        column: x => x.BestemmingID,
                        principalTable: "Adres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rit_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rit_Gebruiker_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruiker",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adres",
                columns: new[] { "ID", "Huisnummer", "Plaats", "Straat" },
                values: new object[,]
                {
                    { 1, "49", "Doetinchem", "J.F. Kennedylaan" },
                    { 2, "6A", "Doetinchem", "Expiditieweg" }
                });

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "ID",
                keyValue: 1,
                column: "KilometerStand",
                value: 1000);

            migrationBuilder.InsertData(
                table: "Gebruiker",
                columns: new[] { "ID", "Admin", "Naam" },
                values: new object[] { 1, true, "Bas" });

            migrationBuilder.InsertData(
                table: "Rit",
                columns: new[] { "ID", "AfkomstID", "AutoID", "BestemmingID", "GebruikerID", "Kilometers" },
                values: new object[] { 1, 2, 1, 1, 1, 1000 });

            migrationBuilder.CreateIndex(
                name: "IX_Rit_AfkomstID",
                table: "Rit",
                column: "AfkomstID");

            migrationBuilder.CreateIndex(
                name: "IX_Rit_AutoID",
                table: "Rit",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Rit_BestemmingID",
                table: "Rit",
                column: "BestemmingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rit_GebruikerID",
                table: "Rit",
                column: "GebruikerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rit");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "ID",
                keyValue: 1,
                column: "KilometerStand",
                value: 0);
        }
    }
}
