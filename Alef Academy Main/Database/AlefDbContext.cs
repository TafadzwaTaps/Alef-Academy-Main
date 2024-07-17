using Alef_Academy_Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Alef_Academy_Main.Database
{
    public class AlefDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AlefDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Payments> Payments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("AlefDatabaseConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactUs>().HasKey(p => p.InquiryId);
            modelBuilder.Entity<Courses>().HasKey(u => u.CourseId);
            modelBuilder.Entity<Enrollments>().HasKey(o => o.EnrollmentID);
            modelBuilder.Entity<Internship>().HasKey(s => s.ApplicationId);
            modelBuilder.Entity<Payments>().HasKey(r => r.Id);

        }
    }
}
