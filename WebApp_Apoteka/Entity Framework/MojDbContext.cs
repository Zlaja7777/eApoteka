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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@" Server= DESKTOP-ND9VBEM\MSSQLSERVER_OLAP;

                                        Database=WebApoteka;

                                        Trusted_Connection=True;

                                        MultipleActiveResultSets=true;"

                                       
                                    );

        }
    }
}
