﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_Apoteka.Entity_Framework;

namespace WebApp_Apoteka.Migrations
{
    [DbContext(typeof(MojDbContext))]
    [Migration("20191222230603_UpdateV2")]
    partial class UpdateV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apoteka.Models.Apotekar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MjestoRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MjestoRodjenjaID");

                    b.ToTable("Apotekar");
                });

            modelBuilder.Entity("Apoteka.Models.Opstina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Opstina");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Clanak", b =>
                {
                    b.Property<int>("ClanakID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApotekarID")
                        .HasColumnType("int");

                    b.HasKey("ClanakID");

                    b.HasIndex("ApotekarID");

                    b.ToTable("clanak");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.DetaljiOnlineNarudzbe", b =>
                {
                    b.Property<int>("lijekID")
                        .HasColumnType("int");

                    b.Property<int>("onlineNarudzbaID")
                        .HasColumnType("int");

                    b.Property<double>("cijenaLijeka")
                        .HasColumnType("float");

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<double>("popust")
                        .HasColumnType("float");

                    b.Property<double>("ukupnaCijenaStavke")
                        .HasColumnType("float");

                    b.HasKey("lijekID", "onlineNarudzbaID");

                    b.HasIndex("onlineNarudzbaID");

                    b.ToTable("detaljiOnlineNarudzbe");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Dobavljac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.ToTable("dobavljac");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Kategorija", b =>
                {
                    b.Property<int>("KategorijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKategorije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategorijaID");

                    b.ToTable("kategorija");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.KonkursPraksa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GodinaZavrsetka")
                        .HasColumnType("int");

                    b.Property<bool>("ImaRadnoIskustvo")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("Obrazlozenje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Prihvacena")
                        .HasColumnType("bit");

                    b.Property<string>("RadnoIskustvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZavrsenaSkola")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("konkursPraksa");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bonovi")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipKorisnikaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OpstinaRodjenjaID");

                    b.HasIndex("TipKorisnikaID");

                    b.ToTable("korisnik");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Kosarica", b =>
                {
                    b.Property<int>("KosaricaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("LijekID")
                        .HasColumnType("int");

                    b.HasKey("KosaricaID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("LijekID");

                    b.ToTable("kosarica");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Lijek", b =>
                {
                    b.Property<int>("LijekID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumProizvodnje")
                        .HasColumnType("datetime2");

                    b.Property<string>("FarmaceutskiOblik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternacionalniGenerickiNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("KvalitativniIKvantitativniSastav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NabavnaCijena")
                        .HasColumnType("float");

                    b.Property<string>("NacinPrimjene")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivLijeka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivProizvodjaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProdajnaCijena")
                        .HasColumnType("float");

                    b.Property<int>("RokTrajanjaMjeseci")
                        .HasColumnType("int");

                    b.Property<string>("SlikaLijeka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LijekID");

                    b.HasIndex("KategorijaID");

                    b.ToTable("Lijek");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Nabavka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApotekarID")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("statusNarudzbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vrijednostNarudzbe")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ApotekarID");

                    b.ToTable("nabavka");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.OnlineNarudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresaDostave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("cijenaDostave")
                        .HasColumnType("float");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("gradDostaveID")
                        .HasColumnType("int");

                    b.Property<int>("korisnikID")
                        .HasColumnType("int");

                    b.Property<double>("vrijednostNarudzbe")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("gradDostaveID");

                    b.HasIndex("korisnikID");

                    b.ToTable("onlineNarudzba");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.RezervacijaTermina", b =>
                {
                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("UslugaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijemeRezervacije")
                        .HasColumnType("datetime2");

                    b.HasKey("KorisnikID", "UslugaID");

                    b.HasIndex("UslugaID");

                    b.ToTable("rezervacijaTermina");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.StavkeNabavke", b =>
                {
                    b.Property<int>("NabavkaID")
                        .HasColumnType("int");

                    b.Property<int>("LijekID")
                        .HasColumnType("int");

                    b.Property<double>("NabavnaCijenaLijeka")
                        .HasColumnType("float");

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<double>("ukupnaCijenaStavke")
                        .HasColumnType("float");

                    b.HasKey("NabavkaID", "LijekID");

                    b.HasIndex("LijekID");

                    b.ToTable("stavkaNabavke");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.TipKorisnika", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tipKorisnika");
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Usluga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPacijenata")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Naziv")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("usluga");
                });

            modelBuilder.Entity("Apoteka.Models.Apotekar", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "MjestoRodjenja")
                        .WithMany()
                        .HasForeignKey("MjestoRodjenjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Clanak", b =>
                {
                    b.HasOne("Apoteka.Models.Apotekar", "Apotekar")
                        .WithMany()
                        .HasForeignKey("ApotekarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.DetaljiOnlineNarudzbe", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Lijek", "lijek")
                        .WithMany()
                        .HasForeignKey("lijekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.OnlineNarudzba", "onlineNarudzba")
                        .WithMany()
                        .HasForeignKey("onlineNarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Dobavljac", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.KonkursPraksa", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Korisnik", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "OpstinaRodjenja")
                        .WithMany()
                        .HasForeignKey("OpstinaRodjenjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.TipKorisnika", "TipKorisnika")
                        .WithMany()
                        .HasForeignKey("TipKorisnikaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Kosarica", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Lijek", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.Nabavka", b =>
                {
                    b.HasOne("Apoteka.Models.Apotekar", "Apotekar")
                        .WithMany()
                        .HasForeignKey("ApotekarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.OnlineNarudzba", b =>
                {
                    b.HasOne("Apoteka.Models.Opstina", "gradDostave")
                        .WithMany()
                        .HasForeignKey("gradDostaveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.RezervacijaTermina", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.Usluga", "usluga")
                        .WithMany()
                        .HasForeignKey("UslugaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp_Apoteka.Models.StavkeNabavke", b =>
                {
                    b.HasOne("WebApp_Apoteka.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Apoteka.Models.Nabavka", "Nabavka")
                        .WithMany()
                        .HasForeignKey("NabavkaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
