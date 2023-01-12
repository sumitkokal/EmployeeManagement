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
                    var loggedInUser = HttpContext.Session.GetSessionObject<EmployeeModel>("loginUser");

                    var leavesByEmp = (await _context.leaves.ToArrayAsync()).Where(c => c.EmployeeId == loggedInUser.EmployeeId).ToList();
                    //   var await _context.leaves.ToListAsync()
                    return View(leavesByEmp);
                }
                else
                {
                    List<LeaveApproveModel> leaveApproveList = await GetLeaveForApprove();
                    return View("LeaveApproveIndex", leaveApproveList);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<List<LeaveApproveModel>> GetLeaveForApprove()
        {
            List<LeaveApproveModel> leaveApproveList = new List<LeaveApproveModel>();
            var leavesByEmp = (await _context.leaves.ToArrayAsync()).ToList();
            foreach (var item in leavesByEmp)
            {
                var emp = (await _context.employees.ToListAsync()).Where(c => c.EmployeeId == item.EmployeeId).ToList()[0];
                leaveApproveList.Add(new LeaveApproveModel
                {
                    EmployeeId = item.EmployeeId,
                    EmployeeName = emp.FirstName + " " + emp.LastName,
                    LeaveId = item.LeaveId,
                    LeaveType = item.LeaveType,
                    LeaveDateFrom = item.LeaveDateFrom,
                    LeaveDateTo = item.LeaveDateTo,
                    Status = item.Status,
                    Remark = item.Remark,
                    ApproveRemark=item.ApproveRemark,
                    LeaveApprovedDate=item.LeaveApprovedDate
                });
            }
            HttpContext.Session.SetSessionObject<List<LeaveApproveModel>>("leaveApproveList", leaveApproveList);
            return leaveApproveList;
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
            var dateAndTime = DateTime.Now;
            ViewBag.TodayDate = dateAndTime.Date;
            return View();
        }

        // POST: Leave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveId,EmployeeId,LeaveType,LeaveDateFrom,LeaveDateTo,Status,Remark")] LeaveModel leaveModel)
        {
            ViewBag.loginUser = HttpContext.Session.GetSessionObject<EmployeeModel>("loginUser");
            leaveModel.EmployeeId = ViewBag.loginUser.EmployeeId;
            leaveModel.Status = "New";
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

        public IActionResult LeaveApprove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = HttpContext.Session.GetSessionObject<List<LeaveApproveModel>>("leaveApproveList");

            var leaveModel = data.Where(c => c.LeaveId == id).FirstOrDefault();
            if (leaveModel == null)
            {
                return NotFound();
            }
            return View("LeaveApprove", leaveModel);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveApprove(int id, LeaveApproveModel leaveApprove)
        {
            if (leaveApprove.ApproveRemark != null)
            {
                var data = HttpContext.Session.GetSessionObject<List<LeaveApproveModel>>("leaveApproveList");

                var tempLeave = data.Where(c => c.LeaveId == id).FirstOrDefault();

                var dateAndTime = DateTime.Now;
                var date = dateAndTime.Date;
                LeaveModel leaveModel = new LeaveModel()
                {
                    LeaveApprovedDate = date,
                    LeaveId = id,
                    Status = "Approved",
                    ApproveRemark = leaveApprove.ApproveRemark,
                    LeaveDateFrom = tempLeave.LeaveDateFrom,
                    LeaveDateTo = tempLeave.LeaveDateTo,
                    Remark = tempLeave.Remark,
                    EmployeeId = tempLeave.EmployeeId,
                    LeaveType = tempLeave.LeaveType

                };

                _context.leaves.Update(leaveModel);
                await _context.SaveChangesAsync();
            }
            List<LeaveApproveModel> leaveApproveList = await GetLeaveForApprove();
            return View("LeaveApproveIndex", leaveApproveList);
        }


        // POST: Leave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveId,EmployeeId,LeaveType,LeaveDateFrom,LeaveDateTo,Status,Remark")] LeaveModel leaveModel)
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
