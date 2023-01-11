using EmployeeManagement.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagement.CustomSessions;
using System.Collections.Generic;
using EmployeeManagement.Models;

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

        public IActionResult Test(int EmployeeId)
        {
            SalaryModel salary = new SalaryModel()
            {
                BasicPay = 1000,
                HRA = 100,
                TA = 200,
                OverTime = 500
            };
            ViewBag.EmployeeList = HttpContext.Session.GetCLRObject<List<SelectListItem>>("EmployeeList");
            ////ViewBag.Profile_Id = new SelectList(data, "Id", "Name", salary.EmployeeId);
            //var EmpSelect = new List<SelectListItem>();
            //var t = ViewBag.EmployeeList;
            ////  var text = data.Where(x => x.Selected).FirstOrDefault().Value;


            //var emp = salary.EmployeeId;
            return View("Create", salary);
        }
    }
}
