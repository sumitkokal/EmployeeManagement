using EmpManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> employees { get; set; }
        public DbSet<RoleModel> roles { get; set; }
        public DbSet<ConsultantModel> consultants { get; set; }
    }
}
