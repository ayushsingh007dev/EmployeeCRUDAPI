using Microsoft.EntityFrameworkCore;
using EmployeeCrudApi.Models;

namespace EmployeeCrudApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}