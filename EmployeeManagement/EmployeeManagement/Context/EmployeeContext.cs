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
        public DbSet<ConsultantModel> consultants { get; set; }
        public DbSet<LeaveModel> leaves { get; set; }
        public DbSet<InvestmentModel> investments { get; set; }
        public DbSet<SalaryStructureModel> salaryStructures { get; set; }
      //  public DbSet<SalaryModel> salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<LeaveModel>().HasNoKey();
            modelBuilder.Entity<LeaveModel>(entity =>
            {
                entity.HasKey(x => x.LeaveId);

            });

            modelBuilder.Entity<InvestmentModel>(entity =>
            {
                entity.HasKey(x => x.InvestmentId);

            });
            modelBuilder.Entity<SalaryStructureModel>(entity =>
            {
                entity.HasKey(x => x.SalaryStructureId);

            });
            //modelBuilder.Entity<SalaryModel>(entity =>
            //{
            //    entity.HasKey(x => x.SalaryId);

            //});
            base.OnModelCreating(modelBuilder);
        }
      //  public DbSet<SalaryModel> salaries { get; set; }

      //  public DbSet<EmployeeManagement.Models.LeaveApproveModel> LeaveApproveModel { get; set; }
    }
}
