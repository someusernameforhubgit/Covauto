using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Gebruikers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rit_Gebruiker_GebruikerID",
                table: "Rit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker");

            migrationBuilder.RenameTable(
                name: "Gebruiker",
                newName: "Gebruikers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rit_Gebruikers_GebruikerID",
                table: "Rit",
                column: "GebruikerID",
                principalTable: "Gebruikers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rit_Gebruikers_GebruikerID",
                table: "Rit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers");

            migrationBuilder.RenameTable(
                name: "Gebruikers",
                newName: "Gebruiker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rit_Gebruiker_GebruikerID",
                table: "Rit",
                column: "GebruikerID",
                principalTable: "Gebruiker",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
