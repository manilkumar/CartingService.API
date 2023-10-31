using CaartingService.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaartingService.API.Data
{
    public class CartingDBContext : DbContext
    {
        public CartingDBContext(DbContextOptions<CartingDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ECommerceDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });

        }
    }
}
