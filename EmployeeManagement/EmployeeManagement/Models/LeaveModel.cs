using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class LeaveModel
    {
        public int EmployeeId { get; set; }
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
