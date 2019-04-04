using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreScaffoldAndSeed
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieExec> MovieExec { get; set; }
        public virtual DbSet<MovieStar> MovieStar { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<StarsIn> StarsIn { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=Localhost;Integrated Security=True;Initial Catalog=Movies");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<MovieExec>(entity =>
            {
                entity.HasKey(e => e.Cert)
                    .HasName("PK__MovieExe__285E989ED1316AC5");

                entity.Property(e => e.Cert)
                    .HasColumnName("cert")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NetWorth)
                    .HasColumnName("netWorth")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<MovieStar>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__MovieSta__72E12F1A6F309B75");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => new { e.Title, e.Year })
                    .HasName("PK_title_year");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(255);

                entity.Property(e => e.ProducerCert).HasColumnName("producerCert");

                entity.Property(e => e.RunTime).HasColumnName("runTime");

                entity.Property(e => e.StudioName)
                    .HasColumnName("studioName")
                    .HasMaxLength(255);

                entity.HasOne(d => d.ProducerCertNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerCert)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_exec_delete");
            });

            modelBuilder.Entity<StarsIn>(entity =>
            {
                entity.HasKey(e => new { e.MovieTitle, e.MovieYear, e.StarName })
                    .HasName("PK_movieT_movieY_starN");

                entity.Property(e => e.MovieTitle)
                    .HasColumnName("movieTitle")
                    .HasMaxLength(255);

                entity.Property(e => e.MovieYear).HasColumnName("movieYear");

                entity.Property(e => e.StarName)
                    .HasColumnName("starName")
                    .HasMaxLength(255);

                entity.HasOne(d => d.StarNameNavigation)
                    .WithMany(p => p.StarsIn)
                    .HasForeignKey(d => d.StarName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StarsIn__starNam__3D5E1FD2");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.StarsIn)
                    .HasForeignKey(d => new { d.MovieTitle, d.MovieYear })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StarsIn__3C69FB99");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Studio__72E12F1AF93C0DFC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.PresC).HasColumnName("presC");
            });
        }
    }
}
