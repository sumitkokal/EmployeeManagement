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
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        private readonly EmployeeContext _context;

        public LeaveController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Leave
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                if (User.Identity.Name != "admin@nitor.com")
                {
                    var loggedInUser = HttpContext.Session.GetCLRObject<EmployeeModel>("loginUser");

                    var leavesByEmp = (await _context.leaves.ToArrayAsync()).Where(c => c.EmployeeId == loggedInUser.EmployeeId).ToList();
                    //   var await _context.leaves.ToListAsync()
                    return View(leavesByEmp);
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

        // GET: Leave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveModel = await _context.leaves
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leaveModel == null)
            {
                return NotFound();
            }

            return View(leaveModel);
        }

        // GET: Leave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveId,EmployeeId,LeaveType,LeaveDateFrom,LeaveDateTo,Remark")] LeaveModel leaveModel)
        {
            ViewBag.loginUser = HttpContext.Session.GetCLRObject<EmployeeModel>("loginUser");
            leaveModel.EmployeeId = ViewBag.loginUser.EmployeeId;
            if (ModelState.IsValid)
            {
                _context.Add(leaveModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveModel);
        }

        // GET: Leave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveModel = await _context.leaves.FindAsync(id);
            if (leaveModel == null)
            {
                return NotFound();
            }
            return View(leaveModel);
        }

        // POST: Leave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveId,EmployeeId,LeaveType,LeaveDateFrom,LeaveDateTo,Remark")] LeaveModel leaveModel)
        {
            if (id != leaveModel.LeaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveModelExists(leaveModel.LeaveId))
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
            return View(leaveModel);
        }

        // GET: Leave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveModel = await _context.leaves
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leaveModel == null)
            {
                return NotFound();
            }

            return View(leaveModel);
        }

        // POST: Leave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveModel = await _context.leaves.FindAsync(id);
            _context.leaves.Remove(leaveModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveModelExists(int id)
        {
            return _context.leaves.Any(e => e.LeaveId == id);
        }
    }
}
