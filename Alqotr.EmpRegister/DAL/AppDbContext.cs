

using Microsoft.EntityFrameworkCore;

namespace Alqotr.EmpRegister.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
           .HasKey(e => e.EmployeeId); // Primary key

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd(); // Auto-increment
            modelBuilder.Entity<LeaveApplication>()
          .HasKey(e => e.LeaveApplicationId); // Primary key

            modelBuilder.Entity<LeaveApplication>()
                .Property(e => e.LeaveApplicationId)
                .ValueGeneratedOnAdd(); // Auto-increment
            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "John Doe", JobNumber = "JD001", MobileNumber = "123456789", Address = "123 Main St", Notes = "No notes" },
                new Employee { EmployeeId = 2, Name = "Jane Smith", JobNumber = "JS002", MobileNumber = "987654321", Address = "456 Elm St", Notes = "Manager" }
            );

            // Seed data for VacationTypes
            modelBuilder.Entity<VacationType>().HasData(
                new VacationType { VacationTypeId = 1, TypeName = "Annual Leave" },
                new VacationType { VacationTypeId = 2, TypeName = "Sick Leave" }
            );

            // Seed data for LeaveApplications
            modelBuilder.Entity<LeaveApplication>().HasData(
                new LeaveApplication
                {
                    LeaveApplicationId = 1,
                    EmployeeId = 1, // John Doe
                    VacationTypeId = 1, // Annual Leave
                    Reason = "Vacation",
                    FromDate = new DateTime(2023, 1, 10),
                    ToDate = new DateTime(2023, 1, 20),
                    Notes = "Family vacation"
                },
                new LeaveApplication
                {
                    LeaveApplicationId = 2,
                    EmployeeId = 2, // Jane Smith
                    VacationTypeId = 2, // Sick Leave
                    Reason = "Medical reasons",
                    FromDate = new DateTime(2023, 5, 5),
                    ToDate = new DateTime(2023, 5, 12),
                    Notes = "Sick leave for surgery"
                }
            );
        }

    }


}
