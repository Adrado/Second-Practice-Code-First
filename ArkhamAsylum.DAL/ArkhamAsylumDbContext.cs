using ArkhamAsylum.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace ArkhamAsylum.Lib.DAL
{
    public class ArkhamAsylumDbContext : DbContext
    {
        public ArkhamAsylumDbContext(DbContextOptions<ArkhamAsylumDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosis>()
                .HasOne(p => p.Record)
                .WithOne(i => i.Diagnosis)
                .HasForeignKey<Record>(b => b.DiagnosisId);

            modelBuilder.Entity<Record>()
                .HasOne(p => p.Diagnosis)
                .WithOne(i => i.Record)
                .HasForeignKey<Diagnosis>(b => b.RecordId);
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<NurseRoomAssignation> NurseRoomAssignations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
