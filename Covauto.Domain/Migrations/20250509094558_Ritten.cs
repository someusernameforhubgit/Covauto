using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Ritten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Rit_RitID",
                table: "Adres");

            migrationBuilder.DropForeignKey(
                name: "FK_Rit_Autos_AutoID",
                table: "Rit");

            migrationBuilder.DropForeignKey(
                name: "FK_Rit_Gebruiker_GebruikerID",
                table: "Rit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rit",
                table: "Rit");

            migrationBuilder.RenameTable(
                name: "Rit",
                newName: "Ritten");

            migrationBuilder.RenameIndex(
                name: "IX_Rit_GebruikerID",
                table: "Ritten",
                newName: "IX_Ritten_GebruikerID");

            migrationBuilder.RenameIndex(
                name: "IX_Rit_AutoID",
                table: "Ritten",
                newName: "IX_Ritten_AutoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ritten",
                table: "Ritten",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Ritten_RitID",
                table: "Adres",
                column: "RitID",
                principalTable: "Ritten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ritten_Autos_AutoID",
                table: "Ritten",
                column: "AutoID",
                principalTable: "Autos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ritten_Gebruiker_GebruikerID",
                table: "Ritten",
                column: "GebruikerID",
                principalTable: "Gebruiker",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Ritten_RitID",
                table: "Adres");

            migrationBuilder.DropForeignKey(
                name: "FK_Ritten_Autos_AutoID",
                table: "Ritten");

            migrationBuilder.DropForeignKey(
                name: "FK_Ritten_Gebruiker_GebruikerID",
                table: "Ritten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ritten",
                table: "Ritten");

            migrationBuilder.RenameTable(
                name: "Ritten",
                newName: "Rit");

            migrationBuilder.RenameIndex(
                name: "IX_Ritten_GebruikerID",
                table: "Rit",
                newName: "IX_Rit_GebruikerID");

            migrationBuilder.RenameIndex(
                name: "IX_Ritten_AutoID",
                table: "Rit",
                newName: "IX_Rit_AutoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rit",
                table: "Rit",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Rit_RitID",
                table: "Adres",
                column: "RitID",
                principalTable: "Rit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rit_Autos_AutoID",
                table: "Rit",
                column: "AutoID",
                principalTable: "Autos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
