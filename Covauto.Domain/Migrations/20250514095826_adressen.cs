using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covauto.Domain.Migrations
{
    /// <inheritdoc />
    public partial class adressen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Ritten_RitID",
                table: "Adres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adres",
                table: "Adres");

            migrationBuilder.RenameTable(
                name: "Adres",
                newName: "Adressen");

            migrationBuilder.RenameIndex(
                name: "IX_Adres_RitID",
                table: "Adressen",
                newName: "IX_Adressen_RitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adressen",
                table: "Adressen",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adressen_Ritten_RitID",
                table: "Adressen",
                column: "RitID",
                principalTable: "Ritten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adressen_Ritten_RitID",
                table: "Adressen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adressen",
                table: "Adressen");

            migrationBuilder.RenameTable(
                name: "Adressen",
                newName: "Adres");

            migrationBuilder.RenameIndex(
                name: "IX_Adressen_RitID",
                table: "Adres",
                newName: "IX_Adres_RitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adres",
                table: "Adres",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Ritten_RitID",
                table: "Adres",
                column: "RitID",
                principalTable: "Ritten",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
