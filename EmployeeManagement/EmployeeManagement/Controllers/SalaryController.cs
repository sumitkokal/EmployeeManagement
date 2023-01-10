using EmployeeManagement.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagement.CustomSessions;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    public class SalaryController : Controller
    {
        EmployeeContext _employeeContext;
        public SalaryController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var empList = await _employeeContext.employees.ToListAsync();
            var EmpSelect = new List<SelectListItem>();
            foreach (var item in empList)
            {
                EmpSelect.Add(new SelectListItem(item.FirstName + " " + item.LastName, item.EmployeeId.ToString()));
            }
            ViewBag.RoleList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("EmployeeList", EmpSelect);
            ViewBag.EmployeeList = EmpSelect;
            return View();
        }
    }
}
