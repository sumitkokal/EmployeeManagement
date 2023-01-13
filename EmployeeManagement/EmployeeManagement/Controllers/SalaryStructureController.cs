using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Context;
using EmployeeManagement.Models;
using EmployeeManagement.CustomSessions;

namespace EmployeeManagement.Controllers
{
    public class SalaryStructureController : Controller
    {
        private readonly EmployeeContext _context;

        public SalaryStructureController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: SalaryStructure
        public async Task<IActionResult> Index()
        {
            return View(await _context.salaryStructures.ToListAsync());
        }

        // GET: SalaryStructure/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryStructureModel = await _context.salaryStructures
                .FirstOrDefaultAsync(m => m.SalaryStructureId == id);
            if (salaryStructureModel == null)
            {
                return NotFound();
            }

            return View(salaryStructureModel);
        }

        // GET: SalaryStructure/Create
        public async Task<IActionResult> Create()
        {
            var empList = (await _context.employees.ToListAsync());
            var EmployeeSelect = new List<SelectListItem>();
            foreach (var item in empList)
            {
                EmployeeSelect.Add(new SelectListItem(item.FirstName + " " + item.LastName, item.EmployeeId.ToString()));
            }
            ViewBag.EmployeeList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("EmployeeList", EmployeeSelect);
            ViewBag.EmployeeList = EmployeeSelect;
            return View();
        }

        // POST: SalaryStructure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryStructureId,EmployeeId,BasicPay,HRA,TA,DA,OverTime,WeekendWorked,GrossSalary,Role")] SalaryStructureModel salaryStructureModel)
        {
            if (ModelState.IsValid)
            {
                salaryStructureModel.Role = "Staff";
                salaryStructureModel.GrossSalary = salaryStructureModel.BasicPay + salaryStructureModel.DA + salaryStructureModel.HRA + salaryStructureModel.TA;
                _context.Add(salaryStructureModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryStructureModel);
        }

        // GET: SalaryStructure/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryStructureModel = await _context.salaryStructures.FindAsync(id);
            if (salaryStructureModel == null)
            {
                return NotFound();
            }
            return View(salaryStructureModel);
        }

        // POST: SalaryStructure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryStructureId,EmployeeId,BasicPay,HRA,TA,DA,OverTime,WeekendWorked,GrossSalary,GrossAnnualSalary")] SalaryStructureModel salaryStructureModel)
        {
            if (id != salaryStructureModel.SalaryStructureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryStructureModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryStructureModelExists(salaryStructureModel.SalaryStructureId))
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
            return View(salaryStructureModel);
        }

        // GET: SalaryStructure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryStructureModel = await _context.salaryStructures
                .FirstOrDefaultAsync(m => m.SalaryStructureId == id);
            if (salaryStructureModel == null)
            {
                return NotFound();
            }

            return View(salaryStructureModel);
        }

        // POST: SalaryStructure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryStructureModel = await _context.salaryStructures.FindAsync(id);
            _context.salaryStructures.Remove(salaryStructureModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryStructureModelExists(int id)
        {
            return _context.salaryStructures.Any(e => e.SalaryStructureId == id);
        }
    }
}
