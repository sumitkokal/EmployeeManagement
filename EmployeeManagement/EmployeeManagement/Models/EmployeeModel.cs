using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpManagement.Models
{
    [Table("EmployeeMaster")]
    public class EmployeeModel
    {
        [Key]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Display(Name = "Emp Code")]
        //[Required(ErrorMessage = "Employee code is required")]
        public string EmployeeCode { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        // [Required(ErrorMessage = "Department is required")]
        //public int DepartmentId { get; set; }
        
        public int  Role { get; set; }
      //  public RoleModel role { get; set; }

        //  public string LastCompanyName { get; set; }

        public string Designation { get; set; }

        //public string DateOfJoining { get; set; }
        [Display(Name = "Reporting Manager")]
        public int ReportingManager { get; set; }

        //public string ReportingManager2 { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Qualification { get; set; }

        // public string Stream { get; set; }

        // Column[TypeName = "char(2)"]
        // [RegularExpression(@"^[0-9]{2,2}$", ErrorMessage = "Must be two digits numbers"), StringLength(2)]
        //  [Range(1, 2)]

        [Display(Name = "Date of Birth")]
        public int TotalExperiance { get; set; }

        //   public string PositionType { get; set; }

        // public string PersonelEmailId { get; set; }

        // public string MotherName { get; set; }

        //   public string BloodGroup { get; set; }
        //   public string MaritalStatus { get; set; }
        //   public string MarrigeAnniversaryDate { get; set; }
        //  public string UserType { get; set; }

        [Display(Name = "Leave Provide")]
        public string TotalLeaveProvide { get; set; }

        [Display(Name = "Weekly Off")]
        public string WeeklyOff { get; set; }

        [Display(Name = "Privilege Leave")]
        public string PrivilegeLeave { get; set; }

        [Display(Name = "Casual Leave")]
        public string CasualLeave { get; set; }

        [Required(ErrorMessage = "Mobile No is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile No")]
        [MaxLength(10, ErrorMessage = "10 digit number is required")]
        public string MobileNo { get; set; }

        //   public string AlternateMobileNo { get; set; }
        //  public string CurrentAddress { get; set; }
        // public string PermanentAddress { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; }
        //public string RequestResignationDate { get; set; }
        //public string ApprovedResignationDate { get; set; }
        //public string RequestRelievingDate { get; set; }
        //public string ApprovedRelievingDate { get; set; }
    }
}
