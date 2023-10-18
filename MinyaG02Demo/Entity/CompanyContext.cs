using Microsoft.EntityFrameworkCore;
using MinyaG02Demo.Models;

namespace MinyaG02Demo.Entity
{
    public class CompanyContext :DbContext
    {
        public CompanyContext()
        {
            
        }
        public CompanyContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
