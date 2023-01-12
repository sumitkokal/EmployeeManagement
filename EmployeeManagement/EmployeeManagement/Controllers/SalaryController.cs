using EmployeeManagement.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagement.CustomSessions;
using System.Collections.Generic;
using EmployeeManagement.Models;
using System;

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
            var SStructureList = await _employeeContext.salaryStructures.ToListAsync();
            var EmpSelect = new List<SelectListItem>();
            foreach (var item in SStructureList)
            {
                var empData = await _employeeContext.employees.FirstOrDefaultAsync(m => m.EmployeeId == item.EmployeeId);
                EmpSelect.Add(new SelectListItem(empData.FirstName + " " + empData.LastName, item.SalaryStructureId.ToString()));
            }
            ViewBag.SalaryStructureList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("SalaryStructureList", EmpSelect);
            ViewBag.SalaryStructureList = EmpSelect;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalaryModel salaryModel)
        {
            if (ModelState.IsValid)
            {
                _employeeContext.Add(salaryModel);
                await _employeeContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public IActionResult GetSalaryStrucId(SalaryModel salaryStruct)
        {
            ViewBag.SalaryStructureList = HttpContext.Session.GetSessionObject<List<SelectListItem>>("SalaryStructureList");
            var getSalStructure = _employeeContext.salaryStructures.ToList().Where(c => c.SalaryStructureId == salaryStruct.SalaryStructureId).ToList()[0];

            salaryStruct.BasicPay = getSalStructure.BasicPay;
            salaryStruct.DA = getSalStructure.DA;
            salaryStruct.TA = getSalStructure.TA;
            salaryStruct.HRA = getSalStructure.HRA;

            var getLeavesCount = _employeeContext.leaves.ToList().Where(c => c.EmployeeId == getSalStructure.EmployeeId).Count();

            salaryStruct.LeavesTaken = getLeavesCount * Convert.ToInt32(LeaveCalculation.LeaveTakenCost);
            salaryStruct.OverTime = 0;
            salaryStruct.WeekendWorked = 0;

            salaryStruct.GrossSalary = salaryStruct.BasicPay + salaryStruct.DA + salaryStruct.TA + salaryStruct.HRA + salaryStruct.LeavesTaken;

            //ViewBag.EmployeeList = HttpContext.Session.GetSessionObject<List<SelectListItem>>("EmployeeList");

            return View("Create", salaryStruct);
        }
    }
}
