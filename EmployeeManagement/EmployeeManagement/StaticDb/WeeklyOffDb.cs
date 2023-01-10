using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.StaticDb
{
    public class WeeklyOffList : List<WeeklyOffModel>
    {
        public WeeklyOffList()
        {
            weeklyoffs.Add(new SelectListItem("Sat-Sun", "Sat-Sun"));
            weeklyoffs.Add(new SelectListItem("Sat", "Sat"));
            weeklyoffs.Add(new SelectListItem("Sun", "Sun"));
        }

        public static List<SelectListItem> weeklyoffs = new List<SelectListItem>();
    }

    public class WeeklyOffModel
    {
        public string WeeklyOff { get; set; }
    }
}
