using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpManagement.Models;
using EmployeeManagement.Context;

namespace EmployeeManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly EmployeeContext _context;

        public RoleController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            return View(await _context.roles.ToListAsync());
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleModel = await _context.roles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // GET: Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleModel);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleModel = await _context.roles.FindAsync(id);
            if (roleModel == null)
            {
                return NotFound();
            }
            return View(roleModel);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName")] RoleModel roleModel)
        {
            if (id != roleModel.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleModelExists(roleModel.RoleId))
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
            return View(roleModel);
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleModel = await _context.roles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleModel = await _context.roles.FindAsync(id);
            _context.roles.Remove(roleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleModelExists(int id)
        {
            return _context.roles.Any(e => e.RoleId == id);
        }

        public async Task<IActionResult> AssignRole()
        {
            var empList = (await _context.employees.ToListAsync());
            var roleList = (await _context.roles.ToListAsync());
            return View();
        }
    }
}
