using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Medications_aspNetCoreWebAPI.Models
{
    public partial class CHDBContext : DbContext
    {
        public CHDBContext()
        {
        }

        public CHDBContext(DbContextOptions<CHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medication> Medications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=CHDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("medications");

                entity.Property(e => e.MedicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("medication_id");

                entity.Property(e => e.LastPrescribedDate)
                    .HasColumnType("date")
                    .HasColumnName("last_prescribed_date");

                entity.Property(e => e.MedicationCost)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("medication_cost");

                entity.Property(e => e.MedicationDescription)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("medication_description");

                entity.Property(e => e.PackageSize)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("package_size");

                entity.Property(e => e.Sig)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sig");

                entity.Property(e => e.Strength)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strength");

                entity.Property(e => e.UnitsUsedYtd).HasColumnName("units_used_ytd");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
