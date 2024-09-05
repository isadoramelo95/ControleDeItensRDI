using GeladeiraCodeRDIVersity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMigration
{
    public class GeladeiraContext :DbContext
    {
        public DbSet<Item> Items { get; set; }

        public GeladeiraContext(DbContextOptions<GeladeiraContext> options) 
            : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Item>()
                .Property(i => i.Classificacao)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
