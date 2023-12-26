using Hastane_Randevu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Randevu.Data
{
    public class HospitalDbContext : IdentityDbContext<User>
    {
        
       
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Clinic> Clinics{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Doctor> Doctors{ get; set; }
        public DbSet<Appointment> Appointments{ get; set; }
        public DbSet<Users> Userss{ get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-P8KNDOA;Initial Catalog=Bessam_Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri tanımla
            modelBuilder.Entity<Clinic>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Clinics)
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.ClinicId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Users)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UsersId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
        }
    }
}
