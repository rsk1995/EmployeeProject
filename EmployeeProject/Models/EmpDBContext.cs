using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Models
{
    public class EmpDBContext:DbContext
    {

        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base (options)
        {
            
        }

        public DbSet<Employee> Employee { get; set; }

    }
}
