using Microsoft.EntityFrameworkCore;

namespace EF_Grup2.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GDKTP-NB-000;Database=DB1;User ID=hikmet;Password=123;Trusted_Connection=False;TrustServerCertificate=True");
        }

        public DbSet<Product> Products_ { get; set; }

    }
}
