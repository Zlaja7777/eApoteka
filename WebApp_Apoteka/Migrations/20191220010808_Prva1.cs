using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Apoteka.Migrations
{
    public partial class Prva1 : Migration
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
                name: "usluga",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<int>(nullable: false),
                    DatumVrijeme = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    BrojPacijenata = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usluga", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    OpstinaRodjenjaID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_korisnik_Opstina_OpstinaRodjenjaID",
                        column: x => x.OpstinaRodjenjaID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "onlineNarudzba",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikID = table.Column<int>(nullable: false),
                    datum = table.Column<DateTime>(nullable: false),
                    vrijednostNarudzbe = table.Column<double>(nullable: false),
                    cijenaDostave = table.Column<double>(nullable: false),
                    gradDostaveID = table.Column<int>(nullable: false),
                    adresaDostave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onlineNarudzba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_onlineNarudzba_Opstina_gradDostaveID",
                        column: x => x.gradDostaveID,
                        principalTable: "Opstina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_onlineNarudzba_korisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rezervacijaTermina",
                columns: table => new
                {
                    UslugaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    DatumVrijemeRezervacije = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacijaTermina", x => new { x.KorisnikID, x.UslugaID });
                    table.ForeignKey(
                        name: "FK_rezervacijaTermina_korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacijaTermina_usluga_UslugaID",
                        column: x => x.UslugaID,
                        principalTable: "usluga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detaljiOnlineNarudzbe",
                columns: table => new
                {
                    onlineNarudzbaID = table.Column<int>(nullable: false),
                    lijekID = table.Column<int>(nullable: false),
                    cijenaLijeka = table.Column<double>(nullable: false),
                    kolicina = table.Column<int>(nullable: false),
                    popust = table.Column<double>(nullable: false),
                    ukupnaCijenaStavke = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detaljiOnlineNarudzbe", x => new { x.lijekID, x.onlineNarudzbaID });
                    table.ForeignKey(
                        name: "FK_detaljiOnlineNarudzbe_Lijek_lijekID",
                        column: x => x.lijekID,
                        principalTable: "Lijek",
                        principalColumn: "LijekID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detaljiOnlineNarudzbe_onlineNarudzba_onlineNarudzbaID",
                        column: x => x.onlineNarudzbaID,
                        principalTable: "onlineNarudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apotekar_MjestoRodjenjaID",
                table: "Apotekar",
                column: "MjestoRodjenjaID");

            migrationBuilder.CreateIndex(
                name: "IX_detaljiOnlineNarudzbe_onlineNarudzbaID",
                table: "detaljiOnlineNarudzbe",
                column: "onlineNarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_korisnik_OpstinaRodjenjaID",
                table: "korisnik",
                column: "OpstinaRodjenjaID");

            migrationBuilder.CreateIndex(
                name: "IX_onlineNarudzba_gradDostaveID",
                table: "onlineNarudzba",
                column: "gradDostaveID");

            migrationBuilder.CreateIndex(
                name: "IX_onlineNarudzba_korisnikID",
                table: "onlineNarudzba",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijaTermina_UslugaID",
                table: "rezervacijaTermina",
                column: "UslugaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apotekar");

            migrationBuilder.DropTable(
                name: "detaljiOnlineNarudzbe");

            migrationBuilder.DropTable(
                name: "rezervacijaTermina");

            migrationBuilder.DropTable(
                name: "Lijek");

            migrationBuilder.DropTable(
                name: "onlineNarudzba");

            migrationBuilder.DropTable(
                name: "usluga");

            migrationBuilder.DropTable(
                name: "korisnik");

            migrationBuilder.DropTable(
                name: "Opstina");
        }
    }
}
