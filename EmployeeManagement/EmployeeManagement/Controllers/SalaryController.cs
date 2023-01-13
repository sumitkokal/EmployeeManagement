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
using EmpManagement.Models;
using EmployeeManagement.StaticDb;

namespace EmployeeManagement.Controllers
{
    public class SalaryController : Controller
    {
        EmployeeContext _employeeContext;
        public SalaryController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.ShowData = false;
            if (User.Identity.Name != null)
            {
                if (User.Identity.Name != "admin@nitor.com")
                {
                    if (User.Identity.Name == "accountant@nitor.com")
                    {
                        //var salaryByEmp = (await _employeeContext.salaries.ToArrayAsync()).Where(c => c.EmployeeId == loggedInUser.EmployeeId).ToList();
                        return View(await _employeeContext.salaries.ToArrayAsync());
                    }
                    else
                    {
                        var loggedInUser = HttpContext.Session.GetSessionObject<EmployeeModel>("loginUser");

                        var salaryByEmp = (await _employeeContext.salaries.ToArrayAsync()).Where(c => c.EmployeeId == loggedInUser.EmployeeId).ToList();
                        return View(salaryByEmp);
                    }                    
                }                
                else
                {
                    //List<SalaryModel> leaveApproveList = await GetLeaveForApprove();
                    return View("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Create()
        {           
            var SStructureList = (await _employeeContext.salaryStructures.ToListAsync()).Where(c => c.Role == "Staff");
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
            var data = HttpContext.Session.GetSessionObject<SalaryModel>("SelectedStaffDetails");
            salaryModel.EmployeeId = data.EmployeeId;
            salaryModel.SalaryStructureId = data.SalaryStructureId;
            salaryModel.Role = "Staff";
            if (ModelState.IsValid)
            {
                _employeeContext.salaries.Add(salaryModel);
                await _employeeContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public IActionResult GetSalaryStrucId(SalaryModel salaryStruct)
        {
            ViewBag.ShowData = true;
            MonthDb month = new MonthDb();
            ViewBag.MonthList = MonthDb.monthList;
            ViewBag.SalaryStructureList = HttpContext.Session.GetSessionObject<List<SelectListItem>>("SalaryStructureList");
            var getSalStructure = _employeeContext.salaryStructures.ToList().Where(c => c.SalaryStructureId == salaryStruct.SalaryStructureId).ToList()[0];

            salaryStruct.BasicPay = getSalStructure.BasicPay;
            salaryStruct.DA = getSalStructure.DA;
            salaryStruct.TA = getSalStructure.TA;
            salaryStruct.HRA = getSalStructure.HRA;
            salaryStruct.EmployeeId = getSalStructure.EmployeeId;
            salaryStruct.SalaryStructureId = getSalStructure.SalaryStructureId;
            var getLeavesCount = _employeeContext.leaves.ToList().Where(c => c.EmployeeId == getSalStructure.EmployeeId).Count();

            salaryStruct.LeavesTaken = getLeavesCount * Convert.ToInt32(LeaveCalculation.LeaveTakenCost);
            salaryStruct.OverTime = 0;
            salaryStruct.WeekendWorked = 0;

            salaryStruct.GrossSalary = salaryStruct.BasicPay + salaryStruct.DA + salaryStruct.TA + salaryStruct.HRA + salaryStruct.LeavesTaken;

            if (salaryStruct.GrossSalary > 50000)
            {
                salaryStruct.TDS = salaryStruct.GrossSalary * 10 / 100;
                salaryStruct.Total = salaryStruct.GrossSalary - salaryStruct.TDS;
            }

            HttpContext.Session.SetSessionObject<SalaryModel>("SelectedStaffDetails", salaryStruct);
            return View("Create", salaryStruct);
        }
    }
}
