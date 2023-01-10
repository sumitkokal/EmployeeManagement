using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpManagement.Models;
using EmployeeManagement.Context;
using EmployeeManagement.CustomSessions;
using EmployeeManagement.Data;
using EmployeeManagement.StaticDb;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.employees.ToListAsync());
        }



        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            // Get Role list
            var roleData = _context.roles.ToList();
            var RoleSelect = new List<SelectListItem>();
            foreach (var item in roleData)
            {
                RoleSelect.Add(new SelectListItem(item.RoleName, item.RoleId.ToString()));
            }
            ViewBag.RoleList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("RoleList", RoleSelect);
            ViewBag.RoleList = RoleSelect;

            // Get Manager List from Emp
            var managerData = _context.employees.ToList().Where(c => c.Role == 1).ToList();
            var ManagerSelect = new List<SelectListItem>();
            foreach (var item in managerData)
            {
                ManagerSelect.Add(new SelectListItem(item.FirstName + " " + item.LastName, item.EmployeeId.ToString()));
            }
            ViewBag.ManagerList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("ManagerList", ManagerSelect);
            ViewBag.ManagerList = ManagerSelect;

            QualificationList qualifications = new QualificationList();
            WeeklyOffList weeklyOffs = new WeeklyOffList();

            // var test = QualificationList.qualifications.ToList();
            //ViewBag.QualificationList = getSelectList((test);
            ViewBag.QualificationList = QualificationList.qualifications;
            ViewBag.WeeklyoffList = WeeklyOffList.weeklyoffs;
            return View();
        }


        public List<SelectListItem> getSelectList(List<SelectListItem> listItems)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in listItems)
            {
                selectList.Add(new SelectListItem(item.Text, item.Value.ToString()));
            }
            return selectList;
        }
        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeCode,FirstName,LastName,EmailId,DepartmentId,Role,Designation,ReportingManager,DateOfBirth,Gender,Qualification,Stream,TotalExperiance,PositionType,TotalLeaveProvide,WeeklyOff,PrivilegeLeave,CasualLeave,MobileNo,BankName,IFSCCode")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.employees.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeCode,FirstName,LastName,EmailId,DepartmentId,Role,Designation,ReportingManager,DateOfBirth,Gender,Qualification,Stream,TotalExperiance,PositionType,TotalLeaveProvide,WeeklyOff,PrivilegeLeave,CasualLeave,MobileNo,BankName,IFSCCode")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeModel = await _context.employees.FindAsync(id);
            _context.employees.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeModelExists(int id)
        {
            return _context.employees.Any(e => e.EmployeeId == id);
        }
    }
}
