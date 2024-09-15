using GeladeiraCodeRDIVersity;
using Microsoft.EntityFrameworkCore;

namespace GeladeiraRepository.Context
{
    public class GeladeiraContext : DbContext
    {
        public DbSet<Item> Items { get; set; }


        public GeladeiraContext(DbContextOptions<GeladeiraContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Item>()
               .Property(a => a.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>()
                .Property(a => a.ClassificacaoDoAndar)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}