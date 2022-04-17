using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using final.Models;

#nullable disable

namespace final.Data
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

        public virtual DbSet<Admission> Admissions { get; set; }
        public virtual DbSet<NursingUnit> NursingUnits { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Physician> Physicians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=CHDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admission>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.AdmissionDate })
                    .HasName("pk_admissions");

                entity.Property(e => e.NursingUnitId).IsUnicode(false);

                entity.Property(e => e.PrimaryDiagnosis).IsUnicode(false);

                entity.Property(e => e.SecondaryDiagnoses).IsUnicode(false);

                entity.HasOne(d => d.AttendingPhysician)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.AttendingPhysicianId)
                    .HasConstraintName("FK__admission__atten__38996AB5");

                entity.HasOne(d => d.NursingUnit)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.NursingUnitId)
                    .HasConstraintName("FK__admission__nursi__398D8EEE");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__admission__patie__37A5467C");
            });

            modelBuilder.Entity<NursingUnit>(entity =>
            {
                entity.Property(e => e.NursingUnitId).IsUnicode(false);

                entity.Property(e => e.ManagerFirstName).IsUnicode(false);

                entity.Property(e => e.ManagerLastName).IsUnicode(false);

                entity.Property(e => e.Specialty).IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).ValueGeneratedNever();

                entity.Property(e => e.Allergies).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StreetAddress).IsUnicode(false);
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.Property(e => e.PhysicianId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Specialty).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
