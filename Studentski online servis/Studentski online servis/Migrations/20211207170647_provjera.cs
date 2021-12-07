using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class provjera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IP_adresa",
                table: "AutentifikacijaToken",
                newName: "IP_Adresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IP_Adresa",
                table: "AutentifikacijaToken",
                newName: "IP_adresa");
        }
    }
}
