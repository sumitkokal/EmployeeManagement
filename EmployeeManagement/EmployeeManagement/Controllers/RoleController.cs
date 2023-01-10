﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class RoleController : Controller
    {
       // private readonly EmployeeContext _context;
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }

        public ViewResult Index() => View(roleManager.Roles);

        //// GET: Role/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required] string RoleName)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(RoleName));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(RoleName);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);

        }


        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        //// GET: Role
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.roles.ToListAsync());
        //}

        //// GET: Role/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleModel = await _context.roles
        //        .FirstOrDefaultAsync(m => m.RoleId == id);
        //    if (roleModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(roleModel);
        //}

      

        //// POST: Role/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("RoleId,RoleName")] RoleModel roleModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(roleModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(roleModel);
        //}

        //// GET: Role/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleModel = await _context.roles.FindAsync(id);
        //    if (roleModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(roleModel);
        //}

        //// POST: Role/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName")] RoleModel roleModel)
        //{
        //    if (id != roleModel.RoleId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(roleModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoleModelExists(roleModel.RoleId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(roleModel);
        //}

        //// GET: Role/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleModel = await _context.roles
        //        .FirstOrDefaultAsync(m => m.RoleId == id);
        //    if (roleModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(roleModel);
        //}

        //// POST: Role/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var roleModel = await _context.roles.FindAsync(id);
        //    _context.roles.Remove(roleModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RoleModelExists(int id)
        //{
        //    return _context.roles.Any(e => e.RoleId == id);
        //}

        //public async Task<IActionResult> AssignRole()
        //{
        //    var empList = (await _context.employees.ToListAsync());
        //    var roleList = (await _context.roles.ToListAsync());

        //    var RoleSelect = new List<SelectListItem>();
        //    foreach (var item in roleList)
        //    {
        //        RoleSelect.Add(new SelectListItem(item.RoleName, item.RoleId.ToString()));
        //    }
        //    ViewBag.RoleList = null;
        //    HttpContext.Session.SetSessionObject<List<SelectListItem>>("RoleList", RoleSelect);
        //    ViewBag.RoleList = RoleSelect;

        //    var EmployeeSelect = new List<SelectListItem>();
        //    foreach (var item in empList)
        //    {
        //        EmployeeSelect.Add(new SelectListItem(item.FirstName + " " + item.LastName, item.EmployeeId.ToString()));
        //    }
        //    ViewBag.EmployeeList = null;
        //    HttpContext.Session.SetSessionObject<List<SelectListItem>>("EmployeeList", RoleSelect);
        //    ViewBag.EmployeeList = EmployeeSelect;


        //    return View();
        //}
    }
}
