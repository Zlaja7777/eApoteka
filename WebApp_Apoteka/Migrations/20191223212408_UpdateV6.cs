using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class UpdateV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "korisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "korisnik");
        }
    }
}
