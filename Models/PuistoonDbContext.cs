using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Puistoon.Models
{
    public partial class PuistoonDbContext : DbContext
    {
        public PuistoonDbContext()
        {
        }

        public PuistoonDbContext(DbContextOptions<PuistoonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategoriat> Kategoriat { get; set; }
        public virtual DbSet<Käyttäjät> Käyttäjät { get; set; }
        public virtual DbSet<Palvelut> Palvelut { get; set; }
        public virtual DbSet<Puistot> Puistot { get; set; }
        public virtual DbSet<Tapahtumat> Tapahtumat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PuistoonDb;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoriat>(entity =>
            {
                entity.HasKey(e => e.KategorianId)
                    .HasName("PK__Kategori__C4546DBC09B5581A");

                entity.Property(e => e.KategorianId).HasColumnName("KategorianID");

                entity.Property(e => e.KategorianNimi).HasMaxLength(300);
            });

            modelBuilder.Entity<Käyttäjät>(entity =>
            {
                entity.HasKey(e => e.KäyttäjänId)
                    .HasName("PK__Käyttäjä__80EE1E604A711C82");

                entity.Property(e => e.KäyttäjänId).HasColumnName("KäyttäjänID");

                entity.Property(e => e.Koodi).HasMaxLength(100);

                entity.Property(e => e.KäyttäjänTunnus).HasMaxLength(10);

                entity.Property(e => e.Sähköposti)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Palvelut>(entity =>
            {
                entity.Property(e => e.PalvelutId).HasColumnName("PalvelutID");

                entity.Property(e => e.Kuvaus).HasMaxLength(100);

                entity.Property(e => e.Lisätietoja).HasMaxLength(400);

                entity.Property(e => e.TyyppiId).HasColumnName("TyyppiID");
            });

            modelBuilder.Entity<Puistot>(entity =>
            {
                entity.HasKey(e => e.PuistonId)
                    .HasName("PK__Puistot__4DF2E5D44B5F02B9");

                entity.Property(e => e.PuistonId).HasColumnName("PuistonID");

                entity.Property(e => e.PuistonNimi).HasMaxLength(300);

                entity.Property(e => e.PuistonUrl).HasColumnName("PuistonURL");
            });

            modelBuilder.Entity<Tapahtumat>(entity =>
            {
                entity.HasKey(e => e.TapahtumanId)
                    .HasName("PK__Tapahtum__60ED5B580BE2B9D5");

                entity.Property(e => e.TapahtumanId).HasColumnName("TapahtumanID");

                entity.Property(e => e.Alkaa).HasColumnType("time(0)");

                entity.Property(e => e.KategorianId).HasColumnName("KategorianID");

                entity.Property(e => e.Kuvaus).HasMaxLength(200);

                entity.Property(e => e.KäyttäjänId).HasColumnName("KäyttäjänID");

                entity.Property(e => e.Loppuu).HasColumnType("time(0)");

                entity.Property(e => e.Nimi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PuistonId).HasColumnName("PuistonID");

                entity.Property(e => e.Pvm).HasColumnType("date");

                entity.HasOne(d => d.Kategorian)
                    .WithMany(p => p.Tapahtumat)
                    .HasForeignKey(d => d.KategorianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tapahtumat_Kategoriat");

                entity.HasOne(d => d.Käyttäjän)
                    .WithMany(p => p.Tapahtumat)
                    .HasForeignKey(d => d.KäyttäjänId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tapahtumat_Käyttäjät");

                entity.HasOne(d => d.Puiston)
                    .WithMany(p => p.Tapahtumat)
                    .HasForeignKey(d => d.PuistonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tapahtumat_Puistot");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
