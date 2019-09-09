using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Opflix.WebAPII.Domains
{
    public partial class OpflixContext : DbContext
    {
        public OpflixContext()
        {
        }

        public OpflixContext(DbContextOptions<OpflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Lancamento> Lancamento { get; set; }
        public virtual DbSet<TipoMetragem> TipoMetragem { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        // Unable to generate entity type for table 'dbo.LancamentoFavoritado'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-IPTA00I\\SQLEXPRESS;Initial Catalog=MD_Opflix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B2230FBA99")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__5629CD9C");

                entity.HasOne(d => d.IdTipoMetragemNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdTipoMetragem)
                    .HasConstraintName("FK__Lancament__IdTip__571DF1D5");
            });

            modelBuilder.Entity<TipoMetragem>(entity =>
            {
                entity.HasKey(e => e.IdTipoMetragem);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TipoMetr__7D8FE3B208C8C24A")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D1053464EC951B")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuario__7ABB9731825A9869")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__4D94879B");
            });
        }
    }
}
