using EmployeeManagement.Context;
using EmployeeManagement.CustomSessions;
using EmpManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly EmployeeContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public RoleController(RoleManager<IdentityRole> roleMgr, EmployeeContext context, SignInManager<IdentityUser> signInManager)
        {
            _roleManager = roleMgr;
            _context = context;
            _signInManager = signInManager;
        }

        // public ViewResult Index() => View(_roleManager.Roles);

        public ViewResult Index() => View(_roleManager.Roles);

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
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(RoleName));
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
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);

        }

        public async Task<IActionResult> AssignRole()
        {
            var empList = (await _signInManager.UserManager.Users.ToListAsync());
            //var empList = (await _context.employees.ToListAsync());
            var roleList = (await _roleManager.Roles.ToListAsync());

            var RoleSelect = new List<SelectListItem>();
            foreach (var item in roleList)
            {
                RoleSelect.Add(new SelectListItem(item.Name, item.Id.ToString()));
            }
            ViewBag.RoleList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("RoleList", RoleSelect);
            ViewBag.RoleList = RoleSelect;

            var EmployeeSelect = new List<SelectListItem>();
            foreach (var item in empList)
            {
                EmployeeSelect.Add(new SelectListItem(item.UserName, item.Id.ToString()));
            }
            ViewBag.EmployeeList = null;
            HttpContext.Session.SetSessionObject<List<SelectListItem>>("EmployeeList", EmployeeSelect);
            ViewBag.EmployeeList = EmployeeSelect;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var empList = (await _signInManager.UserManager.Users.ToListAsync()).Find(c => c.Id == Convert.ToString(roleModel.UserId));
                var roleInfo = (await _roleManager.FindByIdAsync(roleModel.RoleId));
                IdentityResult result = await _signInManager.UserManager.AddToRoleAsync(empList, roleInfo.Name);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                    Errors(result);
                // else
                //    ModelState.AddModelError("", "No role found");
                return View("Index", _roleManager.Roles);
            }
            else
            {
                ModelState.AddModelError("", "No role found");
                return View("Index", _roleManager.Roles);
            }
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


    }
}
