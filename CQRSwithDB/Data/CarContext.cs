using CQRSwithDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSwithDB.Data
{
    public class CarContext : DbContext
    {
        //rejestracja DbSetu
        public DbSet<Car> Cars { get; set; }
    
        //konstruktor na CarContext
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(c =>
            {
                c.Property(cp => cp.Brand).IsRequired();
                c.Property(cp => cp.Brand).HasMaxLength(15);
                c.Property(cp => cp.Model).IsRequired();
                c.Property(cp => cp.Model).HasMaxLength(15);
                c.Property(cp => cp.ProductionDate).IsRequired();
                c.Property(cp => cp.Mileage).IsRequired();
                c.Property(cp => cp.Mileage).HasMaxLength(7);
                c.Property(cp => cp.Price).IsRequired();
                c.Property(cp => cp.Price).HasMaxLength(10);
            });
        }
    }
}
