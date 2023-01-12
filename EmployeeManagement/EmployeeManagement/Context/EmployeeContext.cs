using EmployeeManagement.Models;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Context
{
    [Authorize]
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> employees { get; set; }
      //  public DbSet<RoleModel> roles { get; set; }
        public DbSet<ConsultantModel> consultants { get; set; }
        public DbSet<LeaveModel> leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<LeaveModel>().HasNoKey();
            modelBuilder.Entity<LeaveModel>(entity =>
            {
                entity.HasKey(x => x.LeaveId);

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
