using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class GELADEIRAContext : DbContext
    {
        public GELADEIRAContext()
        {
        }

        public GELADEIRAContext(DbContextOptions<GELADEIRAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Andar> Andars { get; set; } = null!;
        public virtual DbSet<Classificacao> Classificacaos { get; set; } = null!;
        public virtual DbSet<Container> Containers { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-UC5IQEQ6;Database=GELADEIRA;Uid=sa;Pwd=123;Trusted_Connection=True;TrustServerCertificate=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Andar>(entity =>
            {
                entity.HasKey(e => e.NumeroAndar)
                    .HasName("PK__Andar__BB8FAD79E02C898F");

                entity.ToTable("Andar");

                entity.Property(e => e.NumeroAndar).ValueGeneratedNever();
            });

            modelBuilder.Entity<Classificacao>(entity =>
            {
                entity.HasKey(e => e.Classificacao1)
                    .HasName("PK__Classifi__AE2C4A0E91A21CBE");

                entity.ToTable("Classificacao");

                entity.Property(e => e.Classificacao1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Classificacao");
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.HasKey(e => e.NumeroContainer)
                    .HasName("PK__Containe__0BB2649A82C00F94");

                entity.ToTable("Container");

                entity.Property(e => e.NumeroContainer).ValueGeneratedNever();

                entity.HasOne(d => d.NumeroAndarNavigation)
                    .WithMany(p => p.Containers)
                    .HasForeignKey(d => d.NumeroAndar)
                    .HasConstraintName("FK__Container__Numer__3D5E1FD2");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Alimento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Classificacao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Unidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClassificacaoNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Classificacao)
                    .HasConstraintName("FK__Item__Classifica__5165187F");

                entity.HasOne(d => d.NumeroAndarNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.NumeroAndar)
                    .HasConstraintName("FK__Item__NumeroAnda__5070F446");

                entity.HasOne(d => d.NumeroContainerNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.NumeroContainer)
                    .HasConstraintName("FK__Item__NumeroCont__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
