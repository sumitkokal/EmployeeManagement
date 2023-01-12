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
using EmpManagement.Models;
using EmployeeManagement.StaticDb;

namespace EmployeeManagement.Controllers
{
    public class InvestmentController : Controller
    {
        private readonly EmployeeContext _context;

        public InvestmentController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Investment
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                if (User.Identity.Name != "admin@nitor.com")
                {
                    var loggedInUser = HttpContext.Session.GetSessionObject<EmployeeModel>("loginUser");
                    var investmentsByEmp = (await _context.investments.ToArrayAsync()).Where(c => c.EmployeeId == loggedInUser.EmployeeId).ToList();
                    return View(investmentsByEmp);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Investment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investmentModel = await _context.investments
                .FirstOrDefaultAsync(m => m.InvestmentId == id);
            if (investmentModel == null)
            {
                return NotFound();
            }

            return View(investmentModel);
        }

        // GET: Investment/Create
        public IActionResult Create()
        {
            // var empList = (await _signInManager.UserManager.Users.ToListAsync());
            //var empList = (await _context.employees.ToListAsync());
            // var roleList = (await _roleManager.Roles.ToListAsync());
            InvestmentDb investments = new InvestmentDb();
            ViewBag.InvestmentTypeList = InvestmentDb.investmentList;
            return View();
        }

        // POST: Investment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvestmentId,EmployeeId,InvestmentType,InvestmentName,Amount,StartDate,EndDate")] InvestmentModel investmentModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.loginUser = HttpContext.Session.GetSessionObject<EmployeeModel>("loginUser");
                investmentModel.EmployeeId = ViewBag.loginUser.EmployeeId;
                _context.investments.Add(investmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investmentModel);
        }

        // GET: Investment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investmentModel = await _context.investments.FindAsync(id);
            if (investmentModel == null)
            {
                return NotFound();
            }
            return View(investmentModel);
        }

        // POST: Investment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvestmentId,EmployeeId,InvestmentType,InvestmentName,Amount,StartDate,EndDate")] InvestmentModel investmentModel)
        {
            if (id != investmentModel.InvestmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentModelExists(investmentModel.InvestmentId))
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
            return View(investmentModel);
        }

        // GET: Investment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investmentModel = await _context.investments
                .FirstOrDefaultAsync(m => m.InvestmentId == id);
            if (investmentModel == null)
            {
                return NotFound();
            }

            return View(investmentModel);
        }

        // POST: Investment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investmentModel = await _context.investments.FindAsync(id);
            _context.investments.Remove(investmentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentModelExists(int id)
        {
            return _context.investments.Any(e => e.InvestmentId == id);
        }
    }
}
