using EmpManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("LeaveMaster")]
    public class LeaveModel
    {
        [Key]
        public int LeaveId { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }     
    
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }

        [Display(Name = "Leave Date From")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LeaveDateFrom { get; set; }

        [Display(Name = "Leave Date To")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LeaveDateTo { get; set; }

        public string Status { get; set; }
        public string Remark { get; set; }

        [Display(Name = "Approved Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LeaveApprovedDate { get; set; }

        [Display(Name = "Approve Remark")]
        public string ApproveRemark { get; set; }
    }

    public class LeaveApproveModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Key]
        public int LeaveId { get; set; }

        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }

        [Display(Name = "Date From")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LeaveDateFrom { get; set; }

        [Display(Name = "Date To")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LeaveDateTo { get; set; }

        [Display(Name = "Approved Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LeaveApprovedDate { get; set; }

        public string Status { get; set; }

        [Display(Name = "Approve Remark")]
        public string ApproveRemark { get; set; }
        public string Remark { get; set; }
    }
}
