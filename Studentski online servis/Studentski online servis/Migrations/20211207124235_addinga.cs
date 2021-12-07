using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class addinga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poruka",
                table: "AutentifikacijaToken");

            migrationBuilder.AddColumn<string>(
                name: "IP_adresa",
                table: "AutentifikacijaToken",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IP_adresa",
                table: "AutentifikacijaToken");

            migrationBuilder.AddColumn<string>(
                name: "Poruka",
                table: "AutentifikacijaToken",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
