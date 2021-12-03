using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici");

            migrationBuilder.RenameTable(
                name: "Korisnici",
                newName: "KorisnickiNalog");

            migrationBuilder.AlterColumn<int>(
                name: "Vrsta_Korisnika",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumRodjenja",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumPrijave",
                table: "KorisnickiNalog",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KorisnickiNalog",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KorisnickiNalog",
                table: "KorisnickiNalog",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false),
                    IP_Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KorisnickiNalog",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "KorisnickiNalog");

            migrationBuilder.RenameTable(
                name: "KorisnickiNalog",
                newName: "Korisnici");

            migrationBuilder.AlterColumn<int>(
                name: "Vrsta_Korisnika",
                table: "Korisnici",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Korisnici",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumPrijave",
                table: "Korisnici",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici",
                column: "ID");
        }
    }
}
