using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hospital_aspNetCoreWebApp_ModelViewControl.Models;

#nullable disable

namespace Hospital_aspNetCoreWebApp_ModelViewControl.Data
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
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Encounter> Encounters { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<NursingUnit> NursingUnits { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Physician> Physicians { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual DbSet<UnitDoseOrder> UnitDoseOrders { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

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

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName).IsUnicode(false);

                entity.Property(e => e.ManagerFirstName).IsUnicode(false);

                entity.Property(e => e.ManagerLastName).IsUnicode(false);
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.PhysicianId, e.EncounterDateTime })
                    .HasName("pk_encounters");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__encounter__patie__3C69FB99");

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.Encounters)
                    .HasForeignKey(d => d.PhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__encounter__physi__3D5E1FD2");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ItemDescription).IsUnicode(false);

                entity.HasOne(d => d.PrimaryVendor)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.PrimaryVendorId)
                    .HasConstraintName("FK__items__primary_v__403A8C7D");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.MedicationId).ValueGeneratedNever();

                entity.Property(e => e.MedicationDescription).IsUnicode(false);

                entity.Property(e => e.PackageSize).IsUnicode(false);

                entity.Property(e => e.Sig).IsUnicode(false);

                entity.Property(e => e.Strength).IsUnicode(false);
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

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK__patients__provin__300424B4");
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.Property(e => e.PhysicianId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Specialty).IsUnicode(false);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceName).IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(e => e.PurchaseOrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderStatus).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__purchase___depar__4316F928");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__purchase___vendo__440B1D61");
            });

            modelBuilder.Entity<PurchaseOrderLine>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseOrderId, e.LineNum })
                    .HasName("pk_purchase_order_lines");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__purchase___item___4BAC3F29");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___purch__4AB81AF0");
            });

            modelBuilder.Entity<UnitDoseOrder>(entity =>
            {
                entity.Property(e => e.UnitDoseOrderId).ValueGeneratedNever();

                entity.Property(e => e.Dosage).IsUnicode(false);

                entity.Property(e => e.DosageRoute).IsUnicode(false);

                entity.Property(e => e.PharmacistInitials)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sig).IsUnicode(false);

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.UnitDoseOrders)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__unit_dose__medic__47DBAE45");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.UnitDoseOrders)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__unit_dose__patie__46E78A0C");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorId).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ContactFirstName).IsUnicode(false);

                entity.Property(e => e.ContactLastName).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.Property(e => e.VendorName).IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK__vendors__provinc__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
