using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class WebApoteka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lijek",
                columns: table => new
                {
                    LijekID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivLijeka = table.Column<string>(nullable: true),
                    InternacionalniGenerickiNaziv = table.Column<string>(nullable: true),
                    KvalitativniIKvantitativniSastav = table.Column<string>(nullable: true),
                    FarmaceutskiOblik = table.Column<string>(nullable: true),
                    NacinPrimjene = table.Column<string>(nullable: true),
                    RokTrajanjaMjeseci = table.Column<int>(nullable: false),
                    NazivProizvodjaca = table.Column<string>(nullable: true),
                    DatumProizvodnje = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijek", x => x.LijekID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lijek");
        }
    }
}
