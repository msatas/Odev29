using Microsoft.EntityFrameworkCore;

namespace Odev29.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) 
        {

        }

        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>().HasData(
               new Urun {Id=1, Ad="Koltuk", Fiyat=13500 },
               new Urun {Id=2, Ad="Masa", Fiyat=10500 },
               new Urun {Id=3, Ad="Dolap", Fiyat=15500 }
                );
        }
    }
}
