using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class ApotekaV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Apotekar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    MjestoRodjenjaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apotekar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Apotekar_Opstina_MjestoRodjenjaID",
                        column: x => x.MjestoRodjenjaID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apotekar_MjestoRodjenjaID",
                table: "Apotekar",
                column: "MjestoRodjenjaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apotekar");

            migrationBuilder.DropTable(
                name: "Opstina");
        }
    }
}
