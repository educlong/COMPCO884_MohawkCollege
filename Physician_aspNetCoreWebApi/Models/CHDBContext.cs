using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Physician_aspNetCoreWebApi.Models
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
            modelBuilder.Entity<Physician>(entity =>
            {
                entity.ToTable("physicians");

                entity.Property(e => e.PhysicianId)
                    .ValueGeneratedNever()
                    .HasColumnName("physician_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.OhipRegistration).HasColumnName("ohip_registration");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Specialty)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("specialty");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
