using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clinica_Medica.Models
{
    public partial class clinicamedicadbContext : DbContext
    {
        public clinicamedicadbContext()
        {
        }

        public clinicamedicadbContext(DbContextOptions<clinicamedicadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pacientescita> Pacientescitas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=clinicamedicadb;uid=mauricio;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Pacientescita>(entity =>
            {
                entity.ToTable("pacientescitas");

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.DoctorNombre).HasMaxLength(100);

                entity.Property(e => e.FechaCita).HasColumnType("datetime");

                entity.Property(e => e.MotivoCita).HasMaxLength(255);

                entity.Property(e => e.NombrePaciente).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
