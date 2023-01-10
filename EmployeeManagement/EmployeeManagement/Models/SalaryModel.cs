namespace EmployeeManagement.Models
{
    public class SalaryModel
    {
        public int EmployeeId { get; set; }
        public int BasicPay { get; set; }
        public int HRA { get; set; }
        public int TA { get; set; }
        public int DA { get; set; }
        public int OverTime { get; set; }
        public int WeekendWorked { get; set; }
    }

    public enum Calculation
    {
        HRA = 500,
        TA = 400,
        DA = 300,
        OverTime = 500,
        WeekendWorked = 800
    }
}
