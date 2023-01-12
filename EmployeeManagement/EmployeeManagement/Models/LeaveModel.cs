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
       

      //  [ForeignKey()]
        //public int EmployeeId { get; set; }
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }
        [Display(Name = "Leave Date From")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LeaveDateFrom { get; set; }
        [Display(Name = "Leave Date To")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LeaveDateTo { get; set; }
        public string Remark { get; set; }
    }
}
