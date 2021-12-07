using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakulteti_KorisnickiNalog_KorisnikID",
                table: "Fakulteti");

            migrationBuilder.DropIndex(
                name: "IX_Fakulteti_KorisnikID",
                table: "Fakulteti");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Fakulteti");

            migrationBuilder.AddColumn<int>(
                name: "FakultetID",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FakultetID",
                table: "Fakulteti",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fakulteti_FakultetID",
                table: "Fakulteti",
                column: "FakultetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fakulteti_KorisnickiNalog_FakultetID",
                table: "Fakulteti",
                column: "FakultetID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakulteti_KorisnickiNalog_FakultetID",
                table: "Fakulteti");

            migrationBuilder.DropIndex(
                name: "IX_Fakulteti_FakultetID",
                table: "Fakulteti");

            migrationBuilder.DropColumn(
                name: "FakultetID",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "FakultetID",
                table: "Fakulteti");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Fakulteti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fakulteti_KorisnikID",
                table: "Fakulteti",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fakulteti_KorisnickiNalog_KorisnikID",
                table: "Fakulteti",
                column: "KorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
