using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.StaticDb
{

    public class MonthDb : List<WeeklyOffModel>
    {
        public MonthDb()
        {
            monthList.Add(new SelectListItem("Jan", "Jan"));
            monthList.Add(new SelectListItem("Feb", "Feb"));
            monthList.Add(new SelectListItem("March", "March"));
            monthList.Add(new SelectListItem("April", "April"));
            monthList.Add(new SelectListItem("May", "May"));
            monthList.Add(new SelectListItem("June", "June"));
            monthList.Add(new SelectListItem("July", "July"));
            monthList.Add(new SelectListItem("Aug", "Aug"));
            monthList.Add(new SelectListItem("Sept", "Sept"));
            monthList.Add(new SelectListItem("Oct", "Oct"));
            monthList.Add(new SelectListItem("NOv", "NOv"));
            monthList.Add(new SelectListItem("Dec", "Dec"));
        }

        public static List<SelectListItem> monthList = new List<SelectListItem>();
    }

    public class MonthModel
    {
        public string Month { get; set; }
    }
}
