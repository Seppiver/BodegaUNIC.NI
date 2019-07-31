using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bodega.Models
{
    public partial class BodegaContext : DbContext
    {
        public BodegaContext()
        {
        }

        public BodegaContext(DbContextOptions<BodegaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pantalla> Pantalla { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<PermisoName> PermisoName { get; set; }
        public virtual DbSet<RecintoEquivalencia> RecintoEquivalencia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.103.29\\Finanzas;Initial Catalog=Bodega;User ID=rmartinez;Password=000000;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Pantalla>(entity =>
            {
                entity.HasKey(e => e.IdPantalla);

                entity.ToTable("Pantalla", "Seguridad");

                entity.Property(e => e.IdPantalla).ValueGeneratedNever();

                entity.Property(e => e.Abreviacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Icon)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IsMenu).HasColumnName("isMenu");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("Perfil", "Seguridad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);

                entity.Property(e => e.Perfil1)
                    .IsRequired()
                    .HasColumnName("Perfil")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);

                entity.ToTable("Permiso", "Seguridad");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);

                entity.HasOne(d => d.IdPantallaNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.IdPantalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_Pantalla");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_Permiso");

                entity.HasOne(d => d.IdPermisoNameNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.IdPermisoName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_PermisoName");

                entity.HasOne(d => d.LoginCreacionNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.LoginCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_Usuario");
            });

            modelBuilder.Entity<PermisoName>(entity =>
            {
                entity.HasKey(e => e.IdPermisoName);

                entity.ToTable("PermisoName", "Seguridad");

                entity.Property(e => e.IdPermisoName).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecintoEquivalencia>(entity =>
            {
                entity.HasKey(e => e.IdRecintoRrhh);

                entity.ToTable("RecintoEquivalencia", "Catalogo");

                entity.Property(e => e.IdRecintoRrhh)
                    .HasColumnName("IdRecintoRRHH")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Login);

                entity.ToTable("Usuario", "Seguridad");

                entity.HasIndex(e => e.Login)
                    .HasName("IX_Usuario");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<UsuarioPerfil>(entity =>
            {
                entity.HasKey(e => new { e.IdPerfil, e.Login });

                entity.ToTable("UsuarioPerfil", "Seguridad");

                entity.Property(e => e.Login).HasMaxLength(20);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LoginCreacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LoginEliminacion).HasMaxLength(20);

                entity.Property(e => e.LoginModificacion).HasMaxLength(20);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.UsuarioPerfil)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioPerfil_Perfil");

                entity.HasOne(d => d.LoginNavigation)
                    .WithMany(p => p.UsuarioPerfil)
                    .HasForeignKey(d => d.Login)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioPerfil_Usuario");
            });
        }
    }
}
