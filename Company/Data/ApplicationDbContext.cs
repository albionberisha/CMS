using CompanyAndLibrary.Data.Entities.Company;
using CompanyAndLibrary.Data.Entities.Company.Library;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace CompanyAndLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocations { get; set; }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<ReaderPhoneNumber> ReaderPhoneNumbers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<InCat> InCats { get; set; }
        public DbSet<Publishes> Publishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many: Department -> Employees
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-One: Department -> Manager (Each department has one manager)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne(m => m.Department)
                .HasForeignKey<Manager>(m => m.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many: Department -> Projects
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Department -> DepartmentLocations
            modelBuilder.Entity<DepartmentLocation>()
                .HasOne(dl => dl.Department)
                .WithMany(d => d.Locations)
                .HasForeignKey(dl => dl.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many: Employee -> Projects
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ensure Employee Cannot Work on Overlapping Projects
            modelBuilder.Entity<EmployeeProject>()
                .HasIndex(ep => new { ep.EmployeeId, ep.StartTime, ep.EndTime })
                .IsUnique();

            // One-to-One: Employee -> Address
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Employee)
                .WithOne()
                .HasForeignKey<Address>(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure composite key for ReaderPhoneNumber
            modelBuilder.Entity<ReaderPhoneNumber>()
                .HasKey(rp => new { rp.ReaderNr, rp.PhoneNumber });

            // Configure composite key for Borrows
            modelBuilder.Entity<Borrow>()
                .HasKey(b => new { b.ReaderNr, b.CopyNr });

            // Configure composite key for InCat
            modelBuilder.Entity<InCat>()
                .HasKey(ic => new { ic.Isbn, ic.CatName });

            // Configure composite key for Publishes
            modelBuilder.Entity<Publishes>()
                .HasKey(p => new { p.Isbn, p.PubName });

            base.OnModelCreating(modelBuilder);
        }
    }


}
