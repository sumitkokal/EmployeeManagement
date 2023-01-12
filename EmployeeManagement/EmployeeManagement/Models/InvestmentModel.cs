using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("InvestmentMaster")]
    public class InvestmentModel
    {
        [Key]
        public int InvestmentId { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        [Display(Name = "Investment Type")]
        public string InvestmentType { get; set; }

        [Display(Name = "Investment Name")]
        public string InvestmentName { get; set; }

        [RegularExpression("([0-9]+)")]
    //    [Range(0, 15, ErrorMessage = "Can only be between 0 .. 10")]
        [Display(Name = "Investment Amount")]
        public string Amount { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
