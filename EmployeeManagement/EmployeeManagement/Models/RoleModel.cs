﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    [Table("RoleMaster")]
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }    
    }
}
