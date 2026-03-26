using EF_Grup2.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EF_Grup2.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GDKTP-NB-000;Database=DB1;User ID=hikmet;Password=1;Trusted_Connection=False;TrustServerCertificate=True");
        }

        public DbSet<Product> Products_ { get; set; }
        public DbSet<DepartmanList> DepartmanList_ { get;set; }

        public DbSet<Arac> aracs { get; set; }
        public DbSet<Musteri> musteris { get; set; }
        public DbSet<SatinAlma> satinalmas { get; set; }

    }
}
