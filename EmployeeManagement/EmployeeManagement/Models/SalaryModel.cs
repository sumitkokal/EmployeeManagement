using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    [Table("SalaryMaster")]
    public class SalaryModel
    {
        [Key]
        public int SalaryId { get; set; }
        [ForeignKey("EmployeeId")]
        public string Role { get; set; }
        public int SalaryStructureId { get; set; }
        public int EmployeeId { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int BasicPay { get; set; }
        [Display(Name = "House Rent Allowance")]
        public int HRA { get; set; }
        [Display(Name = "Travelling Allowance")]
        public int TA { get; set; }
        [Display(Name = "Dearness Allowance")]
        public int DA { get; set; }

        [Display(Name = "Over Time")]
        public int OverTime { get; set; }

        [Display(Name = "Leaves Taken")]
        public int LeavesTaken { get; set; }

        [Display(Name = "Weekend Worked")]
        public int WeekendWorked { get; set; }

        [Display(Name = "Gross Salary")]
        public int GrossSalary { get; set; }
        public double TDS { get; set; }
        public double Total { get; set; }
        //  public int GrossAnnualSalary { get; set; }
    }

    [Table("SalaryStructureMaster")]
    public class SalaryStructureModel
    {
        //SalaryStructure
        [Key]
        public int SalaryStructureId { get; set; }
        public string Role { get; set; }
       // [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        [Display(Name = "Basic Pay")]
        public int BasicPay { get; set; }
        [Display(Name = "House Rent Allowance")]
        public int HRA { get; set; }
        [Display(Name = "Travelling Allowance")]
        public int TA { get; set; }
        [Display(Name = "Dearness Allowance")]
        public int DA { get; set; }
        //public int OverTime { get; set; }
        //public int WeekendWorked { get; set; }
        public int GrossSalary { get; set; }
        //public int GrossAnnualSalary { get; set; }
    }

    public enum LeaveCalculation
    {
        //HRA = 500,
        //TA = 400,
        //DA = 300,
        //OverTime = 500,
        //WeekendWorked = 800
        OverTimeCost = 200,
        WeekendWorkedCost = 300,
        LeaveTakenCost = 500
    }
}
