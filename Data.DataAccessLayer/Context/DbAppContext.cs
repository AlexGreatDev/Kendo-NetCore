using Data.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccessLayer.Context
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(employee => new { employee.EmployeeLastName ,employee.EmployeeFirstName })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets

        public DbSet<Employee> Employee { get; set; }

        #endregion
    }
}
