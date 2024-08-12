using Alef_Academy_Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alef_Academy_Main.Database
{
    public class AlefDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AlefDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ContactUs> contactus { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Internships> Internships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _configuration.GetConnectionString("AlefDatabaseConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<ContactUs>().Property(p => p.inquirydate).HasConversion(dateTimeConverter);
            modelBuilder.Entity<Courses>().Property(p => p.StartDate).HasConversion(dateTimeConverter);
            modelBuilder.Entity<Courses>().Property(p => p.EndDate).HasConversion(dateTimeConverter);
            modelBuilder.Entity<Enrollments>().Property(p => p.EnrollmentDate).HasConversion(dateTimeConverter);
            modelBuilder.Entity<Enrollments>().Property(p => p.CompletionDate).HasConversion(dateTimeConverter);
            modelBuilder.Entity<Internships>().Property(p => p.applicationdate).HasConversion(dateTimeConverter);

            modelBuilder.Entity<ContactUs>(entity =>
            {
                entity.ToTable("contactus");
                entity.HasKey(e => e.inquiryid);
            });

            modelBuilder.Entity<Courses>().HasKey(u => u.CourseId);
            modelBuilder.Entity<Enrollments>().HasKey(o => o.EnrollmentID);
            modelBuilder.Entity<Internships>(entity =>
            {
                entity.ToTable("internships");
                entity.HasKey(s => s.applicationid);
            });
        }
    }
}
