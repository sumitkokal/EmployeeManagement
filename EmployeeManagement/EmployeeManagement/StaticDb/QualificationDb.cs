using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{ 
    public class QualificationModel
    {
        public string Qualification { get; set; }
    } 

    public class QualificationList : List<QualificationModel>
    {
        public QualificationList()
        {            
            qualifications.Add(new SelectListItem("Engineering", "Engineering"));
            qualifications.Add(new SelectListItem("Business", "Business"));
            qualifications.Add(new SelectListItem("BBA", "BBA"));
            qualifications.Add(new SelectListItem("BCA", "BCA"));
        }

        public static List<SelectListItem> qualifications = new List<SelectListItem>();
    }   
}
