using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data
{
    public partial class ANIMALESContext : DbContext
    {
        public ANIMALESContext()
        {
        }

        public ANIMALESContext(DbContextOptions<ANIMALESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animale> Animales { get; set; } = null!;
        public virtual DbSet<Catergorium> Catergoria { get; set; } = null!;
        public virtual DbSet<Licitacion> Licitacions { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<ResponsableLicitacion> ResponsableLicitacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animale>(entity =>
            {
                entity.HasKey(e => e.Animalid);

                entity.ToTable("ANIMALES");

                entity.Property(e => e.Animalid).HasColumnName("ANIMALID");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Breed)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BREED");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SEX");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Catergorium>(entity =>
            {
                entity.ToTable("CATERGORIA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Licitacion>(entity =>
            {
                entity.ToTable("LICITACION");

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.IdResponsable).HasColumnName("Id_Responsable");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Licitacions)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICITACION_CATERGORIA");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.Licitacions)
                    .HasForeignKey(d => d.IdResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICITACION_RESPONSABLE_LICITACION");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("ORDEN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Total).HasColumnName("TOTAL");
            });

            modelBuilder.Entity<ResponsableLicitacion>(entity =>
            {
                entity.ToTable("RESPONSABLE_LICITACION");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
