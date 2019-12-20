using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_Apoteka.Models;
using Apoteka.Models;

namespace WebApp_Apoteka.Entity_Framework
{
    public class MojDbContext : DbContext
    {
        public DbSet<Lijek> Lijek { get; set; }
        public DbSet<Apotekar> Apotekar { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<OnlineNarudzba> onlineNarudzba { get; set; }
        public DbSet<DetaljiOnlineNarudzbe> detaljiOnlineNarudzbe { get; set; }
        public DbSet<Usluga> usluga { get; set; }
        public DbSet<RezervacijaTermina> rezervacijaTermina { get; set; }
        public DbSet<Korisnik> korisnik { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetaljiOnlineNarudzbe>()
                .HasKey(d => new { d.lijekID, d.onlineNarudzbaID });

            modelBuilder.Entity<RezervacijaTermina>()
                .HasKey(r => new { r.KorisnikID, r.UslugaID });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@" Server= localhost;

                                        Database=WebApoteka;

                                        Trusted_Connection=True;

                                        MultipleActiveResultSets=true;"

                                       
                                    );

        }
    }
}
