using CarWash2.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWash2.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CustomerCar> CustomerCars { get; set; } = null!;
        public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
