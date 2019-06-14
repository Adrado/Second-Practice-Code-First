using ArkhamAsylum.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace ArkhamAsylum.Lib.DAL
{
    public class ArkhamAsylumDbContext : DbContext
    {
        public ArkhamAsylumDbContext(DbContextOptions<ArkhamAsylumDbContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<NurseRoomAssignation> NurseRoomAssignations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
