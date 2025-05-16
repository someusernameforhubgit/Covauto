using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Reserveringen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GebruikerID = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gebruikers_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruikers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_AutoID",
                table: "Reserveringen",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_GebruikerID",
                table: "Reserveringen",
                column: "GebruikerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserveringen");
        }
    }
}
