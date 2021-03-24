using Clinic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<AdmissionPadiatricandNeonate> AdmissionPadiatricandNeonates { get; set; }
        public DbSet<PatientType> PatientTypes { get; set; }
        public DbSet<PadiatricandNeonate> PadiatricandNeonates { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmissionPadiatricandNeonate>().HasKey(k => new { k.AdmissionId, k.PadiatricandNeonateId });
            modelBuilder.Entity<Admission>().HasOne(a => a.PatientType).WithMany(p => p.AdmissionTypes).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Admission>().HasOne(a => a.PatientSubType).WithMany(p => p.AdmissionsSubTypes).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
