using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class Izmjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnickiNalog",
                table: "KorisnickiNalog");

            migrationBuilder.RenameTable(
                name: "KorisnickiNalog",
                newName: "_korisnici");

            migrationBuilder.AddPrimaryKey(
                name: "PK__korisnici",
                table: "_korisnici",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken__korisnici_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "_korisnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken__korisnici_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK__korisnici",
                table: "_korisnici");

            migrationBuilder.RenameTable(
                name: "_korisnici",
                newName: "KorisnickiNalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnickiNalog",
                table: "KorisnickiNalog",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
