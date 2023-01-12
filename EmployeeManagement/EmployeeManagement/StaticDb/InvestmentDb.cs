using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.StaticDb
{
    public class InvestmentDb : List<InvestmentDbModel>
    {
        public InvestmentDb()
        {
            investmentList.Add(new SelectListItem("Insurance", "Insurance"));
            investmentList.Add(new SelectListItem("PPF", "PPF"));
        }

        public static List<SelectListItem> investmentList = new List<SelectListItem>();
    }

    public class InvestmentDbModel
    {
        public string WeeklyOff { get; set; }
    }
}
