using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LPBD_Backend.Models
{
    public partial class LPBD_BDContext : DbContext
    {
        public LPBD_BDContext()
        {
        }

        public LPBD_BDContext(DbContextOptions<LPBD_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleHito> DetalleHitos { get; set; } = null!;
        public virtual DbSet<DetalleTarea> DetalleTareas { get; set; } = null!;
        public virtual DbSet<Hito> Hitos { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CRIS\\PRINCIPAL;Database=LPBD_BD;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleHito>(entity =>
            {
                entity.HasKey(e => e.IdDetHit);

                entity.Property(e => e.IdDetHit)
                    .ValueGeneratedNever()
                    .HasColumnName("idDetHit");

                entity.Property(e => e.IdHit).HasColumnName("idHit");

                entity.Property(e => e.IdTar).HasColumnName("idTar");

                entity.HasOne(d => d.IdHitNavigation)
                    .WithMany(p => p.DetalleHitos)
                    .HasForeignKey(d => d.IdHit)
                    .HasConstraintName("FK_DetalleHitos_Hitos");

                entity.HasOne(d => d.IdTarNavigation)
                    .WithMany(p => p.DetalleHitos)
                    .HasForeignKey(d => d.IdTar)
                    .HasConstraintName("FK_DetalleHitos_Tareas");
            });

            modelBuilder.Entity<DetalleTarea>(entity =>
            {
                entity.HasKey(e => e.IdDetTar);

                entity.Property(e => e.IdDetTar)
                    .ValueGeneratedNever()
                    .HasColumnName("idDetTar");

                entity.Property(e => e.IdPer).HasColumnName("idPer");

                entity.Property(e => e.IdTar).HasColumnName("idTar");

                entity.HasOne(d => d.IdPerNavigation)
                    .WithMany(p => p.DetalleTareas)
                    .HasForeignKey(d => d.IdPer)
                    .HasConstraintName("FK_DetalleTareas_Personal");

                entity.HasOne(d => d.IdTarNavigation)
                    .WithMany(p => p.DetalleTareas)
                    .HasForeignKey(d => d.IdTar)
                    .HasConstraintName("FK_DetalleTareas_Tareas");
            });

            modelBuilder.Entity<Hito>(entity =>
            {
                entity.HasKey(e => e.IdHit);

                entity.Property(e => e.IdHit)
                    .ValueGeneratedNever()
                    .HasColumnName("idHit");

                entity.Property(e => e.FecLimHit)
                    .HasColumnType("date")
                    .HasColumnName("fecLimHit");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPer);

                entity.ToTable("Personal");

                entity.Property(e => e.IdPer)
                    .ValueGeneratedNever()
                    .HasColumnName("idPer");

                entity.Property(e => e.CedPer)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cedPer");

                entity.Property(e => e.DispPer).HasColumnName("dispPer");

                entity.Property(e => e.IdRolPer).HasColumnName("idRolPer");

                entity.Property(e => e.NomPer)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomPer");

                entity.Property(e => e.PassPer)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("passPer");

                entity.Property(e => e.UserPer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userPer");

                entity.HasOne(d => d.IdRolPerNavigation)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.IdRolPer)
                    .HasConstraintName("FK_Personal_Roles");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdPro);

                entity.Property(e => e.IdPro)
                    .ValueGeneratedNever()
                    .HasColumnName("idPro");

                entity.Property(e => e.DescPro)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descPro");

                entity.Property(e => e.FecFinPro)
                    .HasColumnType("date")
                    .HasColumnName("fecFinPro");

                entity.Property(e => e.FecIniPro)
                    .HasColumnType("date")
                    .HasColumnName("fecIniPro");

                entity.Property(e => e.NomPro)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomPro");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol)
                    .ValueGeneratedNever()
                    .HasColumnName("idRol");

                entity.Property(e => e.DescRol)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descRol");

                entity.Property(e => e.NomRol)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomRol");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTar);

                entity.Property(e => e.IdTar)
                    .ValueGeneratedNever()
                    .HasColumnName("idTar");

                entity.Property(e => e.AvanceTar)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("avanceTar");

                entity.Property(e => e.DescTar)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descTar");

                entity.Property(e => e.EstTar).HasColumnName("estTar");

                entity.Property(e => e.FecFinTar)
                    .HasColumnType("date")
                    .HasColumnName("fecFinTar");

                entity.Property(e => e.FecIniTar)
                    .HasColumnType("date")
                    .HasColumnName("fecIniTar");

                entity.Property(e => e.IdProTar).HasColumnName("idProTar");

                entity.Property(e => e.NomTar)
                    .HasMaxLength(200)
                    .HasColumnName("nomTar");

                entity.HasOne(d => d.IdProTarNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdProTar)
                    .HasConstraintName("FK_Tareas_Proyectos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
