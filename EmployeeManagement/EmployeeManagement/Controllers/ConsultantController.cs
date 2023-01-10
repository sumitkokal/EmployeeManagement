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
    public class ConsultantController : Controller
    {
        private readonly EmployeeContext _context;

        public ConsultantController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Consultant
        public async Task<IActionResult> Index()
        {
            return View(await _context.consultants.ToListAsync());
        }

        // GET: Consultant/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultantModel = await _context.consultants
                .FirstOrDefaultAsync(m => m.ConsultantId == id);
            if (consultantModel == null)
            {
                return NotFound();
            }

            return View(consultantModel);
        }

        // GET: Consultant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultantId,ConsultantName,Type,EmailId,MobileNo")] ConsultantModel consultantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultantModel);
        }

        // GET: Consultant/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultantModel = await _context.consultants.FindAsync(id);
            if (consultantModel == null)
            {
                return NotFound();
            }
            return View(consultantModel);
        }

        // POST: Consultant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConsultantId,ConsultantName,Type,EmailId,MobileNo")] ConsultantModel consultantModel)
        {
            if (id != consultantModel.ConsultantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultantModelExists(consultantModel.ConsultantId))
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
            return View(consultantModel);
        }

        // GET: Consultant/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultantModel = await _context.consultants
                .FirstOrDefaultAsync(m => m.ConsultantId == id);
            if (consultantModel == null)
            {
                return NotFound();
            }

            return View(consultantModel);
        }

        // POST: Consultant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consultantModel = await _context.consultants.FindAsync(id);
            _context.consultants.Remove(consultantModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultantModelExists(string id)
        {
            return _context.consultants.Any(e => e.ConsultantId == id);
        }
    }
}
