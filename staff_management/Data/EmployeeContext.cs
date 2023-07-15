using Microsoft.EntityFrameworkCore;
using staff_management.Models;
namespace staff_management.Data;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Employee> MyEmployees { get; set; }
} 