using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakulteti_KorisnickiNalog_FakultetID",
                table: "Fakulteti");

            migrationBuilder.DropIndex(
                name: "IX_Fakulteti_FakultetID",
                table: "Fakulteti");

            migrationBuilder.DropColumn(
                name: "FakultetID",
                table: "Fakulteti");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_FakultetID",
                table: "KorisnickiNalog",
                column: "FakultetID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog",
                column: "FakultetID",
                principalTable: "Fakulteti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Fakulteti_FakultetID",
                table: "KorisnickiNalog");

            migrationBuilder.DropIndex(
                name: "IX_KorisnickiNalog_FakultetID",
                table: "KorisnickiNalog");

            migrationBuilder.AddColumn<int>(
                name: "FakultetID",
                table: "Fakulteti",
                type: "int",
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
    }
}
