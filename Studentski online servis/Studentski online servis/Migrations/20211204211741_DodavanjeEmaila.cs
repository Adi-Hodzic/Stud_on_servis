using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_online_servis.Migrations
{
    public partial class DodavanjeEmaila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DLWMS_email",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Privatni_email",
                table: "KorisnickiNalog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DLWMS_email",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Privatni_email",
                table: "KorisnickiNalog");
        }
    }
}
