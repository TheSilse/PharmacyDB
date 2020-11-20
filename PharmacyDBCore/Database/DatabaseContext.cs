using System.Collections;
using Microsoft.EntityFrameworkCore;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.Services;

namespace PharmacyDBCore.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Settings.ConnectionString);
        }
        
    }
}
