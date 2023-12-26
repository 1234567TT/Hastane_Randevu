using B201210597.Models.DTO.Hastane_Randevu.Models;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace B201210597.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
       
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Users> Userss { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


          
            base.OnModelCreating(modelBuilder);

            // IdentityUserLogin<string> için anahtar tanımı
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(p => new { p.LoginProvider, p.ProviderKey });

            // Diğer konfigürasyonlar buraya eklenebilir.
        

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