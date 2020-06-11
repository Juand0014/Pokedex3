using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pokedex3.Models
{
    public partial class pokedex1Context : DbContext
    {
        public pokedex1Context()
        {
        }

        public pokedex1Context(DbContextOptions<pokedex1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-OVC653FD\\SQLEXPRESS;Database=pokedex1;persist security info=true;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("pokemon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ataque1)
                    .HasColumnName("ataque1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ataque2)
                    .HasColumnName("ataque2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ataque3)
                    .HasColumnName("ataque3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ataque4)
                    .HasColumnName("ataque4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Region).HasColumnName("region");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__pokemon__region__2A4B4B5E");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.Tipo)
                    .HasConstraintName("FK__pokemon__tipo__2B3F6F97");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo1)
                    .HasColumnName("tipo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
