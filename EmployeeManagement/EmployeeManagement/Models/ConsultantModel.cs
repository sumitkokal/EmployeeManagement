using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    [Table("ConsultantMaster")]
    public class ConsultantModel
    {
        [Key]
        [Display(Name = "Consultant Id")]
        public string ConsultantId { get; set; }

        [Display(Name = "Consultant Name")]
        [Required(ErrorMessage = "Employee code is required")]
        public string ConsultantName { get; set; }

        [Display(Name = "Consultant Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile No is required")]
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
    }
}
